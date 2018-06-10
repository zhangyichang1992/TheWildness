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
    public static class UpgradeSkillUpdater
    {
        static List<Button> buttons = new List<Button>();
        public static void ReFresh()
        {
            Clear();
            var skills = GameInfo.LearnedSkills.Where(x => x.Level != 3).ToList();
            var i = skills.Count;
            RectTransform content = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content").GetComponent<RectTransform>();
            content.sizeDelta = new Vector2(content.sizeDelta.x, (i < 10) ? 480 : 480 + 230 * (i - 5));

            var offsetY = 0;
            if (i > 10)
            {
                offsetY = ((i - 5) / 5) * 135;
            }
            for (var j = 0; j < skills.Count; j++)
            {
                var x = 105 + (j % 5) * 185;
                var y = -125 + offsetY + (j / 5) * 115;
                var skill = skills[j];

                //生成技能面板并设置面板颜色
                Button button = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content/BtnSkill").GetComponent<Button>();
                var newBtn = UnityEngine.Object.Instantiate<Button>(button);
                newBtn.name = skill.DisplayName;
                //newBtn.image.sprite = Resources.Load("Textures/Skills" + skill.DisplayName, typeof(Sprite)) as Sprite;
                newBtn.image.color = ColorHelper.GetSkillFrameColor(skill.Type);
                newBtn.transform.SetParent(GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content").transform, true);
                newBtn.transform.localPosition = new Vector3(x, y, 0);

                //修改技能图标
                Image skillIcon = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content/" + skill.DisplayName + "/ImgSkill").GetComponent<Image>();
                skillIcon.sprite = SpriteHelper.GetSkillIcon(skill.Name);

                //修改技能描述
                Text skillDesc = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content/" + skill.DisplayName + "/TxtDesc").GetComponent<Text>();
                skillDesc.text = skill.Description;

                //修改技能名称
                Text skillName = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content/" + skill.DisplayName + "/TxtName").GetComponent<Text>();
                skillName.text = skill.DisplayName;

                //修改技能消耗
                var skillCost = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content/" + skill.DisplayName + "/TxtCost").GetComponent<Text>();
                skillCost.text = skill.Cost.ToString();
                //如果技能消耗为0修改技能颜色
                if (skill.Cost == 0)
                    skillCost.color = ColorHelper.GetCostColor(true);
                else
                    skillCost.color = ColorHelper.GetCostColor(false);

                //修改星级
                if (skill.Level < 3)
                {
                    GameObject star3 = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content/" + skill.DisplayName + "/ImgStar3");
                    star3.SetActive(false);
                }
                if (skill.Level < 2)
                {
                    GameObject star2 = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content/" + skill.DisplayName + "/ImgStar2");
                    star2.SetActive(false);
                }
                if (skill.Level < 1)
                {
                    GameObject star1 = GameObject.Find("SubCanvasUpgrade/ScrollView/Viewport/Content/" + skill.DisplayName + "/ImgStar1");
                    star1.SetActive(false);
                }


                //修改技能升级描述
                EventTrigger trigger = newBtn.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = newBtn.gameObject.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                // 鼠标移入事件
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    Text txtStar1 = GameObject.Find("SubCanvasUpgrade/ImgSkillDesc/TxtStar1").GetComponent<Text>();
                    txtStar1.text = skill.DescriptionLevel1;
                    txtStar1.color = Color.black;
                    Text txtStar2 = GameObject.Find("SubCanvasUpgrade/ImgSkillDesc/TxtStar2").GetComponent<Text>();
                    txtStar2.text = skill.DescriptionLevel2;
                    txtStar2.color = Color.black;
                    Text txtStar3 = GameObject.Find("SubCanvasUpgrade/ImgSkillDesc/TxtStar3").GetComponent<Text>();
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

                newBtn.onClick.AddListener(() =>
                {
                    GameInfo.GainSkill(skill.Name);
                    GameInfo.NewStage();
                });

                buttons.Add(newBtn);
            }
        }

        static void Clear()
        {
            foreach (var button in buttons)
            {
                UnityEngine.Object.Destroy(button);
            }
            buttons.Clear();
        }
    }
}
