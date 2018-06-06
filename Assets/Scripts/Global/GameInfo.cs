using Assets.Scripts.Enums;
using Assets.Scripts.Initers;
using Assets.Scripts.Props;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Global
{
    /// <summary>
    /// 对局信息记录器
    /// </summary>
    public static class GameInfo
    {
        public static SceneType CurrentScene = SceneType.Start;

        /// <summary>
        /// 已激活的宝物列表（指的是可能在对局中获得的宝物列表）
        /// </summary>
        public static IList<BaseProp> ActivedProps;
        /// <summary>
        /// 已获得的宝物列表
        /// </summary>
        public static IList<PropName> GainedProps;

        /// <summary>
        /// 开始一场新的对局
        /// </summary>
        public static void New()
        {
            ActivedProps = new List<BaseProp>();
            GainedProps = new List<PropName>();

            PropIniter.Init();
        }

        public static void GainProp(PropName name)
        {
            //修改UI
            PropUpdater.GainProp(name);

            var prop = ActivedProps.FirstOrDefault(x => x.Name == name);
            GainedProps.Add(name);
            if (prop.Gains != null)
                prop.Gains();

        }
    }
}
