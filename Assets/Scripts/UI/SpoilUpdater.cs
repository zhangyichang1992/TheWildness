using Assets.Scripts.Base;
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
    public static class SpoilUpdater
    {
        /// <summary>
        /// 更改战利品界面UI
        /// </summary>
        /// <param name="money">获得金钱</param>
        /// <param name="exp">获得经验</param>
        /// <param name="prop">获得宝物</param>
        /// <param name="skillType">获得的技能类型</param>
        public static void Refresh(int money, int exp, BaseProp prop, SkillRareDegree skillRareDegree)
        {
            var canvas = GameObject.Find("SubCanvasSpoil").GetComponent<Canvas>();
            var txtExp = canvas.transform.Find("TxtExp").GetComponent<Text>();
            var txtMoney = canvas.transform.Find("TxtMoney").GetComponent<Text>();
            var text = canvas.transform.Find("Text").GetComponent<Text>();
            var btnProp = canvas.transform.Find("BtnProp").GetComponent<Button>();
            var btnUpgrade = canvas.transform.Find("BtnUpgrade").GetComponent<Button>();

            txtExp.text = " X" + exp;
            txtMoney.text = " X" + money;
            if (prop == null)
            {
                btnProp.gameObject.SetActive(false);
            }
            else
            {
                btnProp.gameObject.SetActive(true);
                btnProp.image.sprite = SpriteHelper.GetPropSprite(prop.Name);

                EventTrigger trigger = btnProp.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnProp.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    text.text = prop.Description;
                });
                trigger.triggers.Add(entry);
            }

            if (skillRareDegree == SkillRareDegree.None)
            {
                btnUpgrade.gameObject.SetActive(false);
            }
            else
            {
                btnUpgrade.gameObject.SetActive(true);
                btnUpgrade.image.sprite = SpriteHelper.GetSkillRareDegreeSprite(skillRareDegree);

                EventTrigger trigger = btnUpgrade.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnUpgrade.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    if(skillRareDegree==SkillRareDegree.Normal)
                    {
                        text.text = "选择并获得一本技能书";
                    }
                    else if(skillRareDegree == SkillRareDegree.Rare)
                    {
                        text.text = "选择并获得一本稀有技能书";
                    }

                });
                trigger.triggers.Add(entry);

                btnUpgrade.onClick.RemoveAllListeners();
                btnUpgrade.onClick.AddListener(() =>
                {
                    BattleCanvasSetter.Scenes.Enqueue(BattleSceneType.GetSkill);
                    BattleCanvasSetter.Scenes.Enqueue(BattleSceneType.Spoil);
                    BattleCanvasSetter.SwitchBattleScene();
                });
            }


        }

        public static void RemoveSkill()
        {
            Button btnUpgrade = GameObject.Find("SubCanvasSpoil/BtnUpgrade").GetComponent<Button>();
            btnUpgrade.gameObject.SetActive(false);
        }
    }
}
