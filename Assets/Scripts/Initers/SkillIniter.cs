using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Initers
{
    public static class SkillIniter
    {
        /// <summary>
        /// 按职业初始化技能列表
        /// </summary>
        /// <param name="role"></param>
        public static void Init(HeroRole role)
        {
            switch (role){
                case HeroRole.FearlessWarrior:
                    {
                        InitFearlessWarrior();
                        break;
                    }
                case HeroRole.ElementalMage:
                    {
                        InitElementalMage();
                        break;
                    }
            }
        }

        private static void InitFearlessWarrior()
        {
            GameInfo.ActivedSkills.Clear();
            GameInfo.LearnedSkills.Clear();

            #region 初始化本局对战中可能获得的技能
            var skill = new BaseSkill();
            skill.DisplayName = "挥击";
            skill.Name = SkillName.挥击;
            skill.Type = SkillType.None;
            skill.SkillRatio = 40;
            skill.Level = 0;
            skill.Description = "造成100%物理伤害";
            skill.DescriptionLevel1 = "额外造成20%物理伤害";
            skill.DescriptionLevel2 = "额外造成20%物理伤害";
            skill.DescriptionLevel3 = "在一局对战中，每释放四次此技能获得一层精湛";            
            GameInfo.ActivedSkills.Add(skill);
            #endregion

            #region 初始化默认技能
            for (var i = 0; i < 20; i++)
            {
                //挥击
                var defaultSkill = GameInfo.ActivedSkills.FirstOrDefault(x => x.Name == SkillName.挥击);               
                var thisSkill = defaultSkill.Clone();
                thisSkill.DisplayName += i.ToString();
                thisSkill.DescriptionLevel1 += i.ToString();
                thisSkill.Level = i % 4;
                
                SkillUpdater.NewSkill(thisSkill);
                GameInfo.LearnedSkills.Add(thisSkill);
            }
            #endregion

            return;
        }

        private static void InitElementalMage()
        {
            return;
        }
    }
}
