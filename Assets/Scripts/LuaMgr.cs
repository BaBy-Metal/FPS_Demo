using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

public class LuaMgr : MonoBehaviour
{
    static LuaMgr instance = null;
    public static LuaMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LuaMgr>();
            }

            return instance;
        }
    }

    LuaEnv luaEnv;


    // Start is called before the first frame update
    void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(LoadLuaFile);
        luaEnv.DoString("require 'MainGame'");
    }

    private byte[] LoadLuaFile(ref string filepath)
    {
        string path = string.Empty;
        byte[] file = null;
#if LOAD_AB
        path = Application.persistentDataPath + "/AB/" + filepath + ".lua";
        file = SecurityUtil.Xor(File.ReadAllBytes(path));
#else
        path = Application.dataPath + "/Resources/lua/" + filepath + ".lua";
        file = File.ReadAllBytes(path);
#endif
        return file;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
