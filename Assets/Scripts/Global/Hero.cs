using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Global
{
    /// <summary>
    /// 英雄属性
    /// </summary>
    public static class Hero
    {
        public static HeroRole Role;

        #region 战斗属性
        /// <summary>
        /// 血量
        /// </summary>
        public static float Health;
        /// <summary>
        /// 魔法
        /// </summary>
        public static float Mana;
        /// <summary>
        /// 经验值
        /// </summary>
        public static float Exp;
        /// <summary>
        /// 等级
        /// </summary>
        public static int Level;
        #endregion

        #region 基础属性
        /// <summary>
        /// 物理攻击
        /// </summary>
        public static float PhysicalAttack;
        /// <summary>
        /// 魔法攻击
        /// </summary>
        public static float MagicAttack;
        /// <summary>
        /// 物理防御
        /// </summary>
        public static float PhysicalArmor;
        /// <summary>
        /// 魔法防御
        /// </summary>
        public static float MagicArmor;

        /// <summary>
        /// 火焰之力
        /// </summary>
        public static float FirePower;
        /// <summary>
        /// 纯净之力
        /// </summary>
        public static float PurePower;
        /// <summary>
        /// 暗影之力
        /// </summary>
        public static float ShadowPower;
        /// <summary>
        /// 神圣之力
        /// </summary>
        public static float HolyPower;
        #endregion

        #region 加成属性
        /// <summary>
        /// 额外伤害百分比
        /// </summary>
        public static float ExtraDamagePercent;
        /// <summary>
        /// 额外伤害值
        /// </summary>
        public static float ExtraDamageValue;
        /// <summary>
        /// 额外防御百分比
        /// </summary>
        public static float ExtraDefensePercent;
        /// <summary>
        /// 额外防御值
        /// </summary>
        public static float ExtraDefenseValue;
        /// <summary>
        /// 吸血百分比
        /// </summary>
        public static float HematophagiaPercent;
        /// <summary>
        /// 吸血值
        /// </summary>
        public static float HematophagiaValue;
        /// <summary>
        /// 战后回复
        /// </summary>
        public static float PostwarHealthRecoveryValue;
        /// <summary>
        /// 战前回复
        /// </summary>
        public static float PostwarManaRecoveryValue;
        /// <summary>
        /// 额外魔法消耗值
        /// </summary>
        public static float ExtraManaCostValue;

        #endregion

        #region 临时属性 战斗结束后会减去这些属性
        /// <summary>
        /// 临时物理攻击
        /// </summary>
        public static float TempPhysicalAttack;
        /// <summary>
        /// 临时魔法攻击
        /// </summary>
        public static float TempMagicAttack;
        /// <summary>
        /// 临时物理防御
        /// </summary>
        public static float TempPhysicalArmor;
        /// <summary>
        /// 临时魔法防御
        /// </summary>
        public static float TempMagicArmor;
        #endregion

        /// <summary>
        /// 初始化英雄信息
        /// </summary>
        /// <param name="role"></param>
        public static void New(HeroRole role)
        {
        }

        public static void LevelUp()
        {
        }

    }
}
