﻿using System.Collections.Generic;
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

    /// <summary>
    /// csv文件线程
    /// </summary>
    Thread LoadCsv;

    /// <summary>
    /// 大文件下载路径
    /// </summary>
    Thread LoadLargeFiles;

    /// <summary>
    /// 小文件下载路径
    /// </summary>
    Thread LoadLettelFiles;

    /// <summary>
    /// 下载根路径
    /// </summary>
    string loadRootPath;

    /// <summary>
    /// 所有文件总长度
    /// </summary>
    long TotalFilesLength = 0;

    /// <summary>
    /// 需要下载的文件总数
    /// </summary>
    int TotalNumFilesByLoad = 0;
    /// <summary>
    /// 已下载文件数
    /// </summary>
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
    string version;

    private void Start()
    {
        currentLen = new Queue<long>();
        version = Application.version;
        InitShow();
        loadRootPath = Application.persistentDataPath + "/AB";

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
            AllLoad.value = (float)loadedFilesNum / TotalNumFilesByLoad;
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
        AllLoad.value = 1;

        Thread.Sleep(100);
        DontDestroyOnLoad(GameObject.Find("Start"));
        SceneManager.LoadScene("LoadGameScene");

        if (LuaMgr.Instance.luaEnv != null)
        {
            Action action = LuaMgr.Instance.luaEnv.Global.Get<Action>("OnStart");
            action?.Invoke();
        }
    }

    /// <summary>
    /// 显示界面初始化
    /// </summary>
    private void InitShow()
    {
        AllLoad.value = 0;
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
            line = csv.ReadLine();

            if (line.Split(',')[1] == version)
            {
                Debug.LogError("版本相同无需下载");
                return;
            }

            line = string.Empty;

            while ((line = csv.ReadLine()) != null)
            {
                string[] tmpFile = line.Split(',');
                Msg Msg = new Msg(tmpFile[0], tmpFile[1], tmpFile[2]);

                fileQueue.Enqueue(Msg);
                line = string.Empty;
            }
            Debug.Log(fileQueue.Count);

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
                if (IsLoad)
                {
                    if (file.fileLen > 1024 * 10)
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

            Debug.Log(lettleFiles.Count);
            Debug.Log(largeFiles.Count);

            while (lettleFiles.Count > 0)
            {
                DownLoadLettelFiles += delegate ()
                {
                    //Debug.Log("执行委托");
                    int downloadCount = 3;

                    bool IsLoad = lettleFiles.TryDequeue(out Msg file);

                    if (IsLoad)
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

            while (largeFiles.Count > 0)
            {
                DownLoadLargeFiles += delegate ()
                {
                    //Debug.Log("执行委托");
                    int downloadCount = 3;

                    bool IsLoad = largeFiles.TryDequeue(out Msg file);
                    Debug.Log(file.httpDownLoadPath);
                    string tmpPath = loadRootPath + "/" + file.httpDownLoadPath;

                    if (IsLoad)
                    {
                        BBBB:
                        if (tmpPath != null)
                        {
                            bool IsDownLoad = HttpTool.DownLoad(tmpPath, file.fileName);
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
        fileLen = long.Parse(a2);
        md5 = a1;

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