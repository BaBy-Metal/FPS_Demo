using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    static PlayerMgr instance = null;
    public static PlayerMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerMgr>();
            }

            return instance;
        }
    }

    float x;
    float z;
    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        RoleMove();
    }

    void RoleMove()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        //print(x + "," + z);
        transform.Translate(new Vector3(x, 0, z));
    }
}
