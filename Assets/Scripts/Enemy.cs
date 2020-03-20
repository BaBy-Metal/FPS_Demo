using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //获取鼠标点击的点，
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;  //声明RacastHit类型
            if (Physics.Raycast(ray, out rayhit))
            {
                //if (rayhit.transform.name == "Plane") //判断是不是点击地面
                //{
                    //鼠标点击的点赋值给目标点
                    nav.SetDestination(rayhit.point);
                //}
            }
        }

        //nav.SetDestination(new Vector3(0, 0, 0));
    }
}
