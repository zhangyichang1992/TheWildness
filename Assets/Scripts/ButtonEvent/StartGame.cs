using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InitButtonEvents();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitButtonEvents()
    {
        #region 开始游戏
        Button btnStart = GameObject.Find("CanvasProps/BtnStart").GetComponent<Button>();        
        btnStart.onClick.AddListener(delegate () {
            SceneManager.LoadScene("TheWildness");
        });
        #endregion

        #region 退出游戏
        Button btnExit = GameObject.Find("CanvasProps/BtnExit").GetComponent<Button>();
        btnExit.onClick.AddListener(delegate () {
            Application.Quit();
        });
        #endregion
    }
}
