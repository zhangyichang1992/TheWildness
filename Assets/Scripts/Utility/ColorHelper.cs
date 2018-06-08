using Assets.Scripts.Enums;
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

        public static Color GetFireCardColor()
        {
            return new Color(255f / 255f, 43f / 255f, 43f / 255f, 255f / 255f);
        }
        public static Color GetPureCardColor()
        {
            return new Color(174f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        }

        public static Color GetShadowCardColor()
        {
            return new Color(170f / 255f, 114f / 255f, 170f / 255f, 255f / 255f);
        }

        public static Color GetHolyCardColor()
        {
            return new Color(255f / 255f, 214f / 255f, 0f / 255f, 255f / 255f);
        }

        public static Color GetNoneCardColor()
        {
            return new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        }

        public static Color GetSkillFrameColor(SkillType type)
        {
            switch (type)
            {
                case SkillType.Fire: return GetFireCardColor();
                case SkillType.Pure: return GetPureCardColor();
                case SkillType.Shadow: return GetShadowCardColor();
                case SkillType.Holy: return GetHolyCardColor();
                default: return GetNoneCardColor();
            }
        }
    }
}
