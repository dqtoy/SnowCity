using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class CallBackModel : Singleton<CallBackModel> {

    public Dictionary<int, Dictionary<string, string>> data;
    public CallBackModel()
    {
        data = CallBackData.Instance.data;
    }

    public void InvokeMethod(int id)
    {
        string eventName = GetEventName(id);
        object[] paras = GetParams(id);
        try
        {
            EventDispatcher.Inner.DispatchEvent(eventName, paras);
            EventDispatcher.Outer.DispatchEvent(eventName, paras);
        }
        catch
        {
            Debug.Log("方法调用出错！");
        }
    }

    public string GetEventName(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            return data[id]["EventName"];
        }
        return res;
    }

    public object[] GetParams(int id)
    {
        object[] res = null;
        if (data.ContainsKey(id))
        {
            string[] str = data[id]["Parameters"].Split(',');
            if (str[0] == "")
                return res;
            int c = str.Length;
            res = new object[c];
            for (int i = 0; i < c; i++)
            {
                res[i] = str[i];
            }
        }
        return res;
    }
}
