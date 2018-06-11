using Assets.Scripts.Base;
using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public static class DialogUpdater
    {
        public static void Refresh(BaseEvent e)
        {
            #region 继续
            Button btnContinue = GameObject.Find("SubCanvasDialog/BtnContinue").GetComponent<Button>();
            btnContinue.onClick.RemoveAllListeners();
            btnContinue.onClick.AddListener(delegate ()
            {
                GameInfo.NewStage();
            });
            #endregion
            var canvas = GameObject.Find("SubCanvasDialog").GetComponent<Canvas>();
            var btnOption1 = canvas.transform.Find("BtnOption1").GetComponent<Button>();
            var btnOption2 = canvas.transform.Find("BtnOption2").GetComponent<Button>();
            var btnOption3 = canvas.transform.Find("BtnOption3").GetComponent<Button>();
            var txtOption1 = canvas.transform.Find("BtnOption1/Text").GetComponent<Text>();
            var txtOption2 = canvas.transform.Find("BtnOption2/Text").GetComponent<Text>();
            var txtOption3 = canvas.transform.Find("BtnOption3/Text").GetComponent<Text>();
            var txtTitle = GameObject.Find("SubCanvasDialog/TxtTitle").GetComponent<Text>();
            var txtDesc = GameObject.Find("SubCanvasDialog/TxtDesc").GetComponent<Text>();
            var txtChooseDesc = GameObject.Find("SubCanvasDialog/TxtChooseDesc").GetComponent<Text>();
            var imgEvent= GameObject.Find("SubCanvasDialog/ImgEvent").GetComponent<Image>();

            txtTitle.text = e.Title;
            txtDesc.text = e.Description;
            txtChooseDesc.text = "";
            txtOption1.text = e.Choose1Name;
            txtOption2.text = e.Choose2Name;
            txtOption3.text = e.Choose3Name;
            imgEvent.sprite = e.Sprite;

            if (e.Choose1 == null)
            {
                btnOption1.gameObject.SetActive(false);
            }
            else
            {
                btnOption1.gameObject.SetActive(true);
                btnOption1.onClick.RemoveAllListeners();
                btnOption1.onClick.AddListener(e.Choose1);
                EventTrigger trigger = btnOption1.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnOption1.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    txtChooseDesc.text = e.Choose1Desc;
                });
                trigger.triggers.Add(entry);
            }

            if (e.Choose2 == null)
            {
                btnOption2.gameObject.SetActive(false);
            }
            else
            {
                btnOption2.gameObject.SetActive(true);
                btnOption2.onClick.RemoveAllListeners();
                btnOption2.onClick.AddListener(e.Choose2);
                EventTrigger trigger = btnOption2.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnOption2.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    txtChooseDesc.text = e.Choose2Desc;
                });
                trigger.triggers.Add(entry);
            }

            if (e.Choose3 == null)
            {
                btnOption3.gameObject.SetActive(false);
            }
            else
            {
                btnOption3.gameObject.SetActive(true);
                btnOption3.onClick.RemoveAllListeners();
                btnOption3.onClick.AddListener(e.Choose3);
                EventTrigger trigger = btnOption3.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnOption3.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    txtChooseDesc.text = e.Choose3Desc;
                });
                trigger.triggers.Add(entry);
            }
        }
    }
}
