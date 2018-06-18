using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    public static class SkillHelper
    {
        public static BaseSkill GetRandomVisibleSkill()
        {
            var index = NumberHelper.GetRandom(0, GameInfo.ActivedSkills.Count);
            return GameInfo.ActivedSkills[index].Clone();
        }

        public static BaseSkill GetRandomVisibleSkill(SkillRareDegree skillRareDegree)
        {
            var skills = GameInfo.ActivedSkills.Where(x => x.RareDegree == skillRareDegree).ToList();
            var index = NumberHelper.GetRandom(0, skills.Count);
            return skills[index].Clone();
        }

        public static string UpgradeRandomSkill()
        {
            var skills = GameInfo.LearnedSkills.Where(x => x.Level != 3).ToList();
            if (skills.Count == 0)
                return string.Empty;
            var index = NumberHelper.GetRandom(0, skills.Count);
            skills[index].LevelUp();
            return skills[index].DisplayName;
        }

        public static string GetSkillDesc(BaseSkill skill)
        {
            var desc = "";
            if (skill.BaseDamage != 0)
            {
                desc += "基础伤害：" + skill.BaseDamage.ToString() + "\n";
                desc += "技能加成" + "\n";
                desc += skill.SkillRatio + "%" + GetDamageTypeDesc(skill.DamageType) + "\n\n";
            }
            desc += skill.Description;
            return desc;
        }

        public static string GetDamageTypeDesc(DamageType type)
        {
            switch (type) {
                case DamageType.Physical:
                    return "物理伤害";
                case DamageType.Magic:
                    return "魔法伤害";
                case DamageType.Real:
                    return "真实伤害";
            }
            return "伤害";
        }
    }
}
