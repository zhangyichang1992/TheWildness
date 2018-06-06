using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Props
{
    public class BaseProp
    {
        public string DisplayName;
        public PropType Type;
        public PropName Name;
        public Action Gains;
        public string Description;
    }
}
