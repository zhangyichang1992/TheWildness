using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {
    // Use this for initialization
    void Start () {
        InitButtonEvents();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitButtonEvents()
    {
        #region 返回游戏
        Button btnReturnGame = GameObject.Find("CanvasSkills/BtnReturnGame").GetComponent<Button>();
        btnReturnGame.onClick.AddListener(delegate ()
        {
            GameInfo.CurrentScene = SceneType.BattleMain;
            CameraSetter.SwichScene(GameInfo.CurrentScene);
        });
        #endregion
    }
}
