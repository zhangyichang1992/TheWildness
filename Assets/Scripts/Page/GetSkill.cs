using Assets.Scripts.Global;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSkill : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btnSkip = GameObject.Find("SubCanvasGetSkill/BtnSkip").GetComponent<Button>();
        btnSkip.onClick.AddListener(delegate ()
        {
            SpoilUpdater.RemoveSkill();
            BattleCanvasSetter.SwitchBattleScene();
        });
    }

    // Update is called once per frame
    void Update () {
		
	}
}
