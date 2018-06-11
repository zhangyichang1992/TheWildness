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
    public static class ShopUpdater
    {
        /// <summary>
        /// 刷新商店
        /// </summary>
        public static void Refresh()
        {
            var btnProp = GameObject.Find("SubCanvasShop/BtnProp").GetComponent<Button>();
            //var btnUpgrade = GameObject.Find("SubCanvasShop/BtnUpgrade").GetComponent<Button>();
            var btnSkill1 = GameObject.Find("SubCanvasShop/BtnSkill1").GetComponent<Button>();
            var btnSkill2 = GameObject.Find("SubCanvasShop/BtnSkill2").GetComponent<Button>();
            var btnSkill3 = GameObject.Find("SubCanvasShop/BtnSkill3").GetComponent<Button>();

            var imgSkill1 = GameObject.Find("SubCanvasShop/BtnSkill1/Image").GetComponent<Image>();
            var imgSkill2 = GameObject.Find("SubCanvasShop/BtnSkill2/Image").GetComponent<Image>();
            var imgSkill3 = GameObject.Find("SubCanvasShop/BtnSkill3/Image").GetComponent<Image>();

            var txtNameSkill1 = GameObject.Find("SubCanvasShop/BtnSkill1/TxtName").GetComponent<Text>();
            var txtNameSkill2 = GameObject.Find("SubCanvasShop/BtnSkill2/TxtName").GetComponent<Text>();
            var txtNameSkill3 = GameObject.Find("SubCanvasShop/BtnSkill3/TxtName").GetComponent<Text>();

            var txtDescSkill1 = GameObject.Find("SubCanvasShop/BtnSkill1/TxtDes").GetComponent<Text>();
            var txtDescSkill2 = GameObject.Find("SubCanvasShop/BtnSkill2/TxtDes").GetComponent<Text>();
            var txtDescSkill3 = GameObject.Find("SubCanvasShop/BtnSkill3/TxtDes").GetComponent<Text>();

            var txtCostSkill1 = GameObject.Find("SubCanvasShop/BtnSkill1/TxtCost").GetComponent<Text>();
            var txtCostSkill2 = GameObject.Find("SubCanvasShop/BtnSkill2/TxtCost").GetComponent<Text>();
            var txtCostSkill3 = GameObject.Find("SubCanvasShop/BtnSkill3/TxtCost").GetComponent<Text>();

            var txtPrice1 = GameObject.Find("SubCanvasShop/BtnPrice1/TxtPrice").GetComponent<Text>();
            var txtPrice2 = GameObject.Find("SubCanvasShop/BtnPrice2/TxtPrice").GetComponent<Text>();
            var txtPrice3 = GameObject.Find("SubCanvasShop/BtnPrice3/TxtPrice").GetComponent<Text>();
            var txtPrice4 = GameObject.Find("SubCanvasShop/BtnPrice4/TxtPrice").GetComponent<Text>();
            var txtPrice5 = GameObject.Find("SubCanvasShop/BtnPrice5/TxtPrice").GetComponent<Text>();

            var btnPrice1 = GameObject.Find("SubCanvasShop/BtnPrice1").GetComponent<Button>();
            var btnPrice2 = GameObject.Find("SubCanvasShop/BtnPrice2").GetComponent<Button>();
            var btnPrice3 = GameObject.Find("SubCanvasShop/BtnPrice3").GetComponent<Button>();
            var btnPrice4 = GameObject.Find("SubCanvasShop/BtnPrice4").GetComponent<Button>();
            var btnPrice5 = GameObject.Find("SubCanvasShop/BtnPrice5").GetComponent<Button>();

            var canvas = GameObject.Find("SubCanvasShop");

            var ratio = Convert.ToSingle(100 + NumberHelper.GetRandom(-10, 11)) / 100f;

            #region 隐藏两个信息面板
            canvas.transform.Find("TxtDesc").gameObject.SetActive(false);
            canvas.transform.Find("ImgSkillDesc").gameObject.SetActive(false);
            #endregion

            #region 刷新宝物
            //随机刷新一个未获得的普通宝物
            {
                var randomProp = PropHelper.GetRandomVisibleProp(PropType.Normal);
                txtPrice1.text = Math.Round((randomProp.Price * ratio)).ToString();
                btnProp.image.sprite = SpriteHelper.GetPropSprite(randomProp.Name);
                EventTrigger trigger = btnProp.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnProp.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    canvas.transform.Find("TxtDesc").gameObject.SetActive(true);
                    canvas.transform.Find("ImgSkillDesc").gameObject.SetActive(false);
                    GameObject.Find("SubCanvasShop/TxtDesc").GetComponent<Text>().text = randomProp.Description;
                });
                trigger.triggers.Add(entry);
                if (GameInfo.Money < randomProp.Price)
                {
                    btnPrice1.interactable = false;
                }
                else
                {
                    btnPrice1.interactable = true;
                    //绑定宝物购买事件
                    btnPrice1.onClick.RemoveAllListeners();
                    btnPrice1.onClick.AddListener(() =>
                    {
                        GameInfo.Money -= Convert.ToInt32(Math.Round((randomProp.Price * ratio)));
                        GameInfo.GainProp(randomProp.Name);
                        BattleUpdater.UpdateStageInfo();
                        BattleUpdater.UpdateMessage("获得宝物：" + randomProp.DisplayName);
                        GameInfo.NewStage();
                    });
                }
            }
            #endregion

            #region 升级技能
            if (GameInfo.Money < 100)
            {
                btnPrice2.interactable = false;
            }
            else
            {
                btnPrice2.interactable = true;
                btnPrice2.onClick.RemoveAllListeners();
                btnPrice2.onClick.AddListener(() =>
                {
                    GameInfo.Money -= 100;
                    BattleUpdater.UpdateStageInfo();
                    UpgradeSkillUpdater.ReFresh();
                    BattleCanvasSetter.SwitchBattleScene(BattleSceneType.UpgradeSkill);
                });
            }
            #endregion

            #region 刷新技能

            //生成三个不同的技能
            var skill1 = SkillHelper.GetRandomVisibleSkill();
            var skill2 = SkillHelper.GetRandomVisibleSkill();
            var skill3 = SkillHelper.GetRandomVisibleSkill();
            while (skill2.Name == skill1.Name)
            {
                System.Threading.Thread.Sleep(10);
                skill2 = SkillHelper.GetRandomVisibleSkill();
            }
            while (skill3.Name == skill2.Name || skill3.Name == skill1.Name)
            {
                System.Threading.Thread.Sleep(10);
                skill3 = SkillHelper.GetRandomVisibleSkill();
            }

            {
                var price1 = Math.Round(skill1.Price * ratio);
                btnSkill1.image.color = ColorHelper.GetSkillFrameColor(skill1.Type);
                imgSkill1.sprite = SpriteHelper.GetSkillIcon(skill1.Name);
                txtDescSkill1.text = skill1.Description;
                txtNameSkill1.text = skill1.DisplayName;
                txtCostSkill1.text = skill1.Cost.ToString();
                //如果技能消耗为0
                if (skill1.Cost == 0)
                    txtCostSkill1.color = ColorHelper.GetCostColor(true);
                else
                    txtCostSkill1.color = ColorHelper.GetCostColor(false);

                EventTrigger trigger = btnSkill1.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnSkill1.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    canvas.transform.Find("TxtDesc").gameObject.SetActive(false);
                    canvas.transform.Find("ImgSkillDesc").gameObject.SetActive(true);
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar1").GetComponent<Text>().text = skill1.DescriptionLevel1;
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar2").GetComponent<Text>().text = skill1.DescriptionLevel2;
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar3").GetComponent<Text>().text = skill1.DescriptionLevel3;
                });
                trigger.triggers.Add(entry);

                txtPrice3.text = price1.ToString();
                if (GameInfo.Money < price1)
                {
                    btnPrice3.interactable = false;
                }
                else
                {
                    btnPrice3.interactable = true;
                    btnPrice3.onClick.RemoveAllListeners();
                    btnPrice3.onClick.AddListener(() =>
                    {
                        GameInfo.Money -= Convert.ToInt32(price1);
                        BattleUpdater.UpdateStageInfo();
                        GameInfo.GainSkill(skill1.Name);
                        
                        GameInfo.NewStage();
                    });
                }
            }

            {
                var price2 = Math.Round(skill2.Price * ratio);
                btnSkill2.image.color = ColorHelper.GetSkillFrameColor(skill2.Type);
                imgSkill2.sprite = SpriteHelper.GetSkillIcon(skill2.Name);
                txtDescSkill2.text = skill2.Description;
                txtNameSkill2.text = skill2.DisplayName;
                txtCostSkill2.text = skill2.Cost.ToString();
                //如果技能消耗为0
                if (skill2.Cost == 0)
                    txtCostSkill2.color = ColorHelper.GetCostColor(true);
                else
                    txtCostSkill2.color = ColorHelper.GetCostColor(false);

                EventTrigger trigger = btnSkill2.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnSkill2.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    canvas.transform.Find("TxtDesc").gameObject.SetActive(false);
                    canvas.transform.Find("ImgSkillDesc").gameObject.SetActive(true);
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar1").GetComponent<Text>().text = skill2.DescriptionLevel1;
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar2").GetComponent<Text>().text = skill2.DescriptionLevel2;
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar3").GetComponent<Text>().text = skill2.DescriptionLevel3;
                });
                trigger.triggers.Add(entry);

                txtPrice4.text =price2.ToString();
                if (GameInfo.Money < price2)
                {
                    btnPrice4.interactable = false;
                }
                else
                {
                    btnPrice4.interactable = true;
                    btnPrice4.onClick.RemoveAllListeners();
                    btnPrice4.onClick.AddListener(() =>
                    {
                        GameInfo.Money -= Convert.ToInt32(price2);
                        BattleUpdater.UpdateStageInfo();
                        GameInfo.GainSkill(skill2.Name);
                        GameInfo.NewStage();
                    });
                }
            }

            {
                var price3 = Math.Round(skill3.Price * ratio);
                btnSkill3.image.color = ColorHelper.GetSkillFrameColor(skill3.Type);
                imgSkill3.sprite = SpriteHelper.GetSkillIcon(skill3.Name);
                txtDescSkill3.text = skill3.Description;
                txtNameSkill3.text = skill3.DisplayName;
                txtCostSkill3.text = skill3.Cost.ToString();
                //如果技能消耗为0
                if (skill3.Cost == 0)
                    txtCostSkill3.color = ColorHelper.GetCostColor(true);
                else
                    txtCostSkill3.color = ColorHelper.GetCostColor(false);

                EventTrigger trigger = btnSkill3.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btnSkill3.gameObject.AddComponent<EventTrigger>();
                trigger.triggers.Clear();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback = new EventTrigger.TriggerEvent();
                entry.callback.AddListener((eventdata) =>
                {
                    canvas.transform.Find("TxtDesc").gameObject.SetActive(false);
                    canvas.transform.Find("ImgSkillDesc").gameObject.SetActive(true);
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar1").GetComponent<Text>().text = skill3.DescriptionLevel1;
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar2").GetComponent<Text>().text = skill3.DescriptionLevel2;
                    GameObject.Find("SubCanvasShop/ImgSkillDesc/TxtStar3").GetComponent<Text>().text = skill3.DescriptionLevel3;
                });
                trigger.triggers.Add(entry);

                txtPrice5.text =price3.ToString();
                if (GameInfo.Money < price3)
                {
                    btnPrice5.interactable = false;
                }
                else
                {
                    btnPrice5.interactable = true;
                    btnPrice5.onClick.RemoveAllListeners();
                    btnPrice5.onClick.AddListener(() =>
                    {
                        GameInfo.Money -= Convert.ToInt32(price3);
                        BattleUpdater.UpdateStageInfo();
                        GameInfo.GainSkill(skill3.Name);
                        GameInfo.NewStage();
                    });
                }
            }
            #endregion
        }
    }
}
