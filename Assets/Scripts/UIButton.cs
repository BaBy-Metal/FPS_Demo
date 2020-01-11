using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[XLua.CSharpCallLua]
public delegate void func<T>(T obj);
public class UIButton : Selectable
{
    public func<GameObject> func;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Debug.Log(eventData);
        func?.Invoke(gameObject);
    }
}
