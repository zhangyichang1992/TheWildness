using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Initers
{
    public static class MonsterIniter
    {
        public static void Init()
        {
            {
                var monster = new BaseMonster();
                monster.DisplayName = "野狼";
                monster.Name = MonsterName.野狼;
                monster.Type = MonsterType.Normal;
                monster.MinStage = 0;
                monster.MaxStage = 40;
                monster.Skills = new List<BaseMonsterSkill>();
                monster.PhysicalAttack = 12;
                monster.MagicAttack = 0;
                monster.PhysicalArmor = 4;
                monster.MagicArmor = 3;
            }
        }
    }
}
