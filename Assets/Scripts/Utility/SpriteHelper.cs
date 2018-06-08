using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static class SpriteHelper
    {
        public static Sprite GetSkillIcon(SkillName name)
        {
            var sprite = Resources.Load("Textures/Skills/" + name, typeof(Sprite)) as Sprite;
            return sprite;
        }
    }
}
