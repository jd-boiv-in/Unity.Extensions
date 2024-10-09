using UnityEngine;

namespace JD.Extensions
{
    public static class VectorExtensions
    {
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
    }
}