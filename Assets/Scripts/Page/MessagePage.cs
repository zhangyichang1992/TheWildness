using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MessagePage : MonoBehaviour
{

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


        #region 继续
        Button btnSkip = GameObject.Find("SubCanvasMessage/BtnContinue").GetComponent<Button>();
        btnSkip.onClick.AddListener(delegate ()
        {
            GameInfo.NewStage();
        });
        #endregion

    }
}
