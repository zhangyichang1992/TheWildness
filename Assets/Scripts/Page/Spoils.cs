using Assets.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spoils : MonoBehaviour {

	// Use this for initialization
	void Start () {
        #region 继续
        Button btnSkip = GameObject.Find("CanvasSkills/BtnSkip").GetComponent<Button>();
        btnSkip.onClick.AddListener(delegate ()
        {
            GameInfo.NewStage();
        });
        #endregion
    }

    // Update is called once per frame
    void Update () {

    }
}
