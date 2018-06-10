using Assets.Scripts.Base;
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
            switch (role)
            {
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
            {
                var skill = new BaseSkill();
                skill.DisplayName = "挥击";
                skill.Name = SkillName.挥击;
                skill.Type = SkillType.None;
                skill.SkillRatio = 40;
                skill.Level = 0;
                skill.Price = 50;
                skill.Cost = 0;
                skill.Description = "造成100%物理伤害";
                skill.DescriptionLevel1 = "额外造成20%物理伤害";
                skill.DescriptionLevel2 = "额外造成20%物理伤害";
                skill.DescriptionLevel3 = "在一局对战中，每释放四次此技能获得一层精湛";
                GameInfo.ActivedSkills.Add(skill);
            }

            {
                var skill = new BaseSkill();
                skill.DisplayName = "重击";
                skill.Name = SkillName.重击;
                skill.Type = SkillType.Fire;
                skill.SkillRatio = 10;
                skill.Level = 0;
                skill.Price = 70;
                skill.Cost = 0;
                skill.Description = "造成100%物理伤害，给与对手一层易伤";
                skill.DescriptionLevel1 = "额外造成20%物理伤害";
                skill.DescriptionLevel2 = "回复2点生命值";
                skill.DescriptionLevel3 = "额外造成30%物理伤害";
                GameInfo.ActivedSkills.Add(skill);
            }

            {
                var skill = new BaseSkill();
                skill.DisplayName = "裂地斩";
                skill.Name = SkillName.裂地斩;
                skill.Type = SkillType.Pure;
                skill.SkillRatio = 40;
                skill.Level = 0;
                skill.Price = 60;
                skill.Cost = 2;
                skill.Description = "造成80%物理伤害，给与对手一层涣散";
                skill.DescriptionLevel1 = "额外造成20%物理伤害";
                skill.DescriptionLevel2 = "给与对手一层脆弱";
                skill.DescriptionLevel3 = "魔法消耗减2";
                GameInfo.ActivedSkills.Add(skill);
            }
            #endregion

            #region 初始化默认技能

            //挥击
            var skill1 = GameInfo.ActivedSkills.FirstOrDefault(x => x.Name == SkillName.挥击);
            SkillUpdater.NewSkill(skill1);
            GameInfo.LearnedSkills.Add(skill1);

            //重击
            var skill2 = GameInfo.ActivedSkills.FirstOrDefault(x => x.Name == SkillName.重击);
            SkillUpdater.NewSkill(skill2);
            GameInfo.LearnedSkills.Add(skill2);

            //裂地斩
            var skill3 = GameInfo.ActivedSkills.FirstOrDefault(x => x.Name == SkillName.裂地斩);
            SkillUpdater.NewSkill(skill3);
            GameInfo.LearnedSkills.Add(skill3);
            #endregion

            return;
        }

        private static void InitElementalMage()
        {
            return;
        }
    }
}
