using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardListener : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
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
        CameraSetter.SwichScene(GameInfo.CurrentScene);
    }

    /// <summary>
    /// 返回游戏战斗面板
    /// </summary>
    void ReturnToGame()
    {     
        GameInfo.CurrentScene = SceneType.BattleMain;
        CameraSetter.SwichScene(GameInfo.CurrentScene);
    }
}
