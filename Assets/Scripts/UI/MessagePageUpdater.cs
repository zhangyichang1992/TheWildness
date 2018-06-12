using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public static class MessagePageUpdater
    {
        public static void Update(string message)
        {
            Text text = GameObject.Find("SubCanvasMessage/Text").GetComponent<Text>();
            text.text = message;
        }
    }
}
