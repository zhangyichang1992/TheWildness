using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    public static class EventHelper
    {
        public static GameEventType GetRandomEvent()
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
        /// 向队列中添加一个新事件
        /// </summary>
        /// <param name="type"></param>
        public static void AddNewEvent(RandomEvent type)
        {
            var e = GameInfo.EventList.FirstOrDefault(x => x.Name == type);
            if (e != null)
                GameInfo.CurrentStageEvents.Add(e.Clone());
        }
    }
}
