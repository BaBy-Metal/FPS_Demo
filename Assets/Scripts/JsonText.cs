using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Student
{
    public int ID;
    public string Name;
    public int height;

    public Student() { }
    public Student(int ID, string Name, int height)
    {
        this.ID = ID;
        this.Name = Name;
        this.height = height;
    }

    public void Log() 
    { 
        Debug.Log("ID：" + ID + "Name：" + Name + "height：" + height);
    }
}

public class MYClass
{
    public List<Student> dic = new List<Student>();
    public void ADD(int Index, Student T)
    {
        dic.Add(T);
    }
    public void Log()
    {
        for (int i = 0; i < dic.Count; i++)
        {
            dic[i].Log();
        }

    }

}
public class JsonText : MonoBehaviour
{
    [ContextMenu("生成Json")]
    public void __writeJson()
    {
        MYClass mYClass = new MYClass();

        for (int i = 0; i < 5; i++)
        {
            mYClass.ADD(i, new Student(i, "小明" + i, 2));
        }

        JsonINI<MYClass> d = new JsonINI<MYClass>();
        d.writeFile(mYClass, Application.dataPath + "/__VR1710Josn.json");

    }
    [ContextMenu("读取Json")]
    public void __readJson()
    {
        JsonINI<MYClass> d = new JsonINI<MYClass>();
        MYClass josndata = d.readFile(Application.dataPath + "/__VR1710Josn.json");

        josndata.Log();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class JsonINI<T> where T : MYClass
{
    internal T readFile(string v)
    {
        return null;
    }

    internal T writeFile(T t,string v)
    {
        return null;
    }
}