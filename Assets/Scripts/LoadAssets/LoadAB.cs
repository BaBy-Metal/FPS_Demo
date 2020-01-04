using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Threading;
using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using System.Collections.Concurrent;
using System.Collections;

public class LoadAB : MonoBehaviour
{
    public Slider AllLoad;
    public Slider SingleLoad;
    public Text AllText;
    public Text SingleText;

    Thread LoadCsv;
    Thread LoadLargeFiles;
    Thread LoadLettelFiles;

    string loadRootPath;
    long TotalFilesLength = 0;

    int TotalNumFilesByLoad = 0;
    int loadedFilesNum = 0;

    /// <summary>
    /// 当前文件大小
    /// </summary>
    Queue<long> currentLen;

    /// <summary>
    /// 下载大文件委托 大于1kb算大文件
    /// </summary>
    Action DownLoadLargeFiles;

    /// <summary>
    /// 下载小文件委托
    /// </summary>
    Action DownLoadLettelFiles;

    private void Start()
    {
        currentLen = new Queue<long>();
        InitShow();
        loadRootPath = Application.streamingAssetsPath + "/AB";

        LoadCsv = new Thread(LoadVerAndCSV);
        LoadLargeFiles = new Thread(LoadLargeFilesByCsv);
        LoadLettelFiles = new Thread(LoadLettelFilesByCsv);

        LoadCsv.Start();
        LoadLargeFiles.Start();
        LoadLettelFiles.Start();
    }

    /// <summary>
    /// 线程调用循环执行委托 下载小文件
    /// </summary>
    private void LoadLettelFilesByCsv()
    {
        while (true)
        {
            DownLoadLettelFiles?.Invoke();
        }
    }

    /// <summary>
    /// 线程调用循环执行委托 下载大文件
    /// </summary>
    private void LoadLargeFilesByCsv()
    {
        while (true)
        {
            DownLoadLargeFiles?.Invoke();
        }
    }


    private void Update()
    {
        // 显示数据 需要提炼到显示层里
        if (currentLen.Count > 0)
        {
            ShowMsg(currentLen.Dequeue());
        }
    }

    /// <summary>
    /// 显示下载界面
    /// </summary>
    /// <param name="v"></param>
    private void ShowMsg(long v)
    {
        if (v != TotalFilesLength)
        {
            AllText.text = "正在下载 FTP AB包资源：[" + loadedFilesNum + "/" + TotalNumFilesByLoad + "]";
            SingleText.text = "进度：[" + ((v) / (float)TotalFilesLength) * 100 + "%]";
            AllLoad.value = loadedFilesNum / TotalNumFilesByLoad;
            SingleLoad.value = ((v) / (float)TotalFilesLength);
        }
        else
        {
            EndShow();
        }
    }

    /// <summary>
    /// 下载结束显示
    /// </summary>
    private void EndShow()
    {
        AllText.text = "已是最新版本";
        SingleText.text = "进度：[100%]";
        AllLoad.value = 1;
        SingleLoad.value = 1;

        Thread.Sleep(100);
        SceneManager.LoadScene("CheckScene");
    }

    /// <summary>
    /// 显示界面初始化
    /// </summary>
    private void InitShow()
    {
        AllLoad.value = 0;
        SingleLoad.value = 0;
        AllText.text = "正在校验文件中。。。";
        SingleText.text = "请耐心等待。。。";
    }

    /// <summary>
    /// csv文件流
    /// </summary>
    StreamReader csv;
    /// <summary>
    /// 当前文件下载长度
    /// </summary>
    long currentFileLen = 0;

    /// <summary>
    /// 下载版本文件和csv配置表
    /// </summary>
    private void LoadVerAndCSV()
    {
        int count = 3;

        if (!Directory.Exists(loadRootPath))
        {
            Directory.CreateDirectory(loadRootPath);
        }

        AAAA:
        string csvPath = loadRootPath + "/data.csv";
        Debug.Log(csvPath);
        bool IsDown = HttpTool.DownLoad(csvPath, "data.csv");
        Thread.Sleep(20);
        if (!IsDown)
        {
            if (count-- > 0)
                goto AAAA;
            else
            {
                Debug.LogError("csv文件下载失败");
                return;
            }
        }

        try
        {
            csv = new StreamReader(csvPath);
            string line = string.Empty;
            Queue<Msg> fileQueue = new Queue<Msg>();

            while ((line = csv.ReadLine()) != null)
            {
                string[] tmpFile = line.Split(',');
                Msg Msg = new Msg(tmpFile[0], tmpFile[1], tmpFile[2]);
                fileQueue.Enqueue(Msg);
            }

            ConcurrentQueue<Msg> needLoadFiles = new ConcurrentQueue<Msg>();

            while (fileQueue.Count > 0)
            {
                Msg Msg = fileQueue.Dequeue();
                string fullPath = loadRootPath + "/" + Msg.httpDownLoadPath;
                if (File.Exists(fullPath))
                {
                    string localFileMD5 = GetMD5WithFile(fullPath);
                    if (localFileMD5 != Msg.md5)
                    {
                        TotalFilesLength += Msg.fileLen;
                        needLoadFiles.Enqueue(Msg);
                        Thread.Sleep(20);
                        File.Delete(fullPath);
                    }
                }
                else
                {
                    needLoadFiles.Enqueue(Msg);
                    TotalFilesLength += Msg.fileLen;
                }
            }

            TotalNumFilesByLoad = needLoadFiles.Count;
            ConcurrentQueue<Msg> lettleFiles = new ConcurrentQueue<Msg>();
            ConcurrentQueue<Msg> largeFiles = new ConcurrentQueue<Msg>();

            // 从所有文件里按文件大小进行筛选
            while (needLoadFiles.Count > 0)
            {
                bool IsLoad = needLoadFiles.TryDequeue(out Msg file);
                if (!IsLoad)
                {
                    if (file.fileLen > 1024)
                    {
                        largeFiles.Enqueue(file);
                    }
                    else
                    {
                        lettleFiles.Enqueue(file);
                    }
                }

                if (needLoadFiles.Count == 0) break;
            }

            StartCoroutine(StartLoadLettle(lettleFiles));

            while (largeFiles.Count > 0)
            {
                DownLoadLargeFiles += delegate ()
                {
                    //Debug.Log("执行委托");
                    int downloadCount = 3;

                    bool IsLoad = largeFiles.TryDequeue(out Msg file);
                    Debug.Log(loadRootPath + "/" + file.fileName);

                    if (!IsLoad)
                    {
                        BBBB:
                        bool IsDownLoad = HttpTool.DownLoad(loadRootPath + "/" + file.httpDownLoadPath, file.fileName);
                        if (!IsDownLoad)
                        {
                            if (downloadCount-- > 0)
                                goto BBBB;
                            else
                                return;
                        }

                        currentFileLen += file.fileLen;
                        loadedFilesNum++;
                        currentLen.Enqueue(currentFileLen);
                    }
                };
            }


            if (largeFiles.Count <= 0 || lettleFiles.Count <= 0)
            {
                currentLen.Enqueue(currentFileLen);
                DownLoadLargeFiles = null;
            }
        }
        catch (Exception)
        {
            Debug.LogError("获取csv文件失败");
        }
        finally
        {
            if (csv != null)
            {
                csv.Close();
                csv = null;
            }
        }
    }

    /// <summary>
    /// 开启协程同步下载小文件
    /// </summary>
    /// <param name="lettleFiles"></param>
    /// <returns></returns>
    private IEnumerator StartLoadLettle(ConcurrentQueue<Msg> lettleFiles)
    {
        while (lettleFiles.Count > 0)
        {
            DownLoadLettelFiles += delegate ()
            {
                //Debug.Log("执行委托");
                int downloadCount = 3;

                bool IsLoad = lettleFiles.TryDequeue(out Msg file);
                Debug.Log(loadRootPath + "/" + file.fileName);

                if (!IsLoad)
                {
                    BBBB:
                    bool IsDownLoad = HttpTool.DownLoad(loadRootPath + "/" + file.httpDownLoadPath, file.fileName);
                    if (!IsDownLoad)
                    {
                        if (downloadCount-- > 0)
                            goto BBBB;
                        else
                            return;
                    }

                    currentFileLen += file.fileLen;
                    loadedFilesNum++;
                    currentLen.Enqueue(currentFileLen);
                }
            };
        }

        if (lettleFiles.Count <= 0)
        {
            currentLen.Enqueue(currentFileLen);
            DownLoadLargeFiles = null;
        }

        yield return null;
    }

    /// <summary>
    /// 获取本地文件MD5码
    /// </summary>
    /// <param name="fullPath"></param>
    /// <returns></returns>
    private string GetMD5WithFile(string fullPath)
    {
        StreamReader reader = File.OpenText(fullPath);
        MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
        byte[] md5Arr = mD5.ComputeHash(reader.BaseStream);
        string md5 = BitConverter.ToString(md5Arr);

        md5 = md5.Replace("-", "");
        if (reader != null)
        {
            reader.Close();
            reader.Dispose();
            reader = null;
        }

        return md5;
    }

    private void OnDestroy()
    {
        Destroy(this);
    }
}

public class Msg
{
    public string fileName;
    public long fileLen;
    public string md5;
    public string httpDownLoadPath;

    public Msg(string a0, string a1, string a2)
    {
        fileName = a0;
        fileLen = long.Parse(a1);
        md5 = a2;

        char chr = GetChar();
        httpDownLoadPath = fileName.Replace(chr, '/');
    }

    private char GetChar()
    {
        char chr = ' ';

        string[] a = fileName.Split('/');
        string[] b = fileName.Split('\\');

        if (a.Length > b.Length)
        {
            chr = '/';
        }
        else
        {
            chr = '\\';
        }

        return chr;
    }
}