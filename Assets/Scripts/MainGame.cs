using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        LuaMgr.Instance.Start("require 'MainGame'");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
