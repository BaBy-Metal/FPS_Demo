using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[CSharpCallLua]
public class RoleMove : MonoBehaviour
{
    public Function OnDown;
    public Function OnDrag;
    public Function OnUp;

    private void Awake()
    {
        if (LuaMgr.Instance.luaEnv != null)
        {
            LuaMgr.Instance.luaEnv.Global.Set("RoleMove", this);
        }

        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //if (LuaMgr.Instance.luaEnv == null)
        //{
        //    LuaMgr.Instance.Init();
        //    LuaMgr.Instance.luaEnv.Global.Set("RoleMove", this);
        //    LuaMgr.Instance.luaEnv.DoString("require 'ModelDrag'");
        //    Debug.Log("应该添加成功了");
        //}
    }

    private void OnMouseDown()
    {
        OnDown?.Invoke();
    }

    private void OnMouseDrag()
    {
        OnDrag?.Invoke();
        //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 60);
    }

    private void OnMouseUp()
    {
        OnUp?.Invoke();
    }
}
