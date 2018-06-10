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
    }
}
