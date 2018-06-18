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

        public static Sprite GetEventSprite(Enums.GameEventType type)
        {
            var sprite = Resources.Load("Textures/Events/" + type, typeof(Sprite)) as Sprite;
            return sprite;
        }

        public static Sprite GetRandomEventSprite(Enums.RandomEvent type)
        {
            var sprite = Resources.Load("Textures/RandomEvents/" + type, typeof(Sprite)) as Sprite;
            return sprite;
        }

        public static Sprite GetPropSprite(PropName name)
        {
            var sprite = Resources.Load("Textures/Props/" + name, typeof(Sprite)) as Sprite;
            return sprite;
        }

        public static Sprite GetSkillRareDegreeSprite(SkillRareDegree degree)
        {
            Sprite sprite = null;
            if(degree==SkillRareDegree.Normal)
                sprite = Resources.Load("Textures/Events/普通技能", typeof(Sprite)) as Sprite;
            else if(degree==SkillRareDegree.Rare)
                sprite = Resources.Load("Textures/Events/稀有技能", typeof(Sprite)) as Sprite;
            return sprite;
        }
    }
}
