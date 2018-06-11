using Assets.Scripts.Global;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InitButtonEvents();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitButtonEvents()
    {
        #region 结束回合
        Button btnEndTurn = GameObject.Find("SubCanvasBattling/BtnEndTurn").GetComponent<Button>();
        btnEndTurn.onClick.AddListener(delegate ()
        {
            BattleUpdater.UpdateMessage("战斗胜利！\n获得15经验值,15金币");
            GameInfo.Money += 15;
            Hero.GetExp(15);
            GameInfo.NewStage();
        });
        #endregion
    }
}
