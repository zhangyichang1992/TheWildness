using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Initers
{
    public static class EventIniter
    {
        public static void Init()
        {
            GameInfo.EventList.Clear();

            var e = new BaseEvent();
            e.Type = GameEventType.NormalMonster;
            e.Description = "战斗：普通怪物";
            GameInfo.EventList.Add(e);

            var e1 = new BaseEvent();
            e1.Type = GameEventType.ElitistMonster;
            e1.Description = "战斗：精英怪物";
            GameInfo.EventList.Add(e1);

            var e2 = new BaseEvent();
            e2.Type = GameEventType.RareMonster;
            e2.Description = "战斗：稀有怪物";
            GameInfo.EventList.Add(e2);

            var e3 = new BaseEvent();
            e3.Type = GameEventType.BOSS;
            e3.Description = "战斗：BOSS";
            GameInfo.EventList.Add(e3);

            var e4 = new BaseEvent();
            e4.Type = GameEventType.Shop;
            e4.Description = "旅行商人";
            GameInfo.EventList.Add(e4);

            var e5 = new BaseEvent();
            e5.Type = GameEventType.Hotel;
            e5.Description = "荒原酒馆";
            GameInfo.EventList.Add(e5);

            var e6 = new BaseEvent();
            e6.Type = GameEventType.RandomEvent;
            e6.Description = "随机事件";
            GameInfo.EventList.Add(e6);

            var e7 = new BaseEvent();
            e7.Type = GameEventType.Treasure;
            e7.Description = "闪闪发光的宝藏";
            GameInfo.EventList.Add(e7);
        }
    }
}
