using UnityEngine;

namespace JD.Extensions
{
    public static class RectTransformExtensions
    {
        public static void SetPivot(this RectTransform rt, Vector2 pivot)
        {
            var size = rt.sizeDelta;
            var deltaPivot = rt.pivot - pivot;
            var deltaPosition = new Vector3(deltaPivot.x * size.x, deltaPivot.y * size.y);
            
            rt.pivot = pivot;
            rt.localPosition -= deltaPosition;
        }
        
        public static Rect GetWorldRect(this RectTransform rt)
        {
            return GetWorldRect(rt, new Vector2(1, 1));
        }

        public static Rect GetWorldRect(this RectTransform rt, Vector2 scale) 
        {
            // Convert the rectangle to world corners and grab the top left
            Vector3[] corners = new Vector3[4];
            rt.GetWorldCorners(corners);
            Vector3 bottomLeft = corners[0];
 
            // Rescale the size appropriately based on the current Canvas scale
            Vector2 scaledSize = new Vector2(scale.x * rt.rect.size.x, scale.y * rt.rect.size.y);
 
            return new Rect(bottomLeft, scaledSize);
        }
        
        public static void SetPadding(this RectTransform rt, float value)
        {
            SetLeft(rt, value);
            SetRight(rt, value);
            SetTop(rt, value);
            SetBottom(rt, value);
        }
        
        public static float GetLeft(this RectTransform rt)
        {
            return rt.offsetMin.x;
        }
 
        public static float GetRight(this RectTransform rt)
        {
            return -rt.offsetMax.x;
        }
 
        public static float GetTop(this RectTransform rt)
        {
            return -rt.offsetMax.y;
        }
 
        public static float GetBottom(this RectTransform rt)
        {
            return rt.offsetMin.y;
        }
        
        public static float GetX(this RectTransform rt)
        {
            return rt.localPosition.x;
        }
        
        public static float GetY(this RectTransform rt)
        {
            return rt.localPosition.y;
        }
        
        public static void SetLeft(this RectTransform rt, float left)
        {
            rt.offsetMin = new Vector2(left, rt.offsetMin.y);
        }
 
        public static void SetRight(this RectTransform rt, float right)
        {
            rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
        }
 
        public static void SetTop(this RectTransform rt, float top)
        {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
        }
 
        public static void SetBottom(this RectTransform rt, float bottom)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
        }
        
        public static void SetX(this RectTransform rt, float x)
        {
            rt.localPosition = rt.localPosition.SetX(x);
        }
        
        public static void SetY(this RectTransform rt, float y)
        {
            rt.localPosition = rt.localPosition.SetY(y);
        }
        
        public static void OffsetX(this RectTransform rt, float y)
        {
            rt.localPosition = rt.localPosition.OffsetX(y);
        }
        
        public static void OffsetY(this RectTransform rt, float y)
        {
            rt.localPosition = rt.localPosition.OffsetY(y);
        }
        
        public static void SetXY(this RectTransform rt, float x, float y)
        {
            rt.localPosition = new Vector3(x, y);
        }
        
        public static float GetWidth(this RectTransform rt)
        {
            return rt.sizeDelta.x;
        }
        
        public static float GetHeight(this RectTransform rt)
        {
            return rt.sizeDelta.y;
        }
        
        public static void SetWidth(this RectTransform rt, float width)
        {
            rt.sizeDelta = rt.sizeDelta.SetX(width);
        }
        
        public static void SetHeight(this RectTransform rt, float height)
        {
            rt.sizeDelta = rt.sizeDelta.SetY(height);
        }
        
        public static void SetAnchorX(this RectTransform rt, float x)
        {
            rt.anchoredPosition = rt.anchoredPosition.SetX(x);
        }
        
        public static void SetAnchorY(this RectTransform rt, float y)
        {
            rt.anchoredPosition = rt.anchoredPosition.SetY(y);
        }
        
        public static void SetAnchorXY(this RectTransform rt, float x, float y)
        {
            rt.anchoredPosition = new Vector2(x, y);
        }

        public static void SetAnchorMinX(this RectTransform rt, float x)
        {
            rt.anchorMin = rt.anchorMin.SetX(x);
        }
        
        public static void SetAnchorMaxX(this RectTransform rt, float x)
        {
            rt.anchorMax = rt.anchorMax.SetX(x);
        }
        
        public static void SetAnchorMinY(this RectTransform rt, float x)
        {
            rt.anchorMin = rt.anchorMin.SetY(x);
        }
        
        public static void SetAnchorMaxY(this RectTransform rt, float x)
        {
            rt.anchorMax = rt.anchorMax.SetY(x);
        }
        
        public static float GetAnchorX(this RectTransform rt)
        {
            return rt.anchoredPosition.x;
        }
        
        public static float GetAnchorY(this RectTransform rt)
        {
            return rt.anchoredPosition.y;
        }
    }
}