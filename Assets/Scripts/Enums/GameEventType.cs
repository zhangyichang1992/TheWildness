using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Enums
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public enum GameEventType
    {
        //战斗：普通怪物
        NormalMonster,
        //战斗：稀有怪物
        ElitistMonster,
        //战斗：稀有怪物
        RareMonster,
        //战斗：BOSS
        BOSS,
        //商店
        Shop,
        //宝箱
        Treasure,
        //随机事件
        RandomEvent,
        //旅馆
        Hotel           
    }
}
