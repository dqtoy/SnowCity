using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour {

    public static MissionManager Instance;

    public Transform[] missionTargets;

    private int currentIndex = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        EventDispatcher.Inner.AddEventListener("SwicthTarget", MoveToNext);
    }

    private void OnDestroy()
    {
        EventDispatcher.Inner.RemoveAllListener("SwicthTarget");
    }

    public Transform GetCurrentTarget()
    {
        return missionTargets[currentIndex];
    }

    private void MoveToNext(object[] data)
    {
        currentIndex++;
        currentIndex = Mathf.Clamp(currentIndex, 0, missionTargets.Length - 1);
    }

    public void Move()
    {
        currentIndex++;
        currentIndex = Mathf.Clamp(currentIndex, 0, missionTargets.Length - 1);
    }
}
