using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelSwicthPoint : MonoBehaviour {


    [System.Serializable]
    public struct ArrowData
    {
        public GameObject arrowObj;
        public float duration;
        public Vector3 moveOffset;
        public float rotateSpeed;

        public void StartMove()
        {
            arrowObj.transform.DOLocalMove(moveOffset, duration).SetLoops(-1, LoopType.Yoyo);
            arrowObj.transform.DOLocalRotate(new Vector3(0, 0, 180), rotateSpeed).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
    };

    public ArrowData _arrowData;


    void Start()
    {
        _arrowData.StartMove();
    }


    private void OnTriggerEnter(Collider other)
    {
        ThirdPersonInteraction player = other.GetComponent<ThirdPersonInteraction>();
        if (player != null)
        {
            if (PlayerModel.Instance.CheckDialogueIsPast(80001))
            {
                UIManager.Instance.Push<UIScreenLoading>(UIDepthConst.TopDepth, true);
                SceneManager.LoadSceneAsync("Lake").completed += delegate
                {
                    UIManager.Instance.Pop(UIDepthConst.TopDepth);
                    UIManager.Instance.Push<UIScreenCG>(UIDepthConst.TopDepth, false, "There is a snowman trapped on the ice of the lake, he needs help！", 0f, 2.0f);
                };
            }
            else
            {
                UIManager.Instance.Push<UIMessageInGame>(UIDepthConst.TopDepth, false, "You can't leave now!", 1.5f);
            }
        }
    }
}
