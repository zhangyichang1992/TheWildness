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
                skill.RareDegree = SkillRareDegree.Normal;
                skill.DamageType = DamageType.Physical;
                skill.BaseDamage = 5;
                skill.SkillRatio = 20;
                skill.Level = 0;
                skill.Price = 50;
                skill.Cost = 0;
                skill.Startup = 4;
                skill.Description = "";
                skill.DescriptionLevel1 = "基础伤害 + 3";
                skill.DescriptionLevel2 = "技能加成提升20%";
                skill.DescriptionLevel3 = "在一局对战中，每释放四次此技能获得一层精湛";
                skill.LevelUp = () =>
                {
                    skill.Level++;
                    if (skill.Level == 1)
                        skill.BaseDamage += 3;
                    else if (skill.Level == 2)
                        skill.SkillRatio += 20;
                };
                GameInfo.ActivedSkills.Add(skill);
            }

            {
                var skill = new BaseSkill();
                skill.DisplayName = "重击";
                skill.Name = SkillName.重击;
                skill.Type = SkillType.Fire;
                skill.RareDegree = SkillRareDegree.Normal;
                skill.DamageType = DamageType.Physical;
                skill.BaseDamage = 8;
                skill.SkillRatio = 40;
                skill.Level = 0;
                skill.Price = 70;
                skill.Cost = 0;
                skill.Startup = 2;
                skill.Description = "给与对手一层易伤";
                skill.DescriptionLevel1 = "基础伤害 + 5";
                skill.DescriptionLevel2 = "技能加成提升40%";
                skill.DescriptionLevel3 = "回复8点生命值";
                skill.LevelUp = () =>
                {
                    skill.Level++;
                    if (skill.Level == 1)
                        skill.BaseDamage += 5;
                    else if (skill.Level == 2)
                        skill.SkillRatio += 40;
                };
                GameInfo.ActivedSkills.Add(skill);
            }

            {
                var skill = new BaseSkill();
                skill.DisplayName = "裂地斩";
                skill.Name = SkillName.裂地斩;
                skill.Type = SkillType.Pure;
                skill.RareDegree = SkillRareDegree.Normal;
                skill.DamageType = DamageType.Magic;
                skill.BaseDamage = 6;
                skill.SkillRatio = 50;
                skill.Level = 0;
                skill.Price = 60;
                skill.Cost = 2;
                skill.Startup = 2;
                skill.Description = "给与对手一层寒冷";
                skill.DescriptionLevel1 = "技能消耗 - 2";
                skill.DescriptionLevel2 = "技能加成提升50%";
                skill.DescriptionLevel3 = "给与对手一层涣散";
                skill.LevelUp = () =>
                {
                    skill.Level++;
                    if (skill.Level == 1)
                        skill.Cost -= 2;
                    else if (skill.Level == 2)
                        skill.SkillRatio += 50;
                };
                GameInfo.ActivedSkills.Add(skill);
            }

            {
                var skill = new BaseSkill();
                skill.DisplayName = "神圣之力";
                skill.Name = SkillName.神圣之力;
                skill.Type = SkillType.Holy;
                skill.RareDegree = SkillRareDegree.Rare;
                skill.DamageType = DamageType.None;
                skill.BaseDamage = 0;
                skill.SkillRatio = 0;
                skill.Level = 0;
                skill.Price = 160;
                skill.Cost = 8;
                skill.Startup = 1;
                skill.Description = "获得一层不死";
                skill.DescriptionLevel1 = "技能消耗 - 3";
                skill.DescriptionLevel2 = "回复最大生命值的15%";
                skill.DescriptionLevel3 = "发动系数提升 1";
                skill.LevelUp = () =>
                {
                    skill.Level++;
                    if (skill.Level == 1)
                        skill.Cost -= 3;
                    else if (skill.Level == 3)
                        skill.Startup += 1;
                };
                GameInfo.ActivedSkills.Add(skill);
            }

            {
                var skill = new BaseSkill();
                skill.DisplayName = "寒冰之心";
                skill.Name = SkillName.寒冰之心;
                skill.Type = SkillType.Pure;
                skill.RareDegree = SkillRareDegree.Rare;
                skill.DamageType = DamageType.None;
                skill.BaseDamage = 0;
                skill.SkillRatio = 0;
                skill.Level = 0;
                skill.Price = 160;
                skill.Cost = 4;
                skill.Startup = 1;
                skill.Description = "获得一层护盾";
                skill.DescriptionLevel1 = "启动一个技能";
                skill.DescriptionLevel2 = "获得一层启迪，获得一层石肤";
                skill.DescriptionLevel3 = "发动系数提升 1";
                skill.LevelUp = () =>
                {
                    skill.Level++;
                    if (skill.Level == 3)
                        skill.Startup += 1;
                };
                GameInfo.ActivedSkills.Add(skill);
            }


            {
                var skill = new BaseSkill();
                skill.DisplayName = "灵界打击";
                skill.Name = SkillName.灵界打击;
                skill.Type = SkillType.Shadow;
                skill.RareDegree = SkillRareDegree.Rare;
                skill.DamageType = DamageType.Magic;
                skill.BaseDamage = 18;
                skill.SkillRatio = 120;
                skill.Level = 0;
                skill.Price = 160;
                skill.Cost = 4;
                skill.Startup = 1;
                skill.Description = "回复10点生命值";
                skill.DescriptionLevel1 = "技能加成提升120%";
                skill.DescriptionLevel2 = "给与对手一层萎靡";
                skill.DescriptionLevel3 = "发动系数提升 1";
                skill.LevelUp = () =>
                {
                    skill.Level++;
                    if (skill.Level == 1)
                        skill.SkillRatio += 120;
                    else if (skill.Level == 3)
                        skill.Startup += 1;
                };
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
