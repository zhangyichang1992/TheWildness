using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Function : MonoBehaviour
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

        var btnSettings = GameObject.Find("CanvasBattleMain/BtnSettings").GetComponent<Button>();
        #region 设置      
        btnSettings.onClick.AddListener(delegate ()
        {
            canvasBattleMain.transform.position = new Vector3(1800, 0, 0);
            canvasSettings.transform.position = new Vector3(0, 0, 0);
        });
        #endregion
    }
}
