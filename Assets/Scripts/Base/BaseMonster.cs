using Assets.Scripts.Buffs;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Base
{
    public class BaseMonster
    {
        public string DisplayName;
        public MonsterName Name;
        public int MinStage;
        public int MaxStage;
        public MonsterType Type;
        public List<BaseMonsterSkill> Skills;
        public List<Buff> Buffs;
        public List<Debuff> Debuffs;

        #region 战斗属性
        /// <summary>
        /// 血量
        /// </summary>
        public float Health;
        /// <summary>
        /// 最大生命值
        /// </summary>
        public float MaxHealth;
        /// <summary>
        /// 物理攻击
        /// </summary>
        public float PhysicalAttack;
        /// <summary>
        /// 魔法攻击
        /// </summary>
        public float MagicAttack;
        /// <summary>
        /// 物理防御
        /// </summary>
        public float PhysicalArmor;
        /// <summary>
        /// 魔法防御
        /// </summary>
        public float MagicArmor;
        #endregion

        public BaseMonster Clone()
        {
            var monster = new BaseMonster();
            monster.DisplayName = DisplayName;
            monster.Name = Name;
            monster.MinStage = MinStage;
            monster.MaxStage = MaxStage;
            monster.Type = Type;
            monster.Skills = Skills;
            monster.Buffs = Buffs;
            monster.Debuffs = Debuffs;
            monster.Health = Health;
            monster.MaxHealth = MaxHealth;
            monster.PhysicalAttack = PhysicalAttack;
            monster.MagicAttack = MagicAttack;
            monster.PhysicalArmor = PhysicalArmor;
            monster.MagicArmor = MagicArmor;

            return monster;
        }


    }
}
