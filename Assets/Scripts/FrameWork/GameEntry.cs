using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll(); 
        DontDestroyOnLoad(this.gameObject);
        AudioManager.Instance.Init();
        UIManager.Instance.Init();

        //游戏一开始的界面 -- 打开主菜单界面
        UIManager.Instance.Push<UIScreenMainMenu>(UIDepthConst.BottomDepth);
        AudioManager.Instance.PlayMusic(MusicAudio.MainMenuAudio);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
