using Assets.Scripts.Buffs;
using Assets.Scripts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Base
{
    public class BaseSkill
    {
        public string DisplayName;
        public SkillName Name;
        public SkillType Type;
        public string Description;
        public string DescriptionLevel1;
        public string DescriptionLevel2;
        public string DescriptionLevel3;
        public SkillRareDegree RareDegree;
        public float BaseDamage;
        public float SkillRatio;
        public DamageType DamageType;
        public int Level;
        public int Cost;
        public int Startup;
        public float Price;
        public Action Use;
        public Action Use1;
        public Action Use2;
        public Action Use3;
        public Action LevelUp;

        public BaseSkill Clone()
        {
            var clone = new BaseSkill();
            clone.DisplayName = DisplayName;
            clone.Name = Name;
            clone.Type = Type;
            clone.Description = Description;
            clone.DescriptionLevel1 = DescriptionLevel1;
            clone.DescriptionLevel2 = DescriptionLevel2;
            clone.DescriptionLevel3 = DescriptionLevel3;
            clone.RareDegree = RareDegree;
            clone.BaseDamage = BaseDamage;
            clone.SkillRatio = SkillRatio;
            clone.DamageType = DamageType;
            clone.Level = Level;
            clone.Startup = Startup;
            clone.Cost = Cost;
            clone.Price = Price;
            clone.Use = Use;
            clone.Use1 = Use1;
            clone.Use2 = Use2;
            clone.Use3 = Use3;
            clone.LevelUp = LevelUp;

            return clone;
        }
    }
}