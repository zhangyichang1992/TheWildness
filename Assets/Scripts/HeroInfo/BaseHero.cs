using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.HeroInfo
{
    public class BaseHero
    {
        /// <summary>
        /// 英雄名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 精灵名称
        /// </summary>
        public string SpireName;

        #region 基础属性
        /// <summary>
        /// 基础生命
        /// </summary>
        public float BaseHealth;
        /// <summary>
        /// 基础魔法
        /// </summary>
        public float BaseMana;
        /// <summary>
        /// 基础物理攻击
        /// </summary>
        public static float BasePhysicalAttack;
        /// <summary>
        /// 基础魔法攻击
        /// </summary>
        public static float BaseMagicAttack;
        /// <summary>       
        /// 基础物理防御        
        /// </summary>      
        public static float BasePhysicalArmor;
        /// <summary>       
        /// 基础魔法防御        
        /// </summary>      
        public static float BaseMagicArmor;
        #endregion

        #region 成长属性
        /// <summary>
        /// 成长生命
        /// </summary>
        public float GrowthHealth;
        /// <summary>
        /// 成长魔法
        /// </summary>
        public float GrowthMana;
        /// <summary>
        /// 成长物理攻击
        /// </summary>
        public static float GrowthPhysicalAttack;
        /// <summary>
        /// 成长魔法攻击
        /// </summary>
        public static float GrowthMagicAttack;
        /// <summary>       
        /// 成长物理防御        
        /// </summary>      
        public static float GrowthPhysicalArmor;
        /// <summary>       
        /// 成长魔法防御        
        /// </summary>      
        public static float GrowthMagicArmor;
        #endregion
    }
}
