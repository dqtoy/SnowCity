using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScreenPause : UIScreen
{
    public Button btnContinue;
    public Button btnQuit;


    protected override void InitComponent()
    {
        btnContinue.onClick.AddListener(OnContinueBtnClicked);
        btnQuit.onClick.AddListener(OnQuitBtnClicked);
    }

    public override void OnHide()
    {
        base.OnHide();
        Time.timeScale = 1;
    }

    public override void OnShow()
    {
        base.OnShow();
        Time.timeScale = 0;
    }

    private void OnQuitBtnClicked()
    {
        UIManager.Instance.Push<UIScreenLoading>(UIDepthConst.TopDepth);
        SceneManager.LoadSceneAsync("NewMenu").completed += delegate
        {
            UIManager.Instance.PopToBottom();
        };
    }

    private void OnContinueBtnClicked()
    {
        UIManager.Instance.Pop(UIDepthConst.TopDepth);
    }
}
