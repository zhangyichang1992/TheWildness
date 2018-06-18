using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using Assets.Scripts.UI;
using Assets.Scripts.Utility;
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
            e4.Choose1 = e4.Choose2 = e4.Choose3 = null;
            GameInfo.EventList.Add(e4);

            var e5 = new BaseEvent();
            e5.Type = GameEventType.Hotel;
            e5.Description = "荒原酒馆";
            e5.Choose1 = e5.Choose2 = e5.Choose3 = null;
            GameInfo.EventList.Add(e5);

            var e6 = new BaseEvent();
            e6.Type = GameEventType.RandomEvent;
            e6.Description = "随机事件";
            e6.Choose1 = e6.Choose2 = e6.Choose3 = null;
            GameInfo.EventList.Add(e6);

            var e7 = new BaseEvent();
            e7.Type = GameEventType.Treasure;
            e7.Description = "闪闪发光的宝藏";
            e7.Choose1 = e7.Choose2 = e7.Choose3 = null;
            GameInfo.EventList.Add(e7);

            RandomEventInit();
        }

        static void RandomEventInit()
        {
            {
                var e = new BaseEvent();
                e.Type = GameEventType.RandomEvent;
                e.Title = "苹果树";
                e.Name = RandomEvent.苹果树;
                e.Description = "你遇到了一颗长满果实的苹果树";
                e.Choose1Name = "采摘";
                e.Choose1Desc = "回复40点生命值及10点魔法值";
                e.MinStage = 1;
                e.MaxStage = 20;
                e.Sprite = SpriteHelper.GetRandomEventSprite(RandomEvent.苹果树);
                e.Choose1 = () =>
                {
                    Hero.RecoverHealth(40);
                    Hero.RecoverMana(10);
                    MessagePageUpdater.Update("一顿忙碌后，终于摘到了不少苹果，并饱餐一顿\n\n回复40点生命值及10点魔法值");
                    BattleCanvasSetter.Scenes.Enqueue(BattleSceneType.Message);
                    BattleCanvasSetter.SwitchBattleScene();
                };
                e.Choose2 = e.Choose3 = null;
                GameInfo.EventList.Add(e);
            }

            {
                var e = new BaseEvent();
                e.Type = GameEventType.RandomEvent;
                e.Title = "捕兽夹";
                e.Name = RandomEvent.捕兽夹;
                e.Description = "前方有一个被遗弃的捕兽夹，如果不管它可能会伤害到其他的冒险者";
                e.Choose1Name = "尝试拆除";
                e.Choose1Desc = "这个陷阱看起来很劣质，我有把握拆除它";
                e.MinStage = 1;
                e.MaxStage = 40;
                e.Sprite = SpriteHelper.GetRandomEventSprite(RandomEvent.捕兽夹);
                e.Choose1 = () =>
                {
                    var seed = NumberHelper.GetRandom(0, 3);
                    if (seed == 2)
                    {
                        Hero.RecoverHealth(-30);
                        MessagePageUpdater.Update("一阵忙碌后，不仅没有拆除陷阱，自己还被划伤了\n\n损失30点生命值");
                    }
                    else
                    {
                        Hero.PhysicalArmor += 5;
                        Hero.MagicArmor += 5;
                        MessagePageUpdater.Update("成功的拆除了陷阱，提升了自身的战斗抗性\n\n增加5点物理防御力与法术防御力");
                    }
                    BattleCanvasSetter.Scenes.Enqueue(BattleSceneType.Message);
                    BattleCanvasSetter.SwitchBattleScene();
                };
                e.Choose2 = e.Choose3 = null;
                GameInfo.EventList.Add(e);
            }

            {
                var e = new BaseEvent();
                e.Type = GameEventType.RandomEvent;
                e.Title = "游荡学者";
                e.Name = RandomEvent.游荡学者;
                e.Description = "你碰到了一个满脸书生气的";
                e.Choose1Name = "请教";
                e.Choose1Desc = "活到老学到老，向前辈请教";
                e.Choose2Name = "抢劫";
                e.Choose2Desc = "柿子要挑软的捏，看看这人身上有什么宝贝";
                e.MinStage = 1;
                e.MaxStage = 40;
                e.Sprite = SpriteHelper.GetRandomEventSprite(RandomEvent.游荡学者);
                e.Choose1 = () =>
                {
                    var skillName = SkillHelper.UpgradeRandomSkill();
                    if (string.IsNullOrEmpty(skillName))
                    {
                        MessagePageUpdater.Update("学者对你说，你已经足够强大了，我没有什么能够教你的");
                    }
                    else
                    {
                        MessagePageUpdater.Update("虚心请教后，你确实感觉学到了不少东西\n\n" + skillName + "提升一级");
                    }
                    BattleCanvasSetter.Scenes.Enqueue(BattleSceneType.Message);
                    BattleCanvasSetter.SwitchBattleScene();
                };
                e.Choose2 = () =>
                {
                    var seed = NumberHelper.GetRandom(0, 3);
                    if (seed == 2)
                    {
                        MessagePageUpdater.Update("没想到看似柔弱的书生是个高手，被揍的遍体鳞伤\n\n损失40%当前生命值");
                        Hero.RecoverHealth(Hero.Health * -0.4f);
                    }
                    else
                    {
                        MessagePageUpdater.Update("书生主动求饶，并交出了他的所有财产\n\n获得150金币");
                        GameInfo.Money += 150;
                        BattleUpdater.UpdateStageInfo();
                    }

                    BattleCanvasSetter.Scenes.Enqueue(BattleSceneType.Message);
                    BattleCanvasSetter.SwitchBattleScene();
                };
                e.Choose3 = null;
                GameInfo.EventList.Add(e);
            }
        }
    }
}
