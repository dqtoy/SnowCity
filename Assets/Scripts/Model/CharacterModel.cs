using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : Singleton<CharacterModel>
{
    public Dictionary<int, Dictionary<string, string>> data;

    public CharacterModel()
    {
        data = CharacterData.Instance.data;
    }

    public string GetCharacterName(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["SpeakerName"];
        }
        return res;
    }

    public string GetPortraitPath(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["PortraitPath"];
        }
        return res;
    }

    public List<int> GetCharacterDialogues(int id)
    {
        List<int> res = new List<int>();
        if (data.ContainsKey(id))
        {
            string[] dialogues = data[id]["Dialogue"].Split(',');
            for (int i = 0; i < dialogues.Length; i++)
            {
                res.Add(int.Parse(dialogues[i]));
            }
        }
        return res;
    }
}
