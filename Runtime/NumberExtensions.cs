using System.Collections.Generic;

namespace JD.Extensions
{
    public static class NumberExtensions
    {
        public static float Random(this float value)
        {
            return UnityEngine.Random.Range(0, value); // Already Inclusive
        }
        
        public static int Random(this int value)
        {
            if (value == 0) return 0;
            return UnityEngine.Random.Range(0, value + 1); // Inclusive
        }
    }
}