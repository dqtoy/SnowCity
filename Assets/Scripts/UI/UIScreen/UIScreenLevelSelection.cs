using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIScreenLevelSelection : UIScreen
{
    [SerializeField]
    private float circleRadius;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private Vector3 centerPoint;
    [SerializeField]
    private Vector3 axis;

    public GameObject[] BtnsLevel;
    public Button btnLeft;
    public Button btnRight;
    public Button btnClose;
    public Button btnStart;

    public Text txt_LevelName;
    public Text txt_LevelDescription;
    public Text txt_TimeLimit;

    private int currentLevelIndex = 0;

    private IEnumerator StartRotate(float t, bool left)
    {
        int c = Mathf.FloorToInt(t / Time.fixedDeltaTime);
        for (int k = 0; k < c; k++)
        {
            for (int i = 0; i < BtnsLevel.Length; i++)
            {
                BtnsLevel[i].transform.RotateAround(centerPoint, axis, (left ? 120f : -120f) /c);
                BtnsLevel[i].transform.rotation = Quaternion.identity;
            }
            yield return new WaitForFixedUpdate();
        }
    }
    
    protected override void InitComponent()
    {
        btnClose.onClick.AddListener(OnClickCloseButton);
        btnStart.onClick.AddListener(OnClickStartButton);
        btnLeft.onClick.AddListener(() => OnClickLevelSelectionButton(true));
        btnRight.onClick.AddListener(() => OnClickLevelSelectionButton(false));
    }

    protected override void InitData()
    {

    }

    protected override void InitView()
    {
        base.InitView();
    }

    public override void OnClose()
    {
        base.OnClose();
        btnClose.onClick.RemoveAllListeners();
        btnStart.onClick.RemoveAllListeners();
        btnLeft.onClick.RemoveAllListeners();
        btnRight.onClick.RemoveAllListeners();
    }

    private void OnClickLevelSelectionButton(bool left)
    {
        if (left)
        {
            if(currentLevelIndex == 0)
            {
                currentLevelIndex += BtnsLevel.Length;
            }
            currentLevelIndex--;
        }
        else
        {
            currentLevelIndex++;
            currentLevelIndex = currentLevelIndex % BtnsLevel.Length;
        }

        StartCoroutine(StartRotate(0.5f, left));
    }

    private void OnClickStartButton()
    {
        UIManager.Instance.Pop(UIDepthConst.MiddleDepth);
        UIManager.Instance.Pop(UIDepthConst.BottomDepth);
        UIManager.Instance.Push<UIScreenLoading>(UIDepthConst.TopDepth, true);
    }

    private void OnClickCloseButton()
    {
        UIManager.Instance.Pop(UIDepthConst.MiddleDepth);
    }
}
