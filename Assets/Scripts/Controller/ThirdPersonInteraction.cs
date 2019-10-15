using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonInteraction : MonoBehaviour {

    public float maxSearchDis = 5.0f;

    public PlayerRayCaster m_pRaycaster;
    private IOutline previousOutlineObj;
    private Camera m_camera;
    public GameObject NoteBook;
    public GameObject StoneTablet;

    private void Start()
    {
        m_camera = Camera.main;
        EventDispatcher.Inner.AddEventListener("NoteActive", OnNoteActive);
        EventDispatcher.Inner.AddEventListener("StoneTabletActive", OnStoneTabletActive);
    }

    private void OnDestroy()
    {
        EventDispatcher.Inner.RemoveAllListener("NoteActive");
        EventDispatcher.Inner.RemoveAllListener("StoneTabletActive");
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "NewMenu")
        {
            float disToTarget = Vector3.Distance(transform.position, MissionManager.Instance.GetCurrentTarget().position);
            EventDispatcher.Outer.DispatchEvent("UpdateMission", disToTarget);
        }

        //搜索交互物体
        NPCController npc;
        IOutline outlineObj;
        m_pRaycaster.RaycastToSearch(3f, out npc, out outlineObj);
        if (previousOutlineObj != null && previousOutlineObj.GetTransform() != null && previousOutlineObj != outlineObj)
        {
            previousOutlineObj.DisableOutlineColor();
        }

        if (outlineObj != null)
        {      
            previousOutlineObj = outlineObj;
            outlineObj.EnableOutlineColor();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (npc != null)
            {
                List<int> dialogues = CharacterModel.Instance.GetCharacterDialogues(npc.GetInteractableID());
                int nextDialogue = 0;
                for (int i = 0; i < dialogues.Count; i++)
                {
                    if (PlayerModel.Instance.CheckDialogueIsPast(dialogues[i]))
                    {
                        continue;
                    }
                    int conditionID = DialogueModel.Instance.GetConditionID(dialogues[i]);
                    if (conditionID == 0)
                    {
                        nextDialogue = dialogues[i];
                        break;
                    }
                    else
                    {
                        if (PlayerModel.Instance.CheckDialogueIsPast(conditionID))
                        {
                            nextDialogue = dialogues[i];
                            break;
                        }
                    }                    
                }
                if(nextDialogue != 0)
                {
                    UIManager.Instance.Push<UIScreenDialogue>(UIDepthConst.MiddleDepth, false, nextDialogue);
                    PlayerModel.Instance.SaveDialogueData(nextDialogue);
                }
                else
                {
                    //Can't talk
                    UIManager.Instance.Push<UIMessageInGame>(UIDepthConst.TopDepth, false, "Nothinig to Talk...", 1.5f);
                }

            }
        }
    }

    public InteractableObj SearchInteractableObj()
    {
        Ray ray = m_camera.ScreenPointToRay(new Vector2(Screen.width, Screen.height)/2);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxSearchDis))
        {
            InteractableObj obj = hit.collider.GetComponentInChildren<InteractableObj>();
            if(obj != null)
            {
                return obj;
            }
        }
        return null;
    }

    private void OnNoteActive(object[] data)
    {
        MissionManager.Instance.Move();
    }

    public void OnStoneTabletActive(object[] data)
    {
        MissionManager.Instance.Move();
    }
}
