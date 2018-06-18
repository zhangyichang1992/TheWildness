using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Enums
{
    /// <summary>
    /// 战斗场景类型
    /// </summary>
    public enum BattleSceneType
    {
        //战斗中
        Battling,
        //选择事件
        ChooseEvent,
        //事件对话框
        EventDialog,
        //奖励
        Reward,
        //升级技能
        UpgradeSkill,
        //选择天赋
        ChooseAbility,
        //商店
        Shop,
        //信息通知
        Message,
        //战利品
        Spoil,
        //获取技能
        GetSkill
    }
}
