﻿using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseHero : MonoBehaviour
{
    Button btnWarrior;
    Button btnMage;
    Button btnDefault;

    // Use this for initialization
    void Start()
    {
        CameraSetter.Init();
        InitButtonEvents();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitButtonEvents()
    {
        Text txtDesc = GameObject.Find("CanvasChooseHero/TextDesc").GetComponent<Text>();
        Text txtName = GameObject.Find("CanvasChooseHero/TextName").GetComponent<Text>();
        btnWarrior = GameObject.Find("CanvasChooseHero/BtnWarrior").GetComponent<Button>();
        btnMage = GameObject.Find("CanvasChooseHero/BtnMage").GetComponent<Button>();
        btnDefault = GameObject.Find("CanvasChooseHero/BtnDefault").GetComponent<Button>();
        GameInfo.Role = HeroRole.FearlessWarrior;
        #region 选择战士      
        btnWarrior.onClick.AddListener(delegate ()
        {
            GameInfo.Role = HeroRole.FearlessWarrior;
            txtDesc.text = "拥有强大的物理伤害能力与爆发能力\n也可以通过转职提升自身的防御能力";
            txtName.text = "无畏战神";
            txtName.color = ColorHelper.GetU3dColor(255, 0, 0);
            ResetBtnColor();
            btnWarrior.image.color = ColorHelper.GetU3dColor(36, 203, 140);
            //btnWarrior.image.color = Color.red;
        });
        #endregion

        #region 选择法师     
        btnMage.onClick.AddListener(delegate ()
        {
            GameInfo.Role = HeroRole.ElementalMage;
            txtDesc.text = "拥有强大的法术伤害能力与控制能力\n也可以通过转职提升自身的持续作战能力";
            txtName.text = "元素法师";
            txtName.color = ColorHelper.GetU3dColor(106, 68, 186);
            ResetBtnColor();
            btnMage.image.color = ColorHelper.GetU3dColor(36, 203, 140);
        });
        #endregion

        #region 选择默认       
        btnDefault.onClick.AddListener(delegate ()
        {
            GameInfo.Role = HeroRole.Default;
            txtDesc.text = "";
            txtName.text = "正在研发中的角色！";
            txtName.color = ColorHelper.GetU3dColor(0, 0, 0);
            ResetBtnColor();
            btnDefault.image.color = ColorHelper.GetU3dColor(36, 203, 140);
        });
        #endregion

        #region 出发
        Button btnConfirm = GameObject.Find("CanvasChooseHero/BtnConfirm").GetComponent<Button>();
        btnConfirm.onClick.AddListener(delegate ()
        {
            if (GameInfo.Role == HeroRole.Default)
                return;

            BattleCanvasSetter.Init();
            GameInfo.CurrentScene = SceneType.BattleMain;
            CameraSetter.SwichScene(GameInfo.CurrentScene);

            //开始一场新的对局
            GameInfo.NewGame();         
        });
        #endregion

        #region 返回菜单
        Button btnReturn = GameObject.Find("CanvasChooseHero/BtnReturn").GetComponent<Button>();
        btnReturn.onClick.AddListener(ReturnToMenu);
        #endregion
    }

    private void ReturnToMenu()
    {
        GameInfo.CurrentScene = SceneType.Start;
        SceneManager.LoadScene("Start");
    }

    private void ResetBtnColor()
    {
        btnWarrior.image.color = ColorHelper.GetU3dColor(255, 255, 255);
        btnMage.image.color = ColorHelper.GetU3dColor(255, 255, 255);
        btnDefault.image.color = ColorHelper.GetU3dColor(255, 255, 255);
    }
}
