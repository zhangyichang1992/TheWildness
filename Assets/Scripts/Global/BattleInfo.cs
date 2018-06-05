using Assets.Scripts.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Global
{
    /// <summary>
    /// 对局信息记录器
    /// </summary>
    public static class BattleInfo
    {
        /// <summary>
        /// 已激活的宝物列表（指的是可能在对局中获得的宝物列表）
        /// </summary>
        public static List<BaseProp> ActivedProps;
        /// <summary>
        /// 已获得的宝物列表
        /// </summary>
        public static List<BaseProp> GainedProps;

        /// <summary>
        /// 开始一场新的对局
        /// </summary>
        public static void New()
        {
            ActivedProps = new List<BaseProp>();
            GainedProps = new List<BaseProp>();
        }

    }
}
