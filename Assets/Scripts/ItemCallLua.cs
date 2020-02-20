using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[CSharpCallLua]
public delegate void delegateFun();
public class ItemCallLua : MonoBehaviour
{
    public delegateFun OnStart;
    public delegateFun OnUpdate;
    public delegateFun OnDes;

    private void Start()
    {
        OnStart?.Invoke();
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    private void OnDestroy()
    {
        OnDes?.Invoke();
        OnStart = null;
        OnUpdate = null;
        OnDes = null;
    }
}
