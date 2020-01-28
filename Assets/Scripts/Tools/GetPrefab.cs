using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPrefab : MonoBehaviour
{
    public static Dictionary<string, GameObject> GetAll(string root, Dictionary<string, GameObject> dic = null)
    {
        if (dic == null)
        {
            dic = new Dictionary<string, GameObject>();
        }

        return dic;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("Player");

        foreach (var item in arr)
        {
            Debug.Log(item.GetInstanceID());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
