using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public static class GetSkillUpdater
    {
        public static void Refresh(SkillRareDegree skillRareDegree, int count)
        {
            var canvas = GameObject.Find("SubCanvasGetSkill");
            var btnSkill1 = canvas.transform.Find("BtnSkill1").gameObject.GetComponent<Button>();
            var btnSkill2 = canvas.transform.Find("BtnSkill2").gameObject.GetComponent<Button>();
            var btnSkill3 = canvas.transform.Find("BtnSkill3").gameObject.GetComponent<Button>();
            var imgDesc = canvas.transform.Find("ImgSkillDesc").gameObject.GetComponent<Image>();
            if (count == 1)
            {
                btnSkill1.gameObject.SetActive(false);
                btnSkill3.gameObject.SetActive(false);
            }
            else
            {
                btnSkill1.gameObject.SetActive(true);
                btnSkill3.gameObject.SetActive(true);
            }

            var skill1 = SkillHelper.GetRandomVisibleSkill(skillRareDegree);
            var skill2 = SkillHelper.GetRandomVisibleSkill(skillRareDegree);
            var skill3 = SkillHelper.GetRandomVisibleSkill(skillRareDegree);
            while (skill2.Name == skill1.Name)
            {
                System.Threading.Thread.Sleep(1);
                skill2 = SkillHelper.GetRandomVisibleSkill();
            }
            while (skill3.Name == skill2.Name || skill3.Name == skill1.Name)
            {
                System.Threading.Thread.Sleep(1);
                skill3 = SkillHelper.GetRandomVisibleSkill();
            }

            ButtonHelper.UpdateSkillButton(btnSkill1, skill1, imgDesc, false);
            ButtonHelper.UpdateSkillButton(btnSkill2, skill2, imgDesc, false);
            ButtonHelper.UpdateSkillButton(btnSkill3, skill3, imgDesc, false);

            btnSkill1.onClick.RemoveAllListeners();
            btnSkill1.onClick.AddListener(() =>
            {
                GameInfo.GainSkill(skill1.Name);
                BattleCanvasSetter.SwitchBattleScene();
            });
            btnSkill2.onClick.RemoveAllListeners();
            btnSkill2.onClick.AddListener(() =>
            {
                GameInfo.GainSkill(skill2.Name);
                BattleCanvasSetter.SwitchBattleScene();
            });
            btnSkill3.onClick.RemoveAllListeners();
            btnSkill3.onClick.AddListener(() =>
            {
                GameInfo.GainSkill(skill3.Name);
                BattleCanvasSetter.SwitchBattleScene();
            });
        }
    }
}
