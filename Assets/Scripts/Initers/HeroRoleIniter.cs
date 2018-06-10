using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Initers
{
    public static class HeroRoleIniter
    {
        public static void Init()
        {
            GameInfo.HeroRoleList.Clear();

            var warrior = new BaseHeroRole();
            warrior.BaseHealth = 80;
            warrior.BaseMana = 10;
            warrior.BasePhysicalAttack = 12;
            warrior.BaseMagicAttack = 4;
            warrior.BasePhysicalArmor = 5;
            warrior.BaseMagicArmor = 2;
            warrior.GrowthHealth = 10;
            warrior.GrowthMana = 2;
            warrior.GrowthPhysicalAttack = 7;
            warrior.GrowthMagicAttack = 2;
            warrior.GrowthPhysicalArmor = 3;
            warrior.GrowthMagicArmor = 1;
            warrior.Name = "无畏战神";
            warrior.Role = HeroRole.FearlessWarrior;
            GameInfo.HeroRoleList.Add(warrior);
        }
    }
}
