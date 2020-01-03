using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAsyn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string URL = @"D:\testunityweb.txt";
        UnityWebRequest unity_web = UnityWebRequest.Get(URL);
        UnityWebRequestAsyncOperation _webao = unity_web.SendWebRequest();
        _webao.completed += (_ao) =>
        {
            Debug.Log(unity_web.downloadHandler.text);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
