using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class StringDispose 
{
    [LuaCallCSharp]
    public static string Replace(string sourceStr,string oldValue,string newValue)
    {
        string str = sourceStr.Replace(oldValue, newValue);
        return str;
    }

    [LuaCallCSharp]
    public static string[] Split(string sourceStr,string[] splitStr)
    {
        string[] arr= sourceStr.Split(splitStr, StringSplitOptions.None);
        return arr;
    }

    [LuaCallCSharp]
    public static string[] Split(string sourceStr, string chr)
    {
        char[] arr=chr.ToCharArray();
        string[] a = sourceStr.Split(arr[0]);
        return a;
    }
}
