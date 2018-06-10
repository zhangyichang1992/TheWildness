using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    public static class PropHelper
    {
        public static BaseProp GetRandomVisibleProp(PropType type)
        {
            var propList = new List<PropName>();
            foreach (var prop in GameInfo.ActivedProps)
            {
                if (prop.Type == type && !GameInfo.GainedProps.Contains(prop.Name))
                {
                    propList.Add(prop.Name);
                }
            }
            var index = NumberHelper.GetRandom(0, propList.Count);
            var randomProp = GameInfo.ActivedProps.FirstOrDefault(x => x.Name == propList[index]);

            return randomProp;
        }
    }
}
