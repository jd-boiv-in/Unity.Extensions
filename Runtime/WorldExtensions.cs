using TMPro;
using UnityEngine;

namespace JD.Extensions
{
    public static class WorldExtensions
    {
        public static void SetAlpha(this TextMeshPro text, float value)
        {
            text.alpha = value;
            
            // Optimized version
            /*var info = text.textInfo;
            if (info == null) return;

            Color32 color = text.color.ToAlpha(value);
            for (var i = 0; i < info.characterCount; i++)
            {
                var c = info.characterInfo[i];
                var colors = info.meshInfo[c.materialReferenceIndex].colors32;

                var n = Mathf.Min(c.vertexIndex + 4, colors.Length);
                for (var j = c.vertexIndex; j < n; j++)
                    colors[j] = color;
            }

            text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            text.SetColor(color);*/
        }
        
        public static void SetAlpha(this SpriteRenderer sprite, float value)
        {
            sprite.color = sprite.color.ToAlpha(value);
        }
        
        public static void SetWidth(this SpriteRenderer sprite, float value)
        {
            sprite.size = sprite.size.SetX(value);
        }
        
        public static void SetHeight(this SpriteRenderer sprite, float value)
        {
            sprite.size = sprite.size.SetY(value);
        }
        
        public static void SetX(this SpriteRenderer sprite, float value)
        {
            var trs = sprite.transform;
            trs.localPosition = trs.localPosition.SetX(value);
        }
        
        public static void SetY(this SpriteRenderer sprite, float value)
        {
            var trs = sprite.transform;
            trs.localPosition = trs.localPosition.SetY(value);
        }
        
        public static void SetX(this Transform trs, float value)
        {
            trs.localPosition = trs.localPosition.SetX(value);
        }
        
        public static void SetY(this Transform trs, float value)
        {
            trs.localPosition = trs.localPosition.SetY(value);
        }
        
        public static void OffsetX(this Transform trs, float value)
        {
            trs.localPosition = trs.localPosition.OffsetX(value);
        }
        
        public static void OffsetY(this Transform trs, float value)
        {
            trs.localPosition = trs.localPosition.OffsetY(value);
        }
        
        public static void SetZ(this Transform trs, float value)
        {
            trs.position = trs.position.SetZ(value);
        }
        
        public static void Show(this Transform trs)
        {
            trs.position = trs.position.SetZ(0);
        }
        
        public static void Hide(this Transform trs)
        {
            trs.position = trs.position.SetZ(-10000);
        }
        
        public static bool IsHidden(this Transform trs)
        {
            return trs.position.z < -1000;
        }
        
        public static void SetScale(this Transform trs, float value)
        {
            trs.localScale = value.ToV3();
        }
        
        public static void SetScaleX(this Transform trs, float value)
        {
            trs.localScale = trs.localScale.SetX(value);
        }
        
        public static void SetScaleY(this Transform trs, float value)
        {
            trs.localScale = trs.localScale.SetY(value);
        }
        
        public static void SetRotation(this Transform trs, float value)
        {
            trs.localRotation = Quaternion.Euler(trs.localRotation.eulerAngles.SetZ(value));
        }
        
        public static void SetWorldRotation(this Transform trs, float value)
        {
            trs.rotation = Quaternion.Euler(trs.rotation.eulerAngles.SetZ(value));
        }
    }
}