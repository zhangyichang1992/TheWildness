using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Battle
{
    public static class UseSkill
    {
        /// <summary>
        /// 英雄释放有目标类技能
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="skill"></param>
        public static void HeroUse(BaseMonster monster, BaseSkill skill)
        {
        }

        /// <summary>
        /// 英雄释放无目标类技能
        /// </summary>
        /// <param name="skill"></param>
        public static void HeroUse(BaseSkill skill)
        {
        }

        /// <summary>
        /// 怪物释放有目标类技能
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="skill"></param>
        public static void MonsterUse(BaseMonster monster, BaseSkill skill)
        {
        }

        /// <summary>
        /// 怪物释放无目标类技能
        /// </summary>
        /// <param name="skill"></param>
        public static void MonsterUse(BaseSkill skill)
        {
        }
    }
}
