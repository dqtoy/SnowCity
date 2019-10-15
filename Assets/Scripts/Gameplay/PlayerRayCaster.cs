using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCaster : MonoBehaviour
{
    public Transform raySpawner;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RaycastToSearch(float dist, out NPCController npc, out IOutline oulineObj)
    {
        npc = null;
        oulineObj = null;
        Ray ray = new Ray(raySpawner.position, raySpawner.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dist, 1<<12))
        {
            IOutline _outline = hit.collider.GetComponentInParent<IOutline>();
            if (_outline != null)
            {
                oulineObj = _outline;
            }
            NPCController _npc = hit.collider.GetComponentInChildren<NPCController>();
            if (_npc != null)
            {
                npc = _npc;
            }
        }
    }
}
