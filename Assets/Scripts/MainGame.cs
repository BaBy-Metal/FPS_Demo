using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XLua;

[CSharpCallLua]
public delegate void Function();
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

    private void Awake()
    {
        MessageMgr.Instance.Init();
        LuaMgr.Instance.Init();
        LuaMgr.Instance.luaEnv.DoString("require 'MainGame'");
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
