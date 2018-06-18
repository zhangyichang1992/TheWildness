using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Global
{
    public static class Battle
    {
        static BaseMonster Monster;
        static int Turn;

        public static void New(BaseMonster monster)
        {
            Turn = 0;
            Monster = monster;
        }

        public static void MonsterTurn()
        { }

        public static void HeroTurn()
        {
            Turn++;
            UseSkill(null);
        }

        public static void UseSkill(BaseSkill skill)
        {
            Win();
        }

        static void Win()
        {
            BattleCanvasSetter.Scenes.Enqueue(BattleSceneType.Spoil);
            BattleCanvasSetter.SwitchBattleScene();
        }
    }
}
