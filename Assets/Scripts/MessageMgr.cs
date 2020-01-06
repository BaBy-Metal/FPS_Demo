using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMgr 
{
    static MessageMgr instance = null;
    public static MessageMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MessageMgr();
            }

            return instance;
        }
    }

    public Dictionary<string, Action> actionDic;
    public void Init()
    {
        actionDic = new Dictionary<string, Action>();
    }
}
