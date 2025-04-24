using System.Collections.Generic;
using UnityEngine;

namespace JD.Extensions
{
    public static class NumberExtensions
    {
        /// Clamp value between min / max
        public static float Clamp(this float value, float min = 0f, float max = 1f)
        {
            return Mathf.Min(max, Mathf.Max(min, value));
        }
        
        /// Inclusive random
        public static float Random(this float value)
        {
            return UnityEngine.Random.Range(0, value);
        }
        
        /// Inclusive random
        public static int Random(this int value)
        {
            if (value == 0) return 0;
            return UnityEngine.Random.Range(0, value + 1);
        }

        /// Modulo that wraps around negative value so (-2 % 12) is 10 not -2 / 2
        public static int Mod(this int value, int mod)
        {
            if (value < 0)
            {
                var m = value % mod;
                if (m == 0) return 0;
                
                return mod + (value % mod);
            }
            
            return value % mod;
        }
    }
}