using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Initers;
using Assets.Scripts.UI;
using Assets.Scripts.Utility;
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
        public static BattleSceneType CurrentBattleScene = BattleSceneType.ChooseEvent;
        public static HeroRole Role = HeroRole.FearlessWarrior;

        /// <summary>
        /// 已激活的宝物列表（指的是可能在对局中获得的宝物列表）
        /// </summary>
        public static List<BaseProp> ActivedProps;
        /// <summary>
        /// 已获得的宝物列表
        /// </summary>
        public static List<PropName> GainedProps;

        /// <summary>
        /// 当前职业可用的技能列表
        /// </summary>
        public static List<BaseSkill> ActivedSkills;
        /// <summary>
        /// 已学习的技能列表
        /// </summary>
        public static List<BaseSkill> LearnedSkills;

        /// <summary>
        /// 所有事件信息
        /// </summary>
        public static List<BaseEvent> EventList;
        /// <summary>
        /// 已选择的事件列表
        /// </summary>
        public static List<BaseEvent> OccurredEvents;
        /// <summary>
        /// 当前层数可能触发的事件列表
        /// </summary>
        public static List<BaseEvent> CurrentStageEvents;

        public static List<BaseHeroRole> HeroRoleList;
        /// <summary>
        /// 游戏天数
        /// </summary>
        public static int Day;
        /// <summary>
        /// 持有金钱
        /// </summary>
        public static int Money;
        public static GameEndType EndType;

        /// <summary>
        /// 开始一场新的对局
        /// </summary>
        public static void NewGame()
        {
            CurrentScene = SceneType.BattleMain;
            EndType = GameEndType.None;
            ActivedProps = new List<BaseProp>();
            GainedProps = new List<PropName>();
            ActivedSkills = new List<BaseSkill>();
            LearnedSkills = new List<BaseSkill>();
            EventList = new List<BaseEvent>();
            OccurredEvents = new List<BaseEvent>();
            CurrentStageEvents = new List<BaseEvent>();

            HeroRoleList = new List<BaseHeroRole>();
            Day = 0;
            Money = 1200;
            
            //初始化照相机信息
            CameraSetter.Init();
            //初始化宝物信息
            PropIniter.Init();
            //初始化技能信息
            SkillIniter.Init(Role);
            //初始化事件信息
            EventIniter.Init();
            //初始化职业信息
            HeroRoleIniter.Init();
            //初始化英雄属性
            Hero.New(Role);

            Hero.Health = 40;
            Hero.Mana = 1;
            //更新英雄属性面板
            PropertyPanelUpdater.Update();
            //更新关卡信息面板
            BattleUpdater.UpdateStageInfo();

            BattleUpdater.UpdateMessage("欢迎来到荒原之城！");

            NewStage();
        }

        /// <summary>
        /// 新的关卡
        /// </summary>
        public static void NewStage()
        {
            Day++;
            BattleUpdater.UpdateStageInfo();
            //ShopUpdater.Refresh();
            //BattleCanvasSetter.SwitchBattleScene(BattleSceneType.EventDialog);
            //return;
            if (Day % 20 == 1)
            {
                EventHelper.UpdateCurrentStageEvents();
            }

            //如果三天没有选择战斗事件，则强制生成三个普通怪物
            if (!ThreeDayNotInBattle())
            {
                var stageType1 = EventHelper.GetRandomGameEventType();
                var stageType2 = EventHelper.GetRandomGameEventType();
                var stageType3 = EventHelper.GetRandomGameEventType();
                BattleUpdater.UpdateEvent(stageType1, stageType2, stageType3);
            }
            else
            {
                BattleUpdater.UpdateEvent(GameEventType.NormalMonster, GameEventType.NormalMonster, GameEventType.NormalMonster);
            }
            BattleCanvasSetter.SwitchBattleScene(BattleSceneType.ChooseEvent);
        }

        /// <summary>
        /// 判断是否三天没有选择过战斗事件
        /// </summary>
        /// <returns></returns>
        private static bool ThreeDayNotInBattle()
        {
            if (OccurredEvents.Count < 3)
                return false;

            if (OccurredEvents[OccurredEvents.Count - 1].Type != GameEventType.NormalMonster &&
               OccurredEvents[OccurredEvents.Count - 1].Type != GameEventType.RareMonster &&
               OccurredEvents[OccurredEvents.Count - 1].Type != GameEventType.ElitistMonster &&
               OccurredEvents[OccurredEvents.Count - 1].Type != GameEventType.BOSS)
            {

                if (OccurredEvents[OccurredEvents.Count - 2].Type != GameEventType.NormalMonster &&
                   OccurredEvents[OccurredEvents.Count - 2].Type != GameEventType.RareMonster &&
                   OccurredEvents[OccurredEvents.Count - 2].Type != GameEventType.ElitistMonster &&
                   OccurredEvents[OccurredEvents.Count - 2].Type != GameEventType.BOSS)
                {
                    if (OccurredEvents[OccurredEvents.Count - 3].Type != GameEventType.NormalMonster &&
                      OccurredEvents[OccurredEvents.Count - 3].Type != GameEventType.RareMonster &&
                      OccurredEvents[OccurredEvents.Count - 3].Type != GameEventType.ElitistMonster &&
                      OccurredEvents[OccurredEvents.Count - 3].Type != GameEventType.BOSS)
                    {
                        return true;
                    }
                }
            }

            return false;
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

        public static void GainSkill(SkillName name)
        {
            var skill = LearnedSkills.FirstOrDefault(x => x.Name == name);

            //新技能
            if (skill == null)
            {
                skill = ActivedSkills.FirstOrDefault(x => x.Name == name).Clone();

                SkillUpdater.NewSkill(skill);
                LearnedSkills.Add(skill);
                BattleUpdater.UpdateMessage("学会" + ((skill.RareDegree == SkillRareDegree.Rare) ? "稀有" : "") + "技能：" + skill.DisplayName);
            }
            else
            {
                skill.Level++;
                SkillUpdater.UpgradeSkill(skill);
                BattleUpdater.UpdateMessage("技能 " + skill.DisplayName + " 提升至" + skill.Level.ToString() + "级");
            }
        }

        /// <summary>
        /// 游戏结束
        /// </summary>
        /// <param name="type"></param>
        public static void End()
        {
            EndPageUpdater.Update(EndType);
            CameraSetter.SwichScene(SceneType.End);
        }
    }
}
