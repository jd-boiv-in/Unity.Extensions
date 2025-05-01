using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

namespace JD.Extensions
{
    public static class RectExtensions
    {
        public static Vector2 BottomLeft(this Rect rect) => new Vector2(rect.xMin, rect.yMin);
        public static Vector2 BottomRight(this Rect rect) => new Vector2(rect.xMax, rect.yMin);
        public static Vector2 TopLeft(this Rect rect) => new Vector2(rect.xMin, rect.yMax);
        public static Vector2 TopRight(this Rect rect) => new Vector2(rect.xMax, rect.yMax);
        
        public static Vector2Int BottomLeft(this RectInt rect) => new Vector2Int(rect.xMin, rect.yMin);
        public static Vector2Int BottomRight(this RectInt rect) => new Vector2Int(rect.xMax, rect.yMin);
        public static Vector2Int TopLeft(this RectInt rect) => new Vector2Int(rect.xMin, rect.yMax);
        public static Vector2Int TopRight(this RectInt rect) => new Vector2Int(rect.xMax, rect.yMax);

        public static Rect Rotate(this Rect rect, Vector2 pivot, float degrees)
        {
            // Convert angle to radians
            var radAngle = degrees * Mathf.Deg2Rad;

            // Get the four corners of the Rect relative to the pivot
            var corners = new Vector2[4];
            corners[0] = rect.BottomLeft().RotateAround(radAngle, pivot);
            corners[1] = rect.BottomRight().RotateAround(radAngle, pivot);
            corners[2] = rect.TopRight().RotateAround(radAngle, pivot);
            corners[3] = rect.TopLeft().RotateAround(radAngle, pivot);

            // Find the new bounding box
            var min = corners[0];
            var max = corners[0];
            foreach (var corner in corners)
            {
                min = Vector2.Min(min, corner);
                max = Vector2.Max(max, corner);
            }

            // Return the new Rect
            return Rect.MinMaxRect(min.x, min.y, max.x, max.y);
        }

        public static Rect Rotate(this Rect rect, float degrees)
        {
            return Rotate(rect, new Vector2(rect.xMin, rect.yMin), degrees);
        }

        public static RectInt Rotate(this RectInt rect, Vector2Int pivot, int degrees)
        {
            degrees = ((degrees % 360) + 360) % 360;
            return degrees switch
            {
                0 => rect,
                90 => Rotate90(rect, pivot),
                180 => Rotate180(rect, pivot),
                270 => Rotate270(rect, pivot),
                _ => rect
            };
        }

        private static RectInt Rotate90(this RectInt rect, Vector2Int pivot)
        {
            var xMin = pivot.x - (rect.yMax - pivot.y);
            var yMin = pivot.y + (rect.xMin - pivot.x);
            return new RectInt(xMin + 1, yMin, rect.height, rect.width);
        }

        private static RectInt Rotate180(this RectInt rect, Vector2Int pivot)
        {
            var xMin = pivot.x - (rect.xMax - pivot.x);
            var yMin = pivot.y - (rect.yMax - pivot.y);
            return new RectInt(xMin + 1, yMin + 1, rect.width, rect.height);
        }

        private static RectInt Rotate270(this RectInt rect, Vector2Int pivot)
        {
            var xMin = pivot.x + (rect.yMin - pivot.y);
            var yMin = pivot.y - (rect.xMax - pivot.x);
            return new RectInt(xMin, yMin + 1, rect.height, rect.width);
        }
        
        public static RectInt Rotate(this RectInt rect, int degrees)
        {
            var pivot = new Vector2Int(rect.xMin, rect.yMin);
            degrees = ((degrees % 360) + 360) % 360;
            return degrees switch
            {
                0 => rect,
                90 => Rotate90(rect, pivot),
                180 => Rotate180(rect, pivot),
                270 => Rotate270(rect, pivot),
                _ => rect
            };
        }
        
        public static RectInt Sub(this RectInt rect, Vector2Int pt)
        {
            return new RectInt(rect.xMin - pt.x, rect.yMin - pt.y, rect.width, rect.height);
        }
        
        public static RectInt Add(this RectInt rect, Vector2Int pt)
        {
            return new RectInt(rect.xMin + pt.x, rect.yMin + pt.y, rect.width, rect.height);
        }
        
        public static Rect Sub(this Rect rect, Vector2 pt)
        {
            return new Rect(rect.xMin - pt.x, rect.yMin - pt.y, rect.width, rect.height);
        }
        
        public static Rect Add(this Rect rect, Vector2 pt)
        {
            return new Rect(rect.xMin + pt.x, rect.yMin + pt.y, rect.width, rect.height);
        }
    }
}