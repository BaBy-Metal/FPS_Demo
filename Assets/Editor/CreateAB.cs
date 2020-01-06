using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Security.Cryptography;

public class CreateAB : Editor
{
    static string rootPath = string.Empty;
    static Action action;

    [MenuItem("Tools/一键打包")]
    static void Create()
    {
        rootPath = Application.dataPath.Replace("Assets", "AB");
        if (!Directory.Exists(rootPath))
        {
            Directory.CreateDirectory(rootPath);
        }

        Infect();
        BuildPipeline.BuildAssetBundles(rootPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        CreateCsv();
    }

    static StreamWriter writer;

    private static void CreateCsv()
    {
        if (rootPath.Equals(string.Empty)) rootPath = Application.dataPath.Replace("Assets", "AB");
        string csvPath = rootPath + "/data.csv";
        if (File.Exists(csvPath))
        {
            File.Delete(csvPath);
        }

        List<FileMsg> fileMsgs = SearchFiles(rootPath, ".manifest");
        foreach (var item in fileMsgs)
        {
            item.SetValue("AB\\", "AB\\");
        }

        try
        {
            writer = new StreamWriter(csvPath);
            writer.WriteLine("Version:" + "," + Application.version);
            foreach (var item in fileMsgs)
            {
                byte[] file = File.ReadAllBytes(item.fullPath);
                string md5 = GetMD5(file);
                writer.WriteLine(item.UnAssetsPath + "," + md5 + "," + file.Length);
            }
        }
        catch (Exception)
        {
            Debug.LogError("文件写入失败");
        }
        if (writer != null)
        {
            writer.Close();
            writer = null;
        }
    }

    private static string GetMD5(byte[] file)
    {
        MD5Cng mD5 = new MD5Cng();
        byte[] code = mD5.ComputeHash(file);
        string md5 = BitConverter.ToString(code);
        md5 = md5.Replace("-", "");

        return md5;
    }

    private static void Infect()
    {
        string resPath = "Assets/Resources";

        List<FileMsg> fileMsgs = SearchFiles(resPath);

        foreach (var item in fileMsgs)
        {
            item.SetValue("Assets\\", "Resources\\");
        }

        foreach (var item in fileMsgs)
        {
            AssetImporter importer = AssetImporter.GetAtPath(item.dataPath);
            string path = string.Empty;

            if (item.extension.EndsWith("prefab"))
            {
                path = "prefab/" + item.fileName;
            }
            else if(item.extension.EndsWith("png")|| item.extension.EndsWith("jpg"))
            {
                path = "pic/" + item.fileName;
            }
            else
            {
                path = "other/" + item.fileName;
            }

            importer.assetBundleName = path;
            importer.assetBundleVariant = "ab";
        }
    }

    private static List<FileMsg> SearchFiles(string resPath, string extension = null, List<FileMsg> files = null)
    {
        if (files == null)
        {
            files = new List<FileMsg>();
        }

        string[] filesPath = Directory.GetFiles(resPath);
        if (filesPath != null)
        {
            foreach (var item in filesPath)
            {
                string exten = Path.GetExtension(item);
                if (exten != extension && exten != ".meta")
                {
                    FileMsg msg = new FileMsg()
                    {
                        fileName = Path.GetFileNameWithoutExtension(item),
                        fullPath = Path.GetFullPath(item),
                        extension = exten
                    };

                    files.Add(msg);
                }
            }
        }

        string[] dirPath = Directory.GetDirectories(resPath);
        if (dirPath != null)
        {
            foreach (var item in dirPath)
            {
                SearchFiles(item, extension, files);
            }
        }

        return files;
    }
}

public class FileMsg
{
    public string fullPath = string.Empty;
    public string fileName = string.Empty;
    public string dataPath = string.Empty;
    public string extension = string.Empty;
    public string UnAssetsPath = string.Empty;

    public void SetValue(string oldStr = null, string newStr = null)
    {
        if (!fullPath.Equals(string.Empty))
        {
            string tmp = fullPath.Replace(oldStr, "#" + oldStr);
            dataPath = tmp.Split('#')[1];
            string[] a = tmp.Split(new string[] { newStr }, StringSplitOptions.None);
            UnAssetsPath = a[a.Length - 1];
        }
    }
}