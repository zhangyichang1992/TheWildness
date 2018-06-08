using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    Canvas canvasBattleMain;
    Canvas canvasSettings;
    // Use this for initialization
    void Start()
    {
        InitButtonEvents();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void InitButtonEvents()
    {
        #region canvas
        canvasBattleMain = GameObject.Find("CanvasBattleMain").GetComponent<Canvas>();
        canvasSettings = GameObject.Find("CanvasSettings").GetComponent<Canvas>();
        #endregion

        #region 返回游戏
        Button btnReturnGame = GameObject.Find("CanvasSettings/BtnReturnGame").GetComponent<Button>();
        btnReturnGame.onClick.AddListener(delegate ()
        {
            ReturnToGame();
        });
        #endregion

        #region 返回主菜单
        Button btnReturn = GameObject.Find("CanvasSettings/BtnReturn").GetComponent<Button>();
        btnReturn.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("Start");
        });
        #endregion

        #region 退出游戏
        Button btnExit = GameObject.Find("CanvasSettings/BtnExit").GetComponent<Button>();
        btnExit.onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
        #endregion
    }

    void ReturnToGame()
    {
        GameInfo.CurrentScene = SceneType.BattleMain;
        CameraSetter.SwichScene(GameInfo.CurrentScene);
    }
}
