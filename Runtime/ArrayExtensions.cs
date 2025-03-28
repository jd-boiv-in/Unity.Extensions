using System.Collections.Generic;

namespace JD.Extensions
{
    public static class ArrayExtensions
    {
        public static T Random<T>(this T[] array)
        {
            if (array.Length == 0) return default;
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
        
        public static T Random<T>(this List<T> list)
        {
            if (list.Count == 0) return default;
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}