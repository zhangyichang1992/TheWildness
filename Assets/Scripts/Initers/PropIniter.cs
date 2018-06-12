using Assets.Scripts.Base;
using Assets.Scripts.Enums;
using Assets.Scripts.Global;
using Assets.Scripts.UI;
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
            GameInfo.ActivedProps.Clear();
            GameInfo.GainedProps.Clear();

            {
                var prop = new BaseProp();
                prop.Name = PropName.生锈的铁锤;
                prop.DisplayName = "生锈的铁锤";
                prop.Description = "被人遗弃的铁锤，增加8点物理攻击力";
                prop.Type = PropType.Normal;
                prop.Price = 66;
                prop.Gains = () =>
                {
                    Hero.PhysicalAttack = Hero.PhysicalAttack + 8;
                    PropertyPanelUpdater.Update();
                };
                GameInfo.ActivedProps.Add(prop);
            }

            {
                var prop = new BaseProp();
                prop.Name = PropName.学徒木杖;
                prop.DisplayName = "学徒木杖";
                prop.Description = "初级魔法师使用的武器，增加8点法术攻击力";
                prop.Type = PropType.Normal;
                prop.Price = 66;
                prop.Gains = () =>
                {
                    Hero.MagicAttack = Hero.MagicAttack + 8;
                    PropertyPanelUpdater.Update();
                };
                GameInfo.ActivedProps.Add(prop);
            }

            {
                var prop = new BaseProp();
                prop.Name = PropName.新兵盾牌;
                prop.DisplayName = "新兵盾牌";
                prop.Description = "士兵使用的盾牌，增加5点物理防御力";
                prop.Type = PropType.Normal;
                prop.Price = 66;
                prop.Gains = () =>
                {
                    Hero.PhysicalArmor = Hero.PhysicalArmor + 5;
                    PropertyPanelUpdater.Update();
                };
                GameInfo.ActivedProps.Add(prop);
            }

            {
                var prop = new BaseProp();
                prop.Name = PropName.魔法硬币;
                prop.DisplayName = "魔法硬币";
                prop.Description = "魔法世界的通用货币，增加5点法术防御力";
                prop.Type = PropType.Normal;
                prop.Price = 66;
                prop.Gains = () =>
                {
                    Hero.MagicArmor = Hero.MagicArmor + 5;
                    PropertyPanelUpdater.Update();
                };
                GameInfo.ActivedProps.Add(prop);
            }

            {
                var prop = new BaseProp();
                prop.Name = PropName.不息烈焰;
                prop.DisplayName = "不息烈焰";
                prop.Description = "永不熄灭的火焰，增加1点火焰之力";
                prop.Type = PropType.Normal;
                prop.Price = 66;
                prop.Gains = () =>
                {
                    Hero.FirePower = Hero.FirePower + 1;
                    PropertyPanelUpdater.Update();
                };
                GameInfo.ActivedProps.Add(prop);
            }

            {
                var prop = new BaseProp();
                prop.Name = PropName.纯净之瓶;
                prop.DisplayName = "纯净之瓶";
                prop.Description = "精灵饮水所需的容器，增加1点纯净之力";
                prop.Type = PropType.Normal;
                prop.Price = 66;
                prop.Gains = () =>
                {
                    Hero.PurePower = Hero.PurePower + 1;
                    PropertyPanelUpdater.Update();
                };
                GameInfo.ActivedProps.Add(prop);
            }

            {
                var prop = new BaseProp();
                prop.Name = PropName.乌鸦披风;
                prop.DisplayName = "乌鸦披风";
                prop.Description = "乌鸦之神早年间使用的披风，增加1点暗影之力";
                prop.Type = PropType.Normal;
                prop.Price = 66;
                prop.Gains = () =>
                {
                    Hero.ShadowPower = Hero.ShadowPower + 1;
                    PropertyPanelUpdater.Update();
                };
                GameInfo.ActivedProps.Add(prop);
            }


            {
                var prop = new BaseProp();
                prop.Name = PropName.太阳挂坠;
                prop.DisplayName = "太阳挂坠";
                prop.Description = "带有太阳图标的挂坠，增加1点神圣之力";
                prop.Type = PropType.Normal;
                prop.Price = 66;
                prop.Gains = () =>
                {
                    Hero.HolyPower = Hero.HolyPower + 1;
                    PropertyPanelUpdater.Update();
                };
                GameInfo.ActivedProps.Add(prop);
            }

            //for (int i = 0; i < 50; i++)
            //{
            //    GameInfo.GainProp(PropName.生锈的铁锤);
            //}

        }
    }
}
