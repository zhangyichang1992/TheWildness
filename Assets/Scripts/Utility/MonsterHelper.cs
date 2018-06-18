using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    public static class MonsterHelper
    {
        public static BaseMonster GetRandomMonster(MonsterType type,int stage)
        {
            var monsters = GameInfo.Monsters.Where(x => x.Type == type && x.MinStage < stage && x.MaxStage > stage).ToList();
            var index= NumberHelper.GetRandom(0, monsters.Count);
            return monsters[index].Clone();
        }
    }
}
