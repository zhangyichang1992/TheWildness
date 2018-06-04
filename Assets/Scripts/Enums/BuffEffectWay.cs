using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Enums
{
    public enum BuffEffectWay
    {
        /// <summary>
        /// 按次生效
        /// </summary>
        Time,
        /// <summary>
        /// 回合生效
        /// </summary>
        Round,
        /// <summary>
        /// 持久
        /// </summary>
        Constant
    }
}
