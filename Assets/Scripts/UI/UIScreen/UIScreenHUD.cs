using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIScreenHUD : UIScreen
{
    public GameObject[] slots;
    public Text targetText;

    private float totalTime;
    private float attackedNoticeTime;
    private Camera mainCam;

    protected override void InitComponent()
    {
        mainCam = Camera.main;
        EventDispatcher.Inner.AddEventListener("GotStoneTabletOne", OnGotStoneTabletOne);
        EventDispatcher.Inner.AddEventListener("GotStoneTabletTwo", OnGotStoneTabletTwo);
        EventDispatcher.Outer.AddEventListener("UpdateMission", UpdateMission);
    }

    protected override void InitData()
    {

    }

    protected override void InitView()
    {

    }

    private void UpdateMission(object[] data)
    {
        int dis = (int)(float)data[0];
        targetText.text = "Distance to next target: " + dis.ToString() + " m.";
    }

    public override void OnClose()
    {
        EventDispatcher.Inner.RemoveAllListener("GotStoneTabletOne");
        EventDispatcher.Inner.RemoveAllListener("GotStoneTabletTwo");
        EventDispatcher.Outer.RemoveAllListener("UpdateMission");
        base.OnClose();
    }

    private void OnGotStoneTabletOne(object[] data)
    {
        MissionManager.Instance.Move();
        UIManager.Instance.Push<UIMessageInGame>(UIDepthConst.TopDepth, false, "Aki got the slabstone one, which can help Aki understand the snowman's language better!", 3.0f);
        slots[0].SetActive(true);
    }

    private void OnGotStoneTabletTwo(object[] data)
    {
        UIManager.Instance.Push<UIMessageInGame>(UIDepthConst.TopDepth, false, "Aki got the slabstone two, which can help Aki understand the snowman's language better!", 3.0f);
        slots[1].SetActive(true);
    }
}
