using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Base
{
    public class BaseMonsterSkill
    {
        public string DisplayName;
        public MonsterSkillName Name;
        public string Description;
        public DamageType DamageType;
        public float SkillRatio;
        public Action Use;
    }
}
