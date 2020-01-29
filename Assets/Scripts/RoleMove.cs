using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[CSharpCallLua]
public class RoleMove : MonoBehaviour
{
    public static Function OnDown;
    public static Function<Transform> OnDrag;
    public static Function OnUp;

    private void OnMouseDown()
    {
        OnDown?.Invoke();
    }

    private void OnMouseDrag()
    {
        OnDrag?.Invoke(transform);
    }

    private void OnMouseUp()
    {
        OnUp?.Invoke();
    }
}
