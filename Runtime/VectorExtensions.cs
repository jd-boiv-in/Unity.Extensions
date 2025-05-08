using System;
using UnityEngine;

namespace JD.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 Rotate(this Vector2 value, float angle)
        {
            var length = value.magnitude;
            angle = value.Angle() + angle;
            
            return new Vector2(length * Mathf.Cos(angle), length * Mathf.Sin(angle));
        }
        
        public static float Random(this Vector2 vector)
        {
            return UnityEngine.Random.Range(vector.x, vector.y); // Inclusive already
        }
        
        public static int Random(this Vector2Int vector)
        {
            if (vector.x == vector.y) return vector.x;
            return UnityEngine.Random.Range(vector.x, vector.y + 1); // Inclusive
        }
        
        public static float Random(this Vector2 vector, float random)
        {
            if (Mathf.Approximately(vector.x, vector.y)) return vector.x;
            return vector.x + (vector.y - vector.x) * (random < 0 ? UnityEngine.Random.Range(vector.x, vector.y) : random);
        }
        
        public static int Random(this Vector2Int vector, float random)
        {
            if (vector.x == vector.y) return vector.x;
            return vector.x + Mathf.RoundToInt((vector.y - vector.x) * (random < 0 ? UnityEngine.Random.Range(vector.x, vector.y) : random));
        }
        
        public static float Random(this Vector2 vector, int seed)
        {
            if (Mathf.Approximately(vector.x, vector.y)) return vector.x;
            UnityEngine.Random.InitState(seed);
            return UnityEngine.Random.Range(vector.x, vector.y); // Inclusive already
        }
        
        public static int Random(this Vector2Int vector, int seed)
        {
            if (vector.x == vector.y) return vector.x;
            UnityEngine.Random.InitState(seed);
            return UnityEngine.Random.Range(vector.x, vector.y + 1); // Inclusive
        }
        
        public static Vector2 RotateAround(this Vector2 point, float angle, Vector2 pivot = default)
        {
            var translated = point - pivot;

            var cosAngle = Mathf.Cos(angle);
            var sinAngle = Mathf.Sin(angle);
            var rotated = new Vector2(
                translated.x * cosAngle - translated.y * sinAngle,
                translated.x * sinAngle + translated.y * cosAngle
            );

            return rotated + pivot;
        }
        
        public static Vector2Int RotateAround(this Vector2Int point, int degrees, Vector2Int pivot = default)
        {
            degrees = ((degrees % 360) + 360) % 360;
            return degrees switch
            {
                0 => point,
                90 => Rotate90(point, pivot),
                180 => Rotate180(point, pivot),
                270 => Rotate270(point, pivot),
                _ => point
            };
        }

        public static Vector2Int Rotate90(this Vector2Int point, Vector2Int pivot = default)
        {
            var x = pivot.x - (point.y - pivot.y);
            var y = pivot.y + (point.x - pivot.x);
            return new Vector2Int(x, y);
        }

        public static Vector2Int Rotate180(this Vector2Int point, Vector2Int pivot = default)
        {
            var x = pivot.x - (point.x - pivot.x);
            var y = pivot.y - (point.y - pivot.y);
            return new Vector2Int(x, y);
        }

        public static Vector2Int Rotate270(this Vector2Int point, Vector2Int pivot = default)
        {
            var x = pivot.x + (point.y - pivot.y);
            var y = pivot.y - (point.x - pivot.x);
            return new Vector2Int(x, y);
        }
        
        public static Vector3 SetX(this Vector3 vector, float x)
        {
            vector.x = x;
            return vector;
        }
        
        public static Vector3 Offset(this Vector3 vector, Vector3 offset)
        {
            vector += offset;
            return vector;
        }
        
        public static Vector3 Offset(this Vector3 vector, float x, float y)
        {
            vector += new Vector3(x, y, 0);
            return vector;
        }
        
        public static Vector3 OffsetX(this Vector3 vector, float x)
        {
            vector.x += x;
            return vector;
        }
        
        public static Vector2 SetX(this Vector2 vector, float x)
        {
            vector.x = x;
            return vector;
        }
        
        public static Vector2 OffsetX(this Vector2 vector, float x)
        {
            vector.x += x;
            return vector;
        }
        
        public static Vector3 SetY(this Vector3 vector, float y)
        {
            vector.y = y;
            return vector;
        }
        
        public static Vector3 OffsetY(this Vector3 vector, float y)
        {
            vector.y += y;
            return vector;
        }
        
        public static Vector2 SetY(this Vector2 vector, float y)
        {
            vector.y = y;
            return vector;
        }
        
        public static Vector2 OffsetY(this Vector2 vector, float y)
        {
            vector.y += y;
            return vector;
        }
        
        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            vector.z = z;
            return vector;
        }
        
        public static Vector3 OffsetZ(this Vector3 vector, float z)
        {
            vector.z += z;
            return vector;
        }
        
        public static Vector2 ToV2(this float value)
        {
            return new Vector2(value, value);
        }
        
        public static Vector3 ToV3(this float value)
        {
            return new Vector3(value, value, value);
        }
        
        public static Vector2 ToV2(this Vector3 value)
        {
            return new Vector2(value.x, value.y);
        }
        
        public static Vector3 ToV3(this Vector2 value)
        {
            return new Vector3(value.x, value.y, 0);
        }
        
        public static Vector2 ToFloat(this Vector2Int value)
        {
            return new Vector2(value.x, value.y);
        }
        
        public static Vector3 ToFloat(this Vector3Int value)
        {
            return new Vector3(value.x, value.y, value.z);
        }
        
        public static Vector2Int ToInt(this Vector2 value)
        {
            return new Vector2Int((int) value.x, (int) value.y);
        }
        
        public static Vector3Int ToInt(this Vector3 value)
        {
            return new Vector3Int((int) value.x, (int) value.y, (int) value.z);
        }
        
        public static float Angle(this Vector2 to)
        {
            // Atan2
            return Mathf.Atan2(to.y, to.x);
            
            // Unity's (not working for all quadrant but might be faster?)
            //var from = Vector2.right;
            //var num = (float) Math.Sqrt((double) from.sqrMagnitude * (double) to.sqrMagnitude);
            //return (double) num < 1.0000000036274937E-15 ? 0.0f : (float) Math.Acos((double) Mathf.Clamp(Vector2.Dot(from, to) / num, -1f, 1f)) * 57.29578f;
        }
        
        public static float Angle(this Vector3 to)
        {
            return Mathf.Atan2(to.y, to.x);
        }
        
        public static float Angle(this Vector3 a, Vector3 b)
        {
            var diff = b - a;
            return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg + 180;

            // I'm missing something here... Unity's method don't work as expected...
            //return Vector3.Angle(a, b);
        }
    }
}