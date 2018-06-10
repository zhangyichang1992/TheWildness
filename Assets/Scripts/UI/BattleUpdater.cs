using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public static class BattleUpdater
    {
        public static void UpdateStageInfo()
        {
            Text text = GameObject.Find("CanvasBattleMain/ImgLevel/Text").GetComponent<Text>();
            text.text = "等级" + Hero.Level.ToString() + " 第" + GameInfo.Day.ToString() + "天";

            Text txtMoney = GameObject.Find("CanvasBattleMain/ImgLevel/TxtMoney").GetComponent<Text>();
            txtMoney.text = GameInfo.Money.ToString();
        }

        public static void UpdateEvent(Enums.GameEventType t1, Enums.GameEventType t2, Enums.GameEventType t3)
        {
            Button btnEvent1 = GameObject.Find("SubCanvasChooseEvent/BtnEvent1").GetComponent<Button>();
            Button btnEvent2 = GameObject.Find("SubCanvasChooseEvent/BtnEvent2").GetComponent<Button>();
            Button btnEvent3 = GameObject.Find("SubCanvasChooseEvent/BtnEvent3").GetComponent<Button>();
            Text text = GameObject.Find("SubCanvasChooseEvent/TxtDesc").GetComponent<Text>();

            btnEvent1.image.sprite = SpriteHelper.GetEventSprite(t1);
            btnEvent2.image.sprite = SpriteHelper.GetEventSprite(t2);
            btnEvent3.image.sprite = SpriteHelper.GetEventSprite(t3);

            btnEvent1.image.color = ColorHelper.GetEventColor(t1);
            btnEvent2.image.color = ColorHelper.GetEventColor(t2);
            btnEvent3.image.color = ColorHelper.GetEventColor(t3);

            EventTrigger trigger = btnEvent1.gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
                trigger = btnEvent1.gameObject.AddComponent<EventTrigger>();
            trigger.triggers.Clear();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener((eventdata) =>
            {
                var e = GameInfo.EventList.FirstOrDefault(x => x.Type == t1);
                text.text = e.Description;
            });
            trigger.triggers.Add(entry);
            btnEvent1.onClick.RemoveAllListeners();
            btnEvent1.onClick.AddListener(() =>
            {
                ChooseEvent(t1);
            });

            EventTrigger trigger2 = btnEvent2.gameObject.GetComponent<EventTrigger>();
            if (trigger2 == null)
                trigger2 = btnEvent2.gameObject.AddComponent<EventTrigger>();
            trigger2.triggers.Clear();
            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerEnter;
            entry2.callback = new EventTrigger.TriggerEvent();
            entry2.callback.AddListener((eventdata) =>
            {
                var e = GameInfo.EventList.FirstOrDefault(x => x.Type == t2);
                text.text = e.Description;
            });
            trigger2.triggers.Add(entry2);
            btnEvent2.onClick.RemoveAllListeners();
            btnEvent2.onClick.AddListener(() =>
            {
                ChooseEvent(t2);
            });

            EventTrigger trigger3 = btnEvent3.gameObject.GetComponent<EventTrigger>();
            if (trigger3 == null)
                trigger3 = btnEvent3.gameObject.AddComponent<EventTrigger>();
            trigger3.triggers.Clear();
            EventTrigger.Entry entry3 = new EventTrigger.Entry();
            entry3.eventID = EventTriggerType.PointerEnter;
            entry3.callback = new EventTrigger.TriggerEvent();
            entry3.callback.AddListener((eventdata) =>
            {
                var e = GameInfo.EventList.FirstOrDefault(x => x.Type == t3);
                text.text = e.Description;
            });
            trigger3.triggers.Add(entry3);
            btnEvent3.onClick.RemoveAllListeners();
            btnEvent3.onClick.AddListener(() =>
            {
                ChooseEvent(t3);
            });
        }

        public static void UpdateMessage(string message)
        {
            Text text = GameObject.Find("CanvasBattleMain/ImgCombo/Text").GetComponent<Text>();
            text.text = message;
        }

        private static void ChooseEvent(GameEventType type)
        {
            //GameInfo.NewStage();
            //return;
            switch (type)
            {
                case GameEventType.Shop:
                    {
                        GameInfo.CurrentBattleScene = BattleSceneType.Shop;
                        ShopUpdater.Refresh();
                        BattleCanvasSetter.SwitchBattleScene(BattleSceneType.Shop);
                        break;
                    }
                case GameEventType.Treasure:
                    {
                        GameInfo.CurrentBattleScene = BattleSceneType.Reward;
                        BattleCanvasSetter.SwitchBattleScene(BattleSceneType.Reward);
                        break;
                    }
                //case GameEventType.
                default:
                    {
                        GameInfo.CurrentBattleScene = BattleSceneType.Battling;
                        BattleCanvasSetter.SwitchBattleScene(BattleSceneType.Battling);
                        break;
                    }
            }          
        }

    }
}
