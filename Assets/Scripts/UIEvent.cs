using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// UI  界面事件
/// </summary>
[AddComponentMenu("Tools/UIEvent")]
public class UIEvent : EventTrigger
{
    public static UIEvent ADD(GameObject O)
    {
        UIEvent d = O.GetComponent<UIEvent>();
        if (d != null)
            return d;

        return O.AddComponent<UIEvent>();
    }

    /// <summary>
    /// 添加事件回调函数
    /// </summary>
    /// <param name="type"></param>
    /// <param name="Fun"></param>
    public void AddFunction(EventTriggerType type, Action<GameObject> Fun)
    {
        keyActions[type] = Fun;
    }
    /// <summary>
    /// 函数回调字典
    /// </summary>
    private Dictionary<EventTriggerType, Action<GameObject>> keyActions = new Dictionary<EventTriggerType, System.Action<GameObject>>();
    //
    // 摘要:
    //     Called before a drag is started.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (keyActions.ContainsKey(EventTriggerType.BeginDrag))
        {
            keyActions[EventTriggerType.BeginDrag](gameObject);
        }
    }
    //
    // 摘要:
    //     Called by the EventSystem when a Cancel event occurs.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnCancel(BaseEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.Cancel)) { keyActions[EventTriggerType.Cancel](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when a new object is being selected.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnDeselect(BaseEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.Deselect)) { keyActions[EventTriggerType.Deselect](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem every time the pointer is moved during dragging.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnDrag(PointerEventData eventData)
    {
        if (keyActions.ContainsKey(EventTriggerType.Drag))
        {
            keyActions[EventTriggerType.Drag](gameObject);
        }
    }
    //
    // 摘要:
    //     Called by the EventSystem when an object accepts a drop.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnDrop(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.Drop)) { keyActions[EventTriggerType.Drop](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem once dragging ends.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnEndDrag(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.EndDrag)) { keyActions[EventTriggerType.EndDrag](eventData.pointerEnter); } }
    //
    // 摘要:
    //     Called by the EventSystem when a drag has been found, but before it is valid
    //     to begin the drag.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnInitializePotentialDrag(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.InitializePotentialDrag)) { keyActions[EventTriggerType.InitializePotentialDrag](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when a Move event occurs.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnMove(AxisEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.InitializePotentialDrag)) { keyActions[EventTriggerType.InitializePotentialDrag](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when a Click event occurs.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnPointerClick(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.PointerClick)) { keyActions[EventTriggerType.PointerClick](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when a PointerDown event occurs.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnPointerDown(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.PointerDown)) { keyActions[EventTriggerType.PointerDown](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when the pointer enters the object associated with
    //     this EventTrigger.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnPointerEnter(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.PointerEnter)) { keyActions[EventTriggerType.PointerEnter](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when the pointer exits the object associated with this
    //     EventTrigger.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnPointerExit(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.PointerExit)) { keyActions[EventTriggerType.PointerExit](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when a PointerUp event occurs.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnPointerUp(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.PointerUp)) { keyActions[EventTriggerType.PointerUp](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when a Scroll event occurs.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnScroll(PointerEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.Scroll)) { keyActions[EventTriggerType.Scroll](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when a Select event occurs.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnSelect(BaseEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.Select)) { keyActions[EventTriggerType.Select](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when a Submit event occurs.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnSubmit(BaseEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.Submit)) { keyActions[EventTriggerType.Submit](gameObject); } }
    //
    // 摘要:
    //     Called by the EventSystem when the object associated with this EventTrigger is
    //     updated.
    //
    // 参数:
    //   eventData:
    //     Current event data.
    public override void OnUpdateSelected(BaseEventData eventData) { if (keyActions.ContainsKey(EventTriggerType.UpdateSelected)) { keyActions[EventTriggerType.UpdateSelected](gameObject); } }
}
