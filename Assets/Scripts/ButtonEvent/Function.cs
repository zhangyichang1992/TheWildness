using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Function : MonoBehaviour
{
    Canvas canvasBattleMain;
    Canvas canvasSettings;
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
        canvasSettings = GameObject.Find("CanvasSettings").GetComponent<Canvas>();
        canvasProps = GameObject.Find("CanvasProps").GetComponent<Canvas>();
        #endregion

        #region 设置      
        var btnSettings = GameObject.Find("CanvasBattleMain/BtnSettings").GetComponent<Button>();
        btnSettings.onClick.AddListener(delegate ()
        {
            GameInfo.CurrentScene = SceneType.Settings;
            canvasBattleMain.transform.position = new Vector3(1800, 0, 0);
            canvasSettings.transform.position = new Vector3(0, 0, 0);
        });
        #endregion

        #region 背包   
        var btnBag = GameObject.Find("CanvasBattleMain/BtnBag").GetComponent<Button>();
        btnBag.onClick.AddListener(delegate ()
        {
            GameInfo.CurrentScene = SceneType.Props;
            canvasBattleMain.transform.position = new Vector3(1800, 0, 0);
            canvasProps.transform.position = new Vector3(0, 0, 0);
        });
        #endregion
    }


}
