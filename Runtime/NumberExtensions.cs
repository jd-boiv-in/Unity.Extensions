using System.Collections.Generic;
using UnityEngine;

namespace JD.Extensions
{
    public static class NumberExtensions
    {
        /// Return the number of digits (base 10 obviously)
        public static int Digits(this int n)
        {
            if (n >= 0)
            {
                if (n < 10) return 1;
                if (n < 100) return 2;
                if (n < 1000) return 3;
                if (n < 10000) return 4;
                if (n < 100000) return 5;
                if (n < 1000000) return 6;
                if (n < 10000000) return 7;
                if (n < 100000000) return 8;
                if (n < 1000000000) return 9;
                return 10;
            }
            else
            {
                if (n > -10) return 2;
                if (n > -100) return 3;
                if (n > -1000) return 4;
                if (n > -10000) return 5;
                if (n > -100000) return 6;
                if (n > -1000000) return 7;
                if (n > -10000000) return 8;
                if (n > -100000000) return 9;
                if (n > -1000000000) return 10;
                return 11;
            }
        }

        public static int NthDigit(this int n, int digit)
        {
            // (_value / (int) Mathf.Pow(10, _digits - i - 1)) % 10;

            if (digit == 0) return n % 10;
            if (digit == 1) return (n / 10) % 10;
            if (digit == 2) return (n / 100) % 10;
            if (digit == 3) return (n / 1000) % 10;
            if (digit == 4) return (n / 10000) % 10;
            if (digit == 5) return (n / 100000) % 10;
            if (digit == 6) return (n / 1000000) % 10;
            if (digit == 7) return (n / 10000000) % 10;
            return n % 10;
        }
        
        /// Find the next nearest Power of Two
        public static int NextPowerOfTwo(this int x)
        {
            if (x < 0) { return 0; }
            --x;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            return x + 1;
        }
        
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