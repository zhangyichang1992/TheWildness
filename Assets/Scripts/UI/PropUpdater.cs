using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
namespace Assets.Scripts.UI
{
    public static class PropUpdater
    {
        static List<Button> propBtns=new List<Button>();

        /// <summary>
        /// 获取一个宝物时修改UI
        /// </summary>
        /// <param name="name"></param>
        public static void GainProp(PropName name)
        {
            var i = GameInfo.GainedProps.Count;
            var prop = GameInfo.ActivedProps.FirstOrDefault(p => p.Name == name);
            var x = (i % 12) * 100 - 550;
            var y = 290 - (i / 12) * 100;
            var textures = Resources.LoadAll<Sprite>("Assets/Textures/Props");
            var txtDesc = GameObject.Find("CanvasProps/TextDesc").GetComponent<Text>();

            Button button = GameObject.Find("CanvasProps/Button").GetComponent<Button>();
            var newPropBtn = UnityEngine.Object.Instantiate<Button>(button);
            newPropBtn.image.sprite = Resources.Load("Textures/Props/" + prop.DisplayName, typeof(Sprite)) as Sprite;
            newPropBtn.transform.SetParent(GameObject.Find("CanvasProps").transform, true);
            newPropBtn.transform.localPosition = new Vector3(x, y, 0);
            newPropBtn.onClick.AddListener(() =>
            {
                txtDesc.text = prop.Description;
            });
            propBtns.Add(newPropBtn);
        }

        /// <summary>
        /// 清空宝物列表，用于开启新游戏时调用
        /// </summary>
        public static void Clear()
        {
            foreach (var btn in propBtns)
            {
                UnityEngine.Object.Destroy(btn);
            }

            propBtns.Clear();
        }
    }
}
