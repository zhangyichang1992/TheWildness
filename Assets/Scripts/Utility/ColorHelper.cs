using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static class ColorHelper
    {
        public static Color GetU3dColor(float r, float g, float b)
        {
            return new Color(r / 255f, g / 255f, b / 255f);
        }
        public static Color GetU3dColor(float r, float g, float b, float a)
        {
            return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        }
    }
}
