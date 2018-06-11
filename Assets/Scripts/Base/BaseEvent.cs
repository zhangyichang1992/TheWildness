using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Base
{
    public class BaseEvent
    {
        public GameEventType Type;
        public string Title;
        public string Description;
        public RandomEvent Name;
        public int Choose;
        public int MinStage;
        public int MaxStage;
        public Sprite Sprite;
        public UnityAction Choose1;
        public UnityAction Choose2;
        public UnityAction Choose3;
        public string Choose1Name;
        public string Choose2Name;
        public string Choose3Name;
        public string Choose1Desc;
        public string Choose2Desc;
        public string Choose3Desc;

        public BaseEvent Clone()
        {
            var e = new BaseEvent();
            e.Type = Type;
            e.Title = Title;
            e.Description = Description;
            e.Name = Name;
            e.Choose = Choose;
            e.MinStage = MinStage;
            e.MaxStage = MaxStage;
            e.Sprite = Sprite;
            e.Choose1 = Choose1;
            e.Choose2 = Choose2;
            e.Choose3 = Choose3;
            e.Choose1Name = Choose1Name;
            e.Choose2Name = Choose2Name;
            e.Choose3Name = Choose3Name;
            e.Choose1Desc = Choose1Desc;
            e.Choose2Desc = Choose2Desc;
            e.Choose3Desc = Choose3Desc;
            return e;
        }
    }
}
