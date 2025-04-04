using System.Collections.Generic;
using UnityEngine;

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
        
        public static T[,] Clone<T>(this T[,] array)
        {
            if (array == null) return null;
            
            var size = new Vector2Int(array.GetLength(0), array.GetLength(1));
            var clone = new T[size.x, size.y];
            for (var x = 0; x < size.x; x++)
            for (var y = 0; y < size.y; y++)
                clone[x, y] = array[x, y];
            
            return clone;
        }
    }
}