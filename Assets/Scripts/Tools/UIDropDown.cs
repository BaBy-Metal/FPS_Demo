using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void deleFun<T1, T2>(T1 t1, T2 t2);
public class UIDropDown : Dropdown
{
    public deleFun<GameObject, PointerEventData> func;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        //func(gameObject, eventData);
    }
}
