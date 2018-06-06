using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using Assets.Scripts.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Initers
{
    public static class PropIniter
    {
        public static void Init()
        {
            var prop = new BaseProp();
            prop.Name = PropName.ShengXiuDeTieChui;
            prop.DisplayName = "生锈的铁锤";
            prop.Description = "被人遗弃的铁锤，增加1点物理攻击力";
            prop.Gains = () =>
            {
                Hero.PhysicalAttack = Hero.PhysicalAttack + 1;
            };
            GameInfo.ActivedProps.Add(prop);

            for (int i = 0; i < 50; i++)
            {
                GameInfo.GainProp(PropName.ShengXiuDeTieChui);
            }
        }
    }
}
