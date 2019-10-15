using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIScreenMainMenu : UIScreen
{
    public Button btn_LevelSelection;
    public Button btn_Options;
    public Button btn_Credits;
    public Button btn_Quit;

    protected override void InitComponent()
    {
        btn_LevelSelection.onClick.AddListener(OnLevelSelectionButtonClicked);
        btn_Options.onClick.AddListener(OnOptionsButtonClicked);
        btn_Credits.onClick.AddListener(OnCreditsButtonClicked);
        btn_Quit.onClick.AddListener(OnQuitButtonClicked);
    }

    public override void OnShow()
    {
        base.OnShow();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnLevelSelectionButtonClicked()
    {
        UIManager.Instance.Pop(UIDepthConst.BottomDepth);
        UIManager.Instance.Push<UIScreenLoading>(UIDepthConst.TopDepth, true);
        SceneManager.LoadSceneAsync("InGame").completed += delegate
        {
            UIManager.Instance.Pop(UIDepthConst.TopDepth);
            UIManager.Instance.Push<UIScreenHUD>(UIDepthConst.MiddleDepth);
            UIManager.Instance.Push<UIScreenCG>(UIDepthConst.TopDepth, false, "Aki woke up in a warm hut. There is a snowman around, he seems to be watching Aki.", 0f,2.0f);
        };
    }

    private void OnOptionsButtonClicked()
    {
        UIManager.Instance.Push<UIScreenOptions>(UIDepthConst.MiddleDepth, true);
    }

    private void OnCreditsButtonClicked()
    {
        UIManager.Instance.Push<UIScreenCredits>(UIDepthConst.MiddleDepth, false);
    }

    private void OnQuitButtonClicked()
    {
        UIManager.Instance.Push<UIScreenQuitConfirm>(UIDepthConst.TopDepth, false);
    }
}
