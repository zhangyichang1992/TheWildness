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
        public static HeroRole Role = HeroRole.FearlessWarrior;

        /// <summary>
        /// 已激活的宝物列表（指的是可能在对局中获得的宝物列表）
        /// </summary>
        public static IList<BaseProp> ActivedProps;
        /// <summary>
        /// 已获得的宝物列表
        /// </summary>
        public static IList<PropName> GainedProps;

        /// <summary>
        /// 当前职业可用的技能列表
        /// </summary>
        public static IList<BaseSkill> ActivedSkills;
        /// <summary>
        /// 已学习的技能列表
        /// </summary>
        public static IList<BaseSkill> LearnedSkills;

        /// <summary>
        /// 开始一场新的对局
        /// </summary>
        public static void New()
        {
            CurrentScene = SceneType.BattleMain;
            ActivedProps = new List<BaseProp>();
            GainedProps = new List<PropName>();
            ActivedSkills = new List<BaseSkill>();
            LearnedSkills = new List<BaseSkill>();

            //初始化照相机信息
            CameraSetter.Init();
            //初始化宝物信息
            PropIniter.Init();
            //初始化技能信息
            SkillIniter.Init(Role);
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
