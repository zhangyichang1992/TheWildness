using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardListener : MonoBehaviour
{
    Canvas canvasBattleMain;
    Canvas canvasSettings;
    Canvas canvasProps;
    // Use this for initialization
    void Start()
    {
        canvasBattleMain = GameObject.Find("CanvasBattleMain").GetComponent<Canvas>();
        canvasSettings = GameObject.Find("CanvasSettings").GetComponent<Canvas>();
        canvasProps = GameObject.Find("CanvasProps").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameInfo.CurrentScene == SceneType.ChooseHero)
                ReturnToMenu();
            else if (GameInfo.CurrentScene == SceneType.BattleMain)
                OpenSettings();
            else if (GameInfo.CurrentScene == SceneType.Start)
                ;
            else
                ReturnToGame();
        }
    }

    /// <summary>
    /// 返回主菜单
    /// </summary>
    private void ReturnToMenu()
    {
        GameInfo.CurrentScene = SceneType.Start;
        SceneManager.LoadScene("Start");
    }

    /// <summary>
    /// 开启系统设置窗口
    /// </summary>
    void OpenSettings()
    {
        GameInfo.CurrentScene = SceneType.Settings;
        canvasBattleMain.transform.position = new Vector3(1800, 0, 0);
        canvasSettings.transform.position = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// 返回游戏战斗面板
    /// </summary>
    void ReturnToGame()
    {
       
        canvasBattleMain.transform.position = new Vector3(0, 0, 0);
        switch (GameInfo.CurrentScene)
        {
            case SceneType.Settings:
                {
                    canvasSettings.transform.position = new Vector3(1800, 0, 0);
                    break;
                }
            case SceneType.Props:
                {
                    canvasProps.transform.position = new Vector3(1800, 0, 0);
                    break;
                }
        }

        GameInfo.CurrentScene = SceneType.BattleMain;
    }
}
