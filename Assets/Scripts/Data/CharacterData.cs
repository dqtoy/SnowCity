using System.Collections.Generic;

//ID : 编号(int)
//SpeakerName : 角色名(string)
//PortraitPath : 头像路径(string)
//Dialogue : 对话(string)

public class CharacterData : Singleton<CharacterData>
{
    public Dictionary<int, Dictionary<string, string>> data = new Dictionary<int, Dictionary<string, string>>()
    {
        {10001, new Dictionary<string, string>(){ {"SpeakerName", "Snowman Jack"}, {"PortraitPath", "PortraitPath/Snowman Jack"}, {"Dialogue", "10001,40001"}, } },
        {10002, new Dictionary<string, string>(){ {"SpeakerName", "Book"}, {"PortraitPath", "PortraitPath/Book"}, {"Dialogue", "20001"}, } },
        {10003, new Dictionary<string, string>(){ {"SpeakerName", "Snowman Hanabi"}, {"PortraitPath", "PortraitPath/Snowman Hanabi"}, {"Dialogue", "30001"}, } },
        {10004, new Dictionary<string, string>(){ {"SpeakerName", "Aki"}, {"PortraitPath", "PortraitPath/Aki"}, {"Dialogue", ""}, } },
        {10005, new Dictionary<string, string>(){ {"SpeakerName", "Snowman Mike"}, {"PortraitPath", "PortraitPath/Snowman Mike"}, {"Dialogue", "50001"}, } },
        {10006, new Dictionary<string, string>(){ {"SpeakerName", "Snowman Caspar"}, {"PortraitPath", "PortraitPath/Snowman Caspar"}, {"Dialogue", "60001"}, } },
        {10007, new Dictionary<string, string>(){ {"SpeakerName", "Snowman Jim"}, {"PortraitPath", "PortraitPath/Snowman Jim"}, {"Dialogue", "90001,90002"}, } },
        {10010, new Dictionary<string, string>(){ {"SpeakerName", "Stone Tablet"}, {"PortraitPath", "PortraitPath/Stone Tablet"}, {"Dialogue", "90004"}, } },
        {10011, new Dictionary<string, string>(){ {"SpeakerName", "Note"}, {"PortraitPath", "PortraitPath/Stone Tablet"}, {"Dialogue", "80001"}, } },
    };

}
