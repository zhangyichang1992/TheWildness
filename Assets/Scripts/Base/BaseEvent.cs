using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Base
{
    public class BaseEvent
    {
        public GameEventType Type;
        public string Description;
        public RandomEvent Name;
        public int Choose;
        public int MinStage;
        public int MaxStage;

        public BaseEvent Clone()
        {
            var e = new BaseEvent();
            e.Type = Type;
            e.Description = Description;
            e.Name = Name;
            e.Choose = Choose;
            e.MinStage = MinStage;
            e.MaxStage = MaxStage;

            return e;
        }
    }
}
