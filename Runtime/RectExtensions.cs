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

        public static Rect Rotate(this Rect rect, float degrees, Vector2 pivot = default)
        {
            // Convert angle to radians
            var radAngle = degrees * Mathf.Deg2Rad;

            // Get the four corners of the Rect relative to the pivot
            var corners = new Vector2[4];
            corners[0] = rect.BottomLeft().Rotate(radAngle, pivot);
            corners[1] = rect.BottomRight().Rotate(radAngle, pivot);
            corners[2] = rect.TopRight().Rotate(radAngle, pivot);
            corners[3] = rect.TopLeft().Rotate(radAngle, pivot);

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

        public static RectInt Rotate(this RectInt rect, int degrees, Vector2Int pivot = default)
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

        public static RectInt Rotate90(this RectInt rect, Vector2Int pivot = default)
        {
            var xMin = pivot.x - (rect.yMax - pivot.y);
            var yMin = pivot.y + (rect.xMin - pivot.x);
            return new RectInt(xMin, yMin, rect.height, rect.width);
        }

        public static RectInt Rotate180(this RectInt rect, Vector2Int pivot = default)
        {
            var xMin = pivot.x - (rect.xMax - pivot.x);
            var yMin = pivot.y - (rect.yMax - pivot.y);
            return new RectInt(xMin, yMin, rect.width, rect.height);
        }

        public static RectInt Rotate270(this RectInt rect, Vector2Int pivot = default)
        {
            var xMin = pivot.x + (rect.yMin - pivot.y);
            var yMin = pivot.y - (rect.xMax - pivot.x);
            return new RectInt(xMin, yMin, rect.height, rect.width);
        }
    }
}