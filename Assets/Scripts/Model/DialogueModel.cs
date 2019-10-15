using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueModel : Singleton<DialogueModel>
{
    public Dictionary<int, Dictionary<string, string>> data;
    public DialogueModel()
    {
        data = DialogueData.Instance.data;
    }

    public int GetConditionID(int id)
    {
        int res = 0;
        if (data.ContainsKey(id))
        {
            res = int.Parse(data[id]["ConditionID"]);
        }
        return res;
    }

    public string GetSpeakerName(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            int characterID = int.Parse(data[id]["SpeakerID"]);
            res = CharacterModel.Instance.GetCharacterName(characterID);
        }
        return res;
    }

    public string GetSpeakerPortraitPath(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            int characterID = int.Parse(data[id]["SpeakerID"]);
            res = CharacterModel.Instance.GetPortraitPath(characterID);
        }
        return res;
    }

    public string GetContent(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["Content"];
        }
        return res;
    }

    public int GetActionCost(int id)
    {
        int res = 0;
        if (data.ContainsKey(id))
        {
            res = int.Parse(data[id]["ActionCost"]);
        }
        return res;
    }

    public int GetSocialChange(int id)
    {
        int res = 0;
        if (data.ContainsKey(id))
        {
            res = int.Parse(data[id]["SocialChange"]);
        }
        return res;
    }

    public bool IsLast(int id)
    {
        return string.IsNullOrEmpty(GetBranchContent(id));
    }

    public bool HasBranch(int id)
    {
        string[] branches = GetBranchContent(id).Split(',');
        return branches.Length > 1;
    }

    public List<int> GetBranch(int id)
    {
        List<int> res = new List<int>();
        string[] branches = GetBranchContent(id).Split(',');
        for (int i = 0; i < branches.Length; i++)
        {
            res.Add(int.Parse(branches[i]));
        }
        return res;
    }

    public string GetLastWord(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["LastWord"];
        }
        return res;
    }

    public string GetEventName(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["Event"];
        }
        return res;
    }

    private string GetBranchContent(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["Branch"];
        }
        return res;
    }
}
