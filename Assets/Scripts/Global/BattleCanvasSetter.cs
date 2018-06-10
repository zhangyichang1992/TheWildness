using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public static class BattleCanvasSetter
    {
        static GameObject Battling;
        static GameObject ChooseEvent;
        static GameObject Shop;
        static GameObject Upgrade;

        public static void Init()
        {
            Battling = GameObject.Find("SubCanvasBattling");
            ChooseEvent = GameObject.Find("SubCanvasChooseEvent");
            Shop = GameObject.Find("SubCanvasShop");
            Upgrade = GameObject.Find("SubCanvasUpgrade");
        }

        public static void SwitchBattleScene(BattleSceneType type)
        {
            Battling.transform.position = new Vector3(1800, 1800, 0);
            ChooseEvent.transform.position = new Vector3(1800, 1800, 0);
            Shop.transform.position = new Vector3(1800, 1800, 0);
            Upgrade.transform.position = new Vector3(1800, 1800, 0);
            switch (type)
            {
                case BattleSceneType.Battling:
                    {
                        Battling.transform.position = new Vector3(1800, 0, 0);
                        break;
                    }
                case BattleSceneType.ChooseEvent:
                    {
                        ChooseEvent.transform.position = new Vector3(1800, 0, 0);
                        break;
                    }
                case BattleSceneType.Shop:
                    {
                        Shop.transform.position = new Vector3(1800, 0, 0);
                        break;
                    }
                case BattleSceneType.UpgradeSkill:
                    {
                        Upgrade.transform.position = new Vector3(1800, 0, 0);
                        break;
                    }
            }
        }
    }
}
