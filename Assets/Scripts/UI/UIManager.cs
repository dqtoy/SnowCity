using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UIDepthConst
{
    BottomDepth = 200,
    MiddleDepth = 400,
    TopDepth = 800,
}
public class UIManager : MonoSingleton<UIManager>
{
    //UI 摄像机
    public Camera uiCamera;
    
    public Dictionary<Type, UIScreen> screenDic;
    //用于记录所有已经打开的UI界面的
    private Dictionary<UIDepthConst, Stack<UIScreen>> screenOpened;
    private Dictionary<UIDepthConst, Transform> depthTrans;
    private Dictionary<Type, UIScreen> screenPool;
    private Dictionary<Type,UIMessage> openingMsgScreen;
    private Transform uiRoot;


    //非静态的字段，变量，属性不能用于静态的函数下
    public void Init()
    {
        screenDic = new Dictionary<Type, UIScreen>();
        screenOpened = new Dictionary<UIDepthConst, Stack<UIScreen>>();
        depthTrans = new Dictionary<UIDepthConst, Transform>();
        screenPool = new Dictionary<Type, UIScreen>();
        openingMsgScreen = new Dictionary<Type, UIMessage>();
        uiRoot = GameObject.Find("UIRoot").transform;
        UIDepth[] uiCollections = uiRoot.GetComponentsInChildren<UIDepth>();
        for (int i = 0; i < uiCollections.Length; i++)
        {
            uiCollections[i].Init();
            screenOpened.Add(uiCollections[i].depth, new Stack<UIScreen>());
            depthTrans.Add(uiCollections[i].depth, uiCollections[i].transform);
        }
        UIScreen[] screens = ResourceLoader.Instance.LoadAll<UIScreen>("UIScreens");
        for (int i = 0; i < screens.Length; i++)
        {
            screenDic.Add(screens[i].GetType(), screens[i]);
        }
        InitEvent();
    }

    //重载， 泛型， where用于约束泛型
    //Push用打开某个UI界面
    public T Push<T>(UIDepthConst uIDepthConst, bool hidePrevious = true, params object[] data) where T : UIScreen
    {
        return (T)Push(typeof(T), uIDepthConst, hidePrevious, data);
    }

    //打开一个新的窗口，并选择是否叠在前一个窗口上
    private UIScreen Push(Type screenType, UIDepthConst uIDepthConst, bool hidePrevious = true, params object[] data)
    {
        if (!screenDic.ContainsKey(screenType))
        {
            Debug.LogWarning("You are trying to open a screen not included in the folder");
            return null;
        }

        Stack<UIScreen> temp = screenOpened[uIDepthConst];
        if (hidePrevious && temp.Count > 0)
        {
            temp.Peek().OnHide();
        }
        UIScreen screenToPush;
        if (screenPool.ContainsKey(screenType))
        {
            screenToPush = screenPool[screenType];
            screenPool.Remove(screenType);
        }
        else
        {
            screenToPush = UnityEngine.Object.Instantiate(screenDic[screenType], depthTrans[uIDepthConst]);
            screenToPush.gameObject.name = screenType.Name;
        }
        screenToPush.OnInit(data);
        temp.Push(screenToPush);
        screenOpened[uIDepthConst] = temp;
        return screenToPush;
    }

    //关闭当前打开的窗口，并打开前一个窗口
    public UIScreen Pop(UIDepthConst uIDepthConst)
    {
        UIScreen screenToPop = screenOpened[uIDepthConst].Pop();

        screenToPop.OnHide();
        AddScreenToPool(screenToPop);
        if (screenOpened[uIDepthConst].Count > 0)
        {
            screenOpened[uIDepthConst].Peek().OnShow();
        }
        return screenToPop;
    }

    //重载， 泛型， where用于约束泛型
    //Push用打开某个UI界面
    public T ShowMessage<T>(UIDepthConst uIDepthConst,params object[] data) where T : UIMessage
    {
        return (T)ShowMessage(typeof(T), uIDepthConst, data);
    }

    //打开一个消息提示
    private UIScreen ShowMessage(Type screenType, UIDepthConst uIDepthConst, params object[] data)
    {
        if (!screenDic.ContainsKey(screenType))
        {
            Debug.LogWarning("You are trying to open a screen not included in the folder");
            return null;
        }
        if (openingMsgScreen.ContainsKey(screenType))
        {
            Destroy(openingMsgScreen[screenType].gameObject);
            openingMsgScreen.Remove(screenType);
        }

        UIMessage msgScreen = UnityEngine.Object.Instantiate(screenDic[screenType], depthTrans[uIDepthConst]) as UIMessage;
        openingMsgScreen.Add(screenType, msgScreen);
        msgScreen.OnInit(data);
        return msgScreen;
    }

    //关闭消息
    public void RemoveMessage(Type screenType)
    {
        if (openingMsgScreen.ContainsKey(screenType))
        {
            Destroy(openingMsgScreen[screenType].gameObject);
            openingMsgScreen.Remove(screenType);
        }
    }

    //返回到主菜单
    public void PopToBottom()
    {
        foreach (var screen in screenOpened)
        {
            while (screen.Value.Count > 0)
            {
                Pop(screen.Key);
            }
        }
        Push<UIScreenMainMenu>(UIDepthConst.BottomDepth);
    }

    //将一个已经关闭的窗口加到池中
    private void AddScreenToPool(UIScreen targetScreen)
    {
        screenPool.Add(targetScreen.GetType(), targetScreen);
    }

    private void InitEvent()
    {
        EventDispatcher.Inner.AddEventListener("FoundLake", OnFoundLake);
        EventDispatcher.Inner.AddEventListener("GameOver", OnGameOver);
    }

    private void OnFoundLake(object[] data)
    {
        UIManager.Instance.Push<UIMessageInGame>(UIDepthConst.TopDepth, false, "The road to the lake can allow pass now!", 5f);
    }

    private void OnGameOver(object[] data)
    {
        UIManager.Instance.Push<UIScreenCG>(UIDepthConst.TopDepth, false, "Maybe you have already realized. This world is only an imagination, a mirror of the real world. I created this world to guide those Frozen hearts, those who isolate themselves in this icy world, and those who are afraid to communicate with others just because of language barrier and culture difference. Someday you might realize that this world is not that complicated as you imgained. Unfreeze your heart and take your first step.             -- Aki, the creator of this world", 2f, 2.0f);
    }

}
