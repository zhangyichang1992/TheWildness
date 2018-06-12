using Assets.Scripts.Base;
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
            return GameInfo.ActivedSkills[index];
        }

        public static string UpgradeRandomSkill()
        {
            var skills = GameInfo.LearnedSkills.Where(x => x.Level != 3).ToList();
            if (skills.Count == 0)
                return string.Empty;
            var index = NumberHelper.GetRandom(0, skills.Count);
            skills[index].Level++;
            return skills[index].DisplayName;
        }

    }
}
