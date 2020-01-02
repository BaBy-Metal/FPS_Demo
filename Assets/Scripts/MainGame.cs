using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.Instance.Start("require 'MainGame'");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
