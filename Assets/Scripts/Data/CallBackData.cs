using System.Collections.Generic;

//ID : 回调方法的ID(int)
//EventName : 方法名称(string)
//Parameters : 方法参数(string)

public class CallBackData : Singleton<CallBackData>
{
    public Dictionary<int, Dictionary<string, string>> data = new Dictionary<int, Dictionary<string, string>>()
    {
        {10001, new Dictionary<string, string>(){ {"EventName", "PrintAAA"}, {"Parameters", "111,222"}, } },
        {10002, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10003, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10004, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10005, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10006, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10007, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10008, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10009, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10010, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10011, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
        {10012, new Dictionary<string, string>(){ {"EventName", ""}, {"Parameters", ""}, } },
    };

}
