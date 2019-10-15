using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour {

    public InteractiveLayer layer;
    public Transform focusOn;
    public int ID;

    public void OnInteracted(ThirdPersonController player)
    {
        focusOn = player.transform;
        if (layer == InteractiveLayer.NPC)
        {
            this.transform.parent.localRotation = Quaternion.LookRotation(focusOn.position - transform.position, Vector3.up);
        }

    }
}

public enum InteractiveLayer
{
    NPC,
    Props,
    Other
}