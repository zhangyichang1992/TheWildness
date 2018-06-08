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
    public class SkillUpdater
    {
        static List<Button> skillBtns = new List<Button>();

        /// <summary>
        /// 学习新技能时修改UI
        /// </summary>
        /// <param name="skill">技能</param>
        public static void NewSkill(BaseSkill skill)
        {
            var i = GameInfo.LearnedSkills.Count;
            //修改滚动面板高度
            RectTransform content = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content").GetComponent<RectTransform>();
            var offsetY = -135;
            if (i % 6 == 0 && i > 11)
            {
                content.sizeDelta = new Vector2(content.sizeDelta.x, Math.Max(540, 270 * ((i / 6) + 1)));
                RelocateButtons();
            }

            var x = (i % 6) * 200 + 100;
            var y = offsetY - (i / 6) * 270;

            //生成技能面板并设置面板颜色
            Button button = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content/BtnSkill").GetComponent<Button>();
            var newBtn = UnityEngine.Object.Instantiate<Button>(button);
            newBtn.name = skill.DisplayName;
            //newBtn.image.sprite = Resources.Load("Textures/Skills" + skill.DisplayName, typeof(Sprite)) as Sprite;
            newBtn.image.color = ColorHelper.GetSkillFrameColor(skill.Type);
            newBtn.transform.SetParent(GameObject.Find("CanvasSkills/ScrollView/Viewport/Content").transform, true);
            newBtn.transform.localPosition = new Vector3(x, y, 0);

            //修改技能图标
            Image skillIcon = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content/" + skill.DisplayName + "/ImgSkill").GetComponent<Image>();
            skillIcon.sprite = SpriteHelper.GetSkillIcon(skill.Name);

            //修改技能描述
            Text skillDesc = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content/" + skill.DisplayName + "/TxtDesc").GetComponent<Text>();
            skillDesc.text = skill.Description;

            //修改技能名称
            Text skillName = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content/" + skill.DisplayName + "/TxtName").GetComponent<Text>();
            skillName.text = skill.DisplayName;

            //修改技能消耗
            Text skillCost = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content/" + skill.DisplayName + "/TxtCost").GetComponent<Text>();
            skillCost.text = skill.Cost.ToString();
            //如果技能消耗为0，则不显示
            if (skill.Cost == 0)
                skillCost.gameObject.SetActive(false);

            //修改星级
            if (skill.Level < 3)
            {
                GameObject star3 = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content/" + skill.DisplayName + "/ImgStar3");
                star3.SetActive(false);
            }
            if (skill.Level < 2)
            {
                GameObject star2 = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content/" + skill.DisplayName + "/ImgStar2");
                star2.SetActive(false);
            }
            if (skill.Level < 1)
            {
                GameObject star1 = GameObject.Find("CanvasSkills/ScrollView/Viewport/Content/" + skill.DisplayName + "/ImgStar1");
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
                Text txtStar1 = GameObject.Find("CanvasSkills/ImgSkillDesc/TxtStar1").GetComponent<Text>();
                txtStar1.text = skill.DescriptionLevel1;
                txtStar1.color = Color.black;
                Text txtStar2 = GameObject.Find("CanvasSkills/ImgSkillDesc/TxtStar2").GetComponent<Text>();
                txtStar2.text = skill.DescriptionLevel2;
                txtStar2.color = Color.black;
                Text txtStar3 = GameObject.Find("CanvasSkills/ImgSkillDesc/TxtStar3").GetComponent<Text>();
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

            skillBtns.Add(newBtn);
        }

        /// <summary>
        /// 升级已有技能时修改UI
        /// </summary>
        /// <param name="name"></param>
        public static void UpgradeSkill(SkillName name)
        {

        }

        private static void RelocateButtons()
        {
            //var offsetY = ((skillBtns.Count / 6) - 2) * 135;
            for (var i = 0; i < skillBtns.Count; i++)
            {
                skillBtns[i].transform.position = new Vector3(skillBtns[i].transform.position.x, skillBtns[i].transform.position.y + 135, skillBtns[i].transform.position.z);
            }
        }

        /// <summary>
        /// 清空宝物列表，用于开启新游戏时调用
        /// </summary>
        public static void Clear()
        {
            foreach (var btn in skillBtns)
            {
                UnityEngine.Object.Destroy(btn);
            }

            skillBtns.Clear();
        }
    }
}
