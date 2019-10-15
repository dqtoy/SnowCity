using System.Collections.Generic;

//ID : 编号(int)
//ConditionID : 条件ID()
//SpeakerID : 说话者ID()
//ActionCost : 行动点花费()
//Content : 对话内容()
//Branch : 分支()
//Event : 触发事件()

public class DialogueData : Singleton<DialogueData>
{
    public Dictionary<int, Dictionary<string, string>> data = new Dictionary<int, Dictionary<string, string>>()
    {
        {10001, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", "1"}, {"Content", "You finally awake! "}, {"Branch", "10002,10003"}, {"Event", ""}, } },
        {10002, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Where am I?"}, {"Branch", "10004"}, {"Event", ""}, } },
        {10003, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Who are you?"}, {"Branch", "10011"}, {"Event", ""}, } },
        {10004, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "Here is the City of Snow, a place created by a sorrow God."}, {"Branch", "10005"}, {"Event", ""}, } },
        {10005, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "What?"}, {"Branch", "10006"}, {"Event", ""}, } },
        {10006, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "Well, it's a long story."}, {"Branch", "10007"}, {"Event", ""}, } },
        {10007, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "Anyway, I'm Snowman Jack. Nice to meet you."}, {"Branch", "10008"}, {"Event", ""}, } },
        {10008, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Ok, Jack. So tell me how can I get out of this place. I have to get back to where I were."}, {"Branch", "10009"}, {"Event", ""}, } },
        {10009, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "The snow crush blocks the exit. "}, {"Branch", "10010"}, {"Event", ""}, } },
        {10010, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "Always Remember! 'Never Give Up!' is the maxim of the God who created this world. There has to be a way! Oh, perhaps go check the library, you might find some clues there."}, {"Branch", ""}, {"Event", "SwicthTarget"}, } },
        {10011, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "As what you see, I'm a snowman! "}, {"Branch", "10012"}, {"Event", ""}, } },
        {10012, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Well, fine. It must be a dream."}, {"Branch", "10007"}, {"Event", ""}, } },
        {20001, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10002"}, {"ActionCost", "1"}, {"Content", "Contend of Book: "}, {"Branch", ""}, {"Event", "GotStoneTabletOne"}, } },
        {30001, new Dictionary<string, string>(){ {"ConditionID", "20001"}, {"SpeakerID", "10003"}, {"ActionCost", "1"}, {"Content", "^A hu#man? &*%$^@"}, {"Branch", "30002"}, {"Event", ""}, } },
        {30002, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "What? Pardon me?"}, {"Branch", "30003"}, {"Event", ""}, } },
        {30003, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10003"}, {"ActionCost", ""}, {"Content", "I@#AK32i, N3ic@e!tom(^eet!Yo#$@"}, {"Branch", "30004"}, {"Event", ""}, } },
        {30004, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "I shall go back to the wooden house."}, {"Branch", ""}, {"Event", "SwicthTarget"}, } },
        {40001, new Dictionary<string, string>(){ {"ConditionID", "30001"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "Did you find anything useful?"}, {"Branch", "40002"}, {"Event", ""}, } },
        {40002, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Emm, I guess no. The only stuff I found interesting in the book is something called 'Frozen Heart'."}, {"Branch", "40003"}, {"Event", ""}, } },
        {40003, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "But the language in the book is unknown to me, so I did not fully understand the content."}, {"Branch", "40004"}, {"Event", ""}, } },
        {40004, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "What? You said 'Frozen Heart?' That's the relic left by the God in this world. But no one has ever seen it."}, {"Branch", "40005"}, {"Event", ""}, } },
        {40005, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "It will be OK. We will figure out a way. Hey, right now how about going around the town? The people, I mean sonwmen, are all friendly and nice here. I bet you can have a good conversation with them."}, {"Branch", "40006"}, {"Event", ""}, } },
        {40006, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Sure"}, {"Branch", "40007"}, {"Event", ""}, } },
        {40007, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10001"}, {"ActionCost", ""}, {"Content", "For these days, you are sure welcome to use this room.But remember, you have to be back to this room before the sun falls. Storm will come every night and freeze you immediately."}, {"Branch", "40008"}, {"Event", ""}, } },
        {40008, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Got that. Thanks for the tips."}, {"Branch", ""}, {"Event", "NoteActive"}, } },
        {50001, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10005"}, {"ActionCost", "1"}, {"Content", "#@#$!@#^@$^*%"}, {"Branch", ""}, {"Event", ""}, } },
        {60001, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10006"}, {"ActionCost", "1"}, {"Content", "D@$@!GRHSR&%"}, {"Branch", ""}, {"Event", ""}, } },
        {80001, new Dictionary<string, string>(){ {"ConditionID", "40001"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "There is a note on the table…..."}, {"Branch", "80002"}, {"Event", "FoundLake"}, } },
        {80002, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Lake?"}, {"Branch", ""}, {"Event", "SwicthTarget"}, } },
        {90001, new Dictionary<string, string>(){ {"ConditionID", "80001"}, {"SpeakerID", "10007"}, {"ActionCost", ""}, {"Content", "Th！@a32nk you s1o mu@31ch!!!! Please re23weive t2his"}, {"Branch", ""}, {"Event", "GotStoneTabletTwo"}, } },
        {90002, new Dictionary<string, string>(){ {"ConditionID", "90001"}, {"SpeakerID", "10004"}, {"ActionCost", ""}, {"Content", "Where I…find…this?--Frozen heart?"}, {"Branch", "90003"}, {"Event", ""}, } },
        {90003, new Dictionary<string, string>(){ {"ConditionID", "0"}, {"SpeakerID", "10007"}, {"ActionCost", ""}, {"Content", "It…Church"}, {"Branch", ""}, {"Event", "StoneTabletActive"}, } },
        {90004, new Dictionary<string, string>(){ {"ConditionID", "90002"}, {"SpeakerID", "10010"}, {"ActionCost", ""}, {"Content", "There are some words in the stone tablet…"}, {"Branch", ""}, {"Event", "GameOver"}, } },
    };

}
