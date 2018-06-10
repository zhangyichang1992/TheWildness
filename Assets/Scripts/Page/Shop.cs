using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour
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


        #region 跳过
        Button btnSkip = GameObject.Find("SubCanvasShop/BtnSkip").GetComponent<Button>();
        btnSkip.onClick.AddListener(delegate ()
        {
            GameInfo.NewStage();
        });
        #endregion

        #region 升级技能
        var canvas = GameObject.Find("SubCanvasShop");
        var btnUpgrade= GameObject.Find("SubCanvasShop/BtnUpgrade").GetComponent<Button>();
        EventTrigger trigger = btnUpgrade.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = btnUpgrade.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener((eventdata) =>
        {
            canvas.transform.Find("TxtDesc").gameObject.SetActive(true);
            canvas.transform.Find("ImgSkillDesc").gameObject.SetActive(false);
            GameObject.Find("SubCanvasShop/TxtDesc").GetComponent<Text>().text = "升级一个技能";
        });
        trigger.triggers.Add(entry);

        canvas.transform.Find("TxtDesc").gameObject.SetActive(false);
        canvas.transform.Find("ImgSkillDesc").gameObject.SetActive(false);
        #endregion
    }
}
