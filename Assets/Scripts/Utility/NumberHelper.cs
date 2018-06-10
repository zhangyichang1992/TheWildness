using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Assets.Scripts.Utility
{
    public static class NumberHelper
    {
        public static int GetRandom(int n, int m)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(n, m);
        }

        public static float GetLevelExp(int n)
        {
            if (n == 16)
                return 9999;
            float d = 10f;
            //8级以下每级额外需要12经验
            d = d + 12f * Convert.ToSingle(n);
            //8-12级每级额外需要20经验
            if (n > 8)
                d = d + 20f * (Convert.ToSingle(n) - 8f);
            //12-15级每级额外需要36点经验
            if (n > 12)
                d = d + 36f * (Convert.ToSingle(n) - 12f);
            
            return d;
        }

        public static float GetRound(float n)
        {
            return Convert.ToSingle(Math.Round(n));
        }
    }
}
