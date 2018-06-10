using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public static  class PropertyPanelUpdater
    {
        public static void Update()
        {
            var txtPhysicalAttack= GameObject.Find("CanvasBattleMain/ImgProperty/TxtPhysicalAttack").GetComponent<Text>();
            var txtMagicAttack = GameObject.Find("CanvasBattleMain/ImgProperty/TxtMagicAttack").GetComponent<Text>();
            var txtPhysicalArmor = GameObject.Find("CanvasBattleMain/ImgProperty/TxtPhysicalArmor").GetComponent<Text>();
            var txtMagicArmor = GameObject.Find("CanvasBattleMain/ImgProperty/TxtMagicArmor").GetComponent<Text>();
            var txtHolyPower = GameObject.Find("CanvasBattleMain/ImgProperty/TxtHolyPower").GetComponent<Text>();
            var txtFirePower = GameObject.Find("CanvasBattleMain/ImgProperty/TxtFirePower").GetComponent<Text>();
            var txtShadowPower = GameObject.Find("CanvasBattleMain/ImgProperty/TxtShadowPower").GetComponent<Text>();
            var txtPurePower = GameObject.Find("CanvasBattleMain/ImgProperty/TxtPurePower").GetComponent<Text>();
            var txtHeroMaxHP = GameObject.Find("CanvasBattleMain/TxtHeroMaxHP").GetComponent<Text>();
            var txtHeroMaxMana = GameObject.Find("CanvasBattleMain/TxtHeroMaxMana").GetComponent<Text>();
            var txtHeroHP = GameObject.Find("CanvasBattleMain/TxtHeroHP").GetComponent<Text>();
            var txtHeroMana= GameObject.Find("CanvasBattleMain/TxtHeroMana").GetComponent<Text>();
            var txtHeroEXP = GameObject.Find("CanvasBattleMain/TxtHeroEXP").GetComponent<Text>();
            var txtHeroMaxEXP = GameObject.Find("CanvasBattleMain/TxtHeroMaxEXP").GetComponent<Text>();
           
            var sliderHeroHP = GameObject.Find("CanvasBattleMain/SliderHeroHP").GetComponent<Slider>();
            var sliderHeroMana = GameObject.Find("CanvasBattleMain/SliderHeroMana").GetComponent<Slider>();
            var sliderHeroEXP = GameObject.Find("CanvasBattleMain/SliderHeroEXP").GetComponent<Slider>();

            txtPhysicalAttack.text = Hero.PhysicalAttack.ToString();
            txtMagicAttack.text = Hero.MagicAttack.ToString();
            txtPhysicalArmor.text = Hero.PhysicalArmor.ToString();
            txtMagicArmor.text = Hero.MagicArmor.ToString();
            txtShadowPower.text = Hero.ShadowPower.ToString();
            txtHolyPower.text = Hero.HolyPower.ToString();
            txtFirePower.text = Hero.FirePower.ToString();
            txtPurePower.text = Hero.PurePower.ToString();
            txtHeroMaxHP.text = Hero.MaxHealth.ToString();
            txtHeroMaxMana.text = Hero.MaxMana.ToString();
            txtHeroHP.text = Hero.Health.ToString();
            txtHeroMana.text = Hero.Mana.ToString();
            txtHeroEXP.text = Hero.Exp.ToString();
            txtHeroMaxEXP.text = Hero.MaxExp.ToString();

            sliderHeroHP.value = Hero.Health / Hero.MaxHealth;
            sliderHeroMana.value = Hero.Mana / Hero.MaxMana;
            sliderHeroEXP.value = Hero.Exp / Hero.MaxExp;
        }
    }
}
