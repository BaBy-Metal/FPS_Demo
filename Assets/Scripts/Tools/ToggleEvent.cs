using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEvent : MonoBehaviour
{
    public void SetToggle(bool sele)
    {
        MainGame.Instance.OnToggle(sele);
    }
}
