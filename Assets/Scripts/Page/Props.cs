using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Props : MonoBehaviour
{
    Canvas canvasBattleMain;
    Canvas canvasProps;
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
        canvasProps = GameObject.Find("CanvasProps").GetComponent<Canvas>();
        #endregion
     
        #region 返回游戏
        Button btnReturnGame = GameObject.Find("CanvasProps/BtnReturnGame").GetComponent<Button>();
        btnReturnGame.onClick.AddListener(delegate ()
        {
            GameInfo.CurrentScene = SceneType.BattleMain;
            canvasBattleMain.transform.position = new Vector3(0, 0, 0);
            canvasProps.transform.position = new Vector3(1800, 0, 0);
        });
        #endregion
    }
}
