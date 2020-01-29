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
    public Function OnToggle;

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
        OnToggle?.Invoke();
    }
}
