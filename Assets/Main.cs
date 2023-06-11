using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using HGH.Common;
using System.IO;
using System.Reflection;
using System;

[System.Serializable]
public class Config
{
    public string name;
    public int index;
    public List<string> list;
    public int[] objArray;
    public Dictionary<string, int> Dic;
}

public class Main : Config<Config>
{
    public int A;

    public int B
    {
        get;
        set;
    }

    private void Start()
    {
        Type type = typeof(Main);
        MethodInfo[] methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        for (int i = 0; i < methodInfos.Length; i++)
        {
            Debug.Log(methodInfos[i].Name);
        }
    }

    private void 哈哈数据()
    {

    }
}
