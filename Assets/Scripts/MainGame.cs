using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XLua;

[CSharpCallLua]
public delegate void Function();
[CSharpCallLua]
public delegate void Function<T>(T t);
[CSharpCallLua]
[LuaCallCSharp]
public class MainGame : MonoBehaviour
{
    [CSharpCallLua]
    public Function OnAwake;
    [CSharpCallLua]
    public Function OnStart;
    [CSharpCallLua]
    public Function OnUpdate;
    [CSharpCallLua]
    public Function _OnDestroy;
    public Function<bool> OnToggle;

    static MainGame instance = null;
    public static MainGame Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MainGame>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        MessageMgr.Instance.Init();
        LuaMgr.Instance.Init();
        LuaMgr.Instance.luaEnv.Global.Set("this", this);
        LuaMgr.Instance.luaEnv.DoString("require 'MainGame'");
    }

    private void Update()
    {
        OnUpdate?.Invoke();
        Toggle toggle = GetComponent<Toggle>();
        

        //OnToggle?.Invoke();
    }
}
