using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public static class EndPageUpdater
    {
        public static void Update(GameEndType type)
        {
            var txtTitle = GameObject.Find("CanvasEnd/TxtTitle").GetComponent<Text>();
            txtTitle.text = GetEndTitle(type);

            int value = 0;

            string desc = "";
            desc += type.ToString() + ": " + GetEndValue(type).ToString();
            value += GetEndValue(type);

            var text = GameObject.Find("CanvasEnd/Text").GetComponent<Text>();
            text.text = desc;
        }

        static string GetEndTitle(GameEndType type)
        {
            var title = "";
            switch (type)
            {
                case GameEndType.死亡:
                    {
                        title = "你精疲力尽的倒在了荒原之城中...";
                        break;
                    }
                case GameEndType.商人女儿:
                    {
                        title = "你与商人女儿结婚后，一同在荒原之城经营生意~";
                        break;
                    }
                case GameEndType.商队:
                    {
                        title = "商队将你带出了荒原之城，开启了新的人生！";
                        break;
                    }
                case GameEndType.巫妖王:
                    {
                        title = "你成为了巫妖王的祭品，但你的灵魂永远驻留在荒原之城...";
                        break;
                    }
                case GameEndType.牛魔王:
                    {
                        title = "牛魔王将你带出了荒原之城，你也成为了世界上最后一个见过牛魔王的人...";
                        break;
                    }
                case GameEndType.神灯:
                    {
                        title = "灯神实现了你的愿望，醒来后你发现你睡在一个村庄的草垛中~";
                        break;
                    }
                case GameEndType.野蛮人部落:
                    {
                        title = "野蛮人把你抓了起来，你成为了他们的奴隶，永世不能翻身...";
                        break;
                    }
                case GameEndType.武馆:
                    {
                        title = "你的战斗技巧响彻整个荒原之城，并成立了荒原武馆培养了无数个勇士！";
                        break;
                    }
                case GameEndType.战胜守卫:
                    {
                        title = "你战胜了荒原守卫，走出荒原后与无数人分享了这段不同寻常的经历！";
                        break;
                    }
                case GameEndType.荒原之主:
                    {
                        title = "你的武力超凡绝伦，成为了新的荒原之主！！！";
                        break;
                    }
            }
            return title;
        }

        static int GetEndValue(GameEndType type)
        {
            int value = 0;
            switch (type)
            {
                case GameEndType.死亡:
                    {
                        value = -30;
                        break;
                    }
                case GameEndType.商人女儿:
                    {
                        value = 80;
                        break;
                    }
                case GameEndType.商队:
                    {
                        value = 50;
                        break;
                    }
                case GameEndType.巫妖王:
                    {
                        value = 50;
                        break;
                    }
                case GameEndType.牛魔王:
                    {
                        value = 80;
                        break;
                    }
                case GameEndType.神灯:
                    {
                        value = 30;
                        break;
                    }
                case GameEndType.野蛮人部落:
                    {
                        value = -10;
                        break;
                    }
                case GameEndType.武馆:
                    {
                        value = 100;
                        break;
                    }
                case GameEndType.战胜守卫:
                    {
                        value = 150;
                        break;
                    }
                case GameEndType.荒原之主:
                    {
                        value = 100;
                        break;
                    }
            }
            return value;
        }
    }
}
