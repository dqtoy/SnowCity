using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScreenDialogue : UIScreen {

    [System.Serializable]
    public class OptionButton
    {
        public CanvasGroup cg;
        public Button btn;
        public Text txt;
    }

    [Header("Components")]
    [Space]
    public Text txt_SpeakerName;
    public Text txt_dialogueContent;
    public Image img_SpeakerPortrait;
    public OptionButton[] optionsBtns;
    public Button continueBtn;
    public GameObject continueNotice;

    private string currentDialogueContent;
    private int currentDialogueID;

    protected override void InitData()
    {
        base.InitData();
        currentDialogueID = ParseDataByIndex<int>(0);
    }

    protected override void InitView()
    {
        base.InitView();
        for (int i = 0; i < optionsBtns.Length; i++)
        {
            optionsBtns[i].cg.alpha = 0;
            optionsBtns[i].cg.interactable = false;
        }
        continueBtn.gameObject.SetActive(false);
        continueNotice.gameObject.SetActive(false);
    }

    public override void OnClose()
    {
        base.OnClose();
        for (int i = 0; i < optionsBtns.Length; i++)
        {
            optionsBtns[i].btn.onClick.RemoveAllListeners();
        }
        continueBtn.onClick.RemoveAllListeners();
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    public override void OnShow()
    {
        base.OnShow();
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        string content = DialogueModel.Instance.GetContent(currentDialogueID);
        string speakerName = DialogueModel.Instance.GetSpeakerName(currentDialogueID);
        string portraitPath = DialogueModel.Instance.GetSpeakerPortraitPath(currentDialogueID);
        txt_SpeakerName.text = speakerName;
        img_SpeakerPortrait.sprite = ResourceLoader.Instance.Load<Sprite>(portraitPath);
        StartCoroutine(ShowDialogueProgress(content));
    }

    private IEnumerator ShowDialogueProgress(string content)
    {
        print(content);
        StringBuilder sb = new StringBuilder();
        char[] charArray = content.ToCharArray();
        for (int i = 0, c = charArray.Length; i < c; i++)
        {
            sb.Append(charArray[i]);
            txt_dialogueContent.text = sb.ToString();
            yield return new WaitForSeconds(0.02f);
        }

        bool isLast = DialogueModel.Instance.IsLast(currentDialogueID);
        if (isLast)
        {
            continueBtn.gameObject.SetActive(true);
            continueBtn.onClick.AddListener(() => OnContinueButtonClicked(true));
            yield break;
        }


        //对话字幕显示完毕后显示选项按钮
        bool hasBranch = DialogueModel.Instance.HasBranch(currentDialogueID);
        if (hasBranch)
        {
            List<int> data = DialogueModel.Instance.GetBranch(currentDialogueID);
            for (int i = 0; i < data.Count; i++)
            {
                int tmp = i;
                optionsBtns[i].txt.text = DialogueModel.Instance.GetContent(data[i]);
                optionsBtns[i].cg.DOFade(1, 0.5f).onComplete = () =>
                {
                    optionsBtns[tmp].btn.onClick.AddListener(() => OnOptionButtonClicked(data[tmp]));
                    optionsBtns[tmp].cg.interactable = true;
                };
            }
        }
        else
        {
            continueBtn.onClick.AddListener(() => OnContinueButtonClicked(false));
            continueBtn.gameObject.SetActive(true);
            continueNotice.gameObject.SetActive(false);
        }
    }


    private void OnOptionButtonClicked(int nextID)
    {
        UIManager.Instance.Pop(UIDepthConst.MiddleDepth);
        UIManager.Instance.Push<UIScreenDialogue>(UIDepthConst.MiddleDepth, false, nextID);
    }

    private void OnContinueButtonClicked(bool isLast)
    {
        string eventName = DialogueModel.Instance.GetEventName(currentDialogueID);
        if (!string.IsNullOrEmpty(eventName))
        {
            EventDispatcher.Inner.DispatchEvent(eventName);
        }

        if (isLast)
        {
            UIManager.Instance.Pop(UIDepthConst.MiddleDepth);
        }
        else
        {
            UIManager.Instance.Pop(UIDepthConst.MiddleDepth);
            UIManager.Instance.Push<UIScreenDialogue>(UIDepthConst.MiddleDepth, false, DialogueModel.Instance.GetBranch(currentDialogueID)[0]);
        }
    }

    

}
