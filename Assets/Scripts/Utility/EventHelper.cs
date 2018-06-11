using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    public static class EventHelper
    {
        /// <summary>
        /// 获取随机事件类型
        /// </summary>
        /// <returns></returns>
        public static GameEventType GetRandomGameEventType()
        {
            var random = NumberHelper.GetRandom(0, 100);
            if (random < 7)
                return GameEventType.Hotel;
            if (random < 12)
                return GameEventType.Treasure;
            if (random < 30)
                return GameEventType.RandomEvent;
            if (random < 38)
                return GameEventType.Shop;
            if (random < 42)
                return GameEventType.RareMonster;
            if (random < 56)
                return GameEventType.ElitistMonster;

            return GameEventType.NormalMonster;

        }

        /// <summary>
        /// 从队列中生成一个随机事件
        /// </summary>
        /// <returns></returns>
        public static void GenerateRandomEvent(BaseEvent e)
        {
            var index = NumberHelper.GetRandom(0, GameInfo.CurrentStageEvents.Count);
            e = GameInfo.CurrentStageEvents[index].Clone();
        }

        public static void UpdateCurrentStageEvents()
        {
            //移除不在时间范围内的事件
            for (var i = 0; i < GameInfo.CurrentStageEvents.Count; i++)
            {
                if (GameInfo.CurrentStageEvents[i].MaxStage < GameInfo.Day)
                {
                    GameInfo.CurrentStageEvents.RemoveAt(i);
                    i--;
                }
            }

            //添加新事件
            foreach (var e in GameInfo.EventList)
            {
                if (e.MinStage == GameInfo.Day - 1)
                {
                    GameInfo.CurrentStageEvents.Add(e.Clone());
                }
            }
        }

        /// <summary>
        /// 生成获取宝物对话框
        /// </summary>
        /// <param name="e">事件本体</param>
        /// <param name="name">宝物名称</param>
        public static void GeneratePropEvent(BaseEvent e, PropName name)
        {
            var prop = GameInfo.ActivedProps.FirstOrDefault(x => x.Name == name);
            e.Title = "获得宝物：" + prop.DisplayName;
            e.Description = prop.Description;
            e.Sprite = SpriteHelper.GetPropSprite(prop.Name);
        }

        public static void GenerateHotelEvent(BaseEvent e)
        {
            e.Title = "荒原酒馆";
            e.Description = "花费金币休息有可能得到意外的惊喜！";
            e.Choose1Name = "驻足";
            e.Choose2Name = "大吃一顿";
            e.Choose3Name = "住宿休息";
            e.Choose1Desc = "恢复最大生命值和魔法值的20%";
            e.Choose2Desc = "花费50金币\n恢复最大生命值和魔法值的50%";
            e.Choose3Desc = "花费100金币\n恢复所有生命值和魔法值";
            e.Sprite = SpriteHelper.GetEventSprite(e.Type);
            e.Choose1 = () =>
            {
                Hero.Health = Math.Min(Hero.MaxHealth, Hero.Health + Hero.MaxHealth * 0.2f);
                Hero.Mana = Math.Min(Hero.MaxMana, Hero.Mana + Hero.MaxMana * 0.2f);
                PropertyPanelUpdater.Update();
                GameInfo.NewStage();
            };
            e.Choose2 = () =>
            {
                if (GameInfo.Money < 50)
                {
                    BattleUpdater.UpdateMessage("别逗我，你太穷了");
                    return;
                }
                GameInfo.Money -= 50;
                Hero.RecoverHealth(Hero.MaxHealth * 0.5f);
                Hero.RecoverMana(Hero.MaxMana * 0.5f);
                BattleUpdater.UpdateStageInfo();
                GameInfo.NewStage();
            };
            e.Choose3 = () =>
            {
                if (GameInfo.Money < 100)
                {
                    BattleUpdater.UpdateMessage("别逗我，你太穷了");
                    return;
                }
                GameInfo.Money -= 100;
                Hero.RecoverHealth(Hero.MaxHealth);
                Hero.RecoverMana(Hero.MaxMana);
                BattleUpdater.UpdateStageInfo();
                GameInfo.NewStage();
            };
        }
    }
}
