using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

public class LuaMgr 
{
    static LuaMgr instance = null;
    public static LuaMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LuaMgr();
            }

            return instance;
        }
    }

    public LuaEnv luaEnv;

    // Start is called before the first frame update
    public void Start(string file)
    {
        Init();
        luaEnv.DoString(file);
    }

    public void Init()
    {
        if (luaEnv == null)
        {
            luaEnv = new LuaEnv();
            luaEnv.AddLoader(LoadLuaFile);
        }
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
}
