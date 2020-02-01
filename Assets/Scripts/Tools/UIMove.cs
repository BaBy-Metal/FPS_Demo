using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[XLua.LuaCallCSharp]
public class UIMove : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    RectTransform rt;

    // 位置偏移量
    Vector3 offset = Vector3.zero;
    // 最小、最大X、Y坐标
    float minX, maxX, minY, maxY;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        SetDragRange();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.enterEventCamera, out Vector3 globalMousePos))
        {
            // 计算偏移量
            //SetDragRange();
            Debug.Log("开始拖拽");
            offset = rt.position - globalMousePos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //if (-365 < rt.anchoredPosition.x && rt.anchoredPosition.x < 365)
        //{
        //    if (rt.anchoredPosition.y < 165 && rt.anchoredPosition.y > -165)
        //    {
        // 将屏幕空间上的点转换为位于给定RectTransform平面上的世界空间中的位置
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out Vector3 globalMousePos))
        {
            // 设置拖拽范围
            //Debug.Log("拖拽中");
            rt.position = DragRangeLimit(globalMousePos + offset);
            //rt.position = offset + globalMousePos;
        }
        //    }
        //}
    }

    // 设置最大、最小坐标
    void SetDragRange()
    {
        Debug.Log(Screen.width + "+" + Screen.height);
        Debug.Log(rt.rect.width + "+" + rt.rect.height);
        minX = -((Screen.width - rt.rect.width) / 2) / Screen.width * 12;
        maxX = ((Screen.width - rt.rect.width) / 2) / Screen.width * 12;
        minY = -((Screen.height - rt.rect.height) / 2) / Screen.height * 10;
        maxY = ((Screen.height - rt.rect.height) / 2) / Screen.height * 10;

        Debug.Log("minX:" + minX + ",maxX:" + maxX + ",minY:" + minY + ",maxY:" + maxY);
    }

    // 限制坐标范围
    Vector3 DragRangeLimit(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        Debug.Log("面板实际位置x:" + pos.x);
        Debug.Log("面板实际位置y:" + pos.y);

        return pos;
    }
}