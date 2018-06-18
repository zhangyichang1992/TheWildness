using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Utility
{
    public static class ButtonHelper
    {
        public static void UpdateSkillButton(Button button, BaseSkill skill, Image imgDesc, bool showStar)
        {

            button.name = skill.DisplayName;
            //button.image.sprite = Resources.Load("Textures/Skills" + skill.DisplayName, typeof(Sprite)) as Sprite;
            button.image.color = ColorHelper.GetSkillFrameColor(skill.Type);

            //修改技能图标
            Image skillIcon = button.transform.Find("Image").GetComponent<Image>();
            skillIcon.sprite = SpriteHelper.GetSkillIcon(skill.Name);

            //修改技能描述
            Text skillDesc = button.transform.Find("TxtDesc").GetComponent<Text>();
            skillDesc.text = SkillHelper.GetSkillDesc(skill);

            //修改技能名称
            Text skillName = button.transform.Find("TxtName").GetComponent<Text>();
            skillName.text = skill.DisplayName;

            //修改技能消耗
            var skillCost = button.transform.Find("TxtCost").GetComponent<Text>();
            skillCost.text = skill.Cost.ToString();
            //如果技能消耗为0修改技能颜色
            if (skill.Cost == 0)
                skillCost.color = ColorHelper.GetCostColor(true);
            else
                skillCost.color = ColorHelper.GetCostColor(false);

            if (showStar)
            {
                //修改星级
                if (skill.Level < 3)
                {
                    var star3 = button.transform.Find("ImgStar3").GetComponent<Image>();
                    star3.gameObject.SetActive(false);
                }
                if (skill.Level < 2)
                {
                    var star2 = button.transform.Find("ImgStar2").GetComponent<Image>();
                    star2.gameObject.SetActive(false);
                }
                if (skill.Level < 1)
                {
                    var star1 = button.transform.Find("ImgStar1").GetComponent<Image>();
                    star1.gameObject.SetActive(false);
                }
            }


            if (skillDesc != null)
            {
                //修改技能升级描述
                EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = button.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                // 鼠标移入事件
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    Text txtStar1 = imgDesc.transform.Find("TxtStar1").GetComponent<Text>();
                    txtStar1.text = skill.DescriptionLevel1;
                    txtStar1.color = Color.black;
                    Text txtStar2 = imgDesc.transform.Find("TxtStar2").GetComponent<Text>();
                    txtStar2.text = skill.DescriptionLevel2;
                    txtStar2.color = Color.black;
                    Text txtStar3 = imgDesc.transform.Find("TxtStar3").GetComponent<Text>();
                    txtStar3.text = skill.DescriptionLevel3;
                    txtStar3.color = Color.black;
                    if (skill.Level > 0)
                    {
                        txtStar1.color = Color.red;
                    }
                    if (skill.Level > 1)
                    {
                        txtStar2.color = Color.red;
                    }
                    if (skill.Level > 2)
                    {
                        txtStar3.color = Color.red;
                    }
                });
                trigger.triggers.Add(entry);
            }
        }
    }
}
