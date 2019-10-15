using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outline = QuickOutline.Outline;

public class NPCController : MonoBehaviour, IOutline {

    public CharacterName characterName;

    private List<Outline> _outlines;

    private void Start()
    {
        InitOutline();
    }

    public void InitOutline()
    {
        _outlines = new List<Outline>();
        MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0, c = meshes.Length; i < c; i++)
        {
            var outline = meshes[i].gameObject.AddComponent<Outline>();
            outline.OutlineColor = GameSettings.OUTLINE_COLOR;
            outline.OutlineWidth = GameSettings.OUTLINE_WIDTH;
            _outlines.Add(outline);
        }
        DisableOutlineColor();
    }

    public void EnableOutlineColor()
    {
        for (int i = 0, c = _outlines.Count; i < c; i++)
        {
            _outlines[i].enabled = true;
        }
    }

    public void DisableOutlineColor()
    {
        for (int i = 0, c = _outlines.Count; i < c; i++)
        {
            _outlines[i].enabled = false;
        }
    }

    public string GetName()
    {
        if (this != null)
            return this.name;
        return null;
    }

    public int GetInteractableID()
    {
        return (int)characterName;
    }

    public Transform GetTransform()
    {
        if (this != null)
            return this.transform;
        return null;
    }
}

public enum CharacterName
{
    SnowmanJack = 10001,
    Book = 10002,
    SnowmanHanabi = 10003,
    Aki = 10004,
    SnowmanMike = 10005,
    SnowmanCaspar = 10006,
    SnowmanJim = 10007,
    StoneTablet = 10010,
    Note = 10011
}
