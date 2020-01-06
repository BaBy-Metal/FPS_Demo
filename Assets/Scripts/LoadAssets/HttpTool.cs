using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System;
using System.Threading;

public class HttpTool
{
    const int count = 1024 * 10;
    static byte[] buffer = new byte[count];
    static HttpWebRequest request;
    static FileStream fileStream;
    static Stream stream;
    static string rootUri = "http://127.0.0.1/AB/";

    public static bool DownLoad(string fileFullPath, string fileName, long fileLenth = 0)
    {
        bool IsFlag = false;
        string fullUrl = rootUri + fileName;
        Debug.Log(fullUrl);
        Connect(fullUrl);

        Debug.Log(fileFullPath);
        string dirPath = Path.GetDirectoryName(fileFullPath);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        try
        {
            stream = request.GetResponse().GetResponseStream();
            fileStream = File.Open(fileFullPath, FileMode.OpenOrCreate);

            int loadLen = 0;
            int fileLen = stream.Read(buffer, 0, buffer.Length);
            while (fileLen > 0)
            {
                loadLen += fileLen;
                fileStream.Write(buffer, 0, fileLen);
                fileLen = stream.Read(buffer, 0, buffer.Length);
                Thread.Sleep(5);
            }

            IsFlag = true;
        }
        catch (Exception)
        {
            Debug.LogError("文件下载失败");
            IsFlag = false;
        }
        finally
        {
            if (request != null)
            {
                request.Abort();
                request = null;
            }
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }
        }
        return IsFlag;
    }

    private static void Connect(string fullUrl)
    {
        request = WebRequest.CreateHttp(new Uri(fullUrl));
        request.KeepAlive = false;
    }
}
