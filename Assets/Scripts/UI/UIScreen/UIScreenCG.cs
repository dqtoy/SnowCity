using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenCG : UIScreen
{
    public CanvasGroup msgPanel;
    public Text msgText;
    private string msg;
    private float destroyDelay;
    private float showDelay;
    private Tweener showTweener;
    private Tweener hideTweener;

    protected override void InitData()
    {
        base.InitData();
        msg = ParseDataByIndex<string>(0);
        showDelay = ParseDataByIndex<float>(1);
        destroyDelay = ParseDataByIndex<float>(2);
    }

    protected override void InitView()
    {
        base.InitView();
        msgText.text = "";
    }

    public override void OnShow()
    {
        base.OnShow();
        showTweener = msgPanel.DOFade(1, showDelay).SetEase(Ease.InOutElastic);
        showTweener.onComplete = () =>
        {
            DOVirtual.DelayedCall(1, () =>
            {
                StartCoroutine(ShowText());
            });
         
        };
    }

    private IEnumerator ShowText()
    {
        StringBuilder sb = new StringBuilder();
        char[] charArray = msg.ToCharArray();
        for (int i = 0, c = charArray.Length; i < c; i++)
        {
            sb.Append(charArray[i]);
            msgText.text = sb.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        DOVirtual.DelayedCall(1, () =>
        {
            OnHide();
        });
    }

    public override void OnHide()
    {
        hideTweener = msgPanel.DOFade(0, destroyDelay).SetEase(Ease.InOutElastic);
        hideTweener.onComplete = () =>
        {
            OnClose();
        };
    }

    private void OnDestroy()
    {
        if (showTweener != null)
        {
            showTweener.Kill();
        }
        if (hideTweener != null)
        {
            hideTweener.Kill();
        }
    }
}
