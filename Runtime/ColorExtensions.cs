using UnityEngine;

namespace JD.Extensions
{
    public static class ColorExtensions
    {
        public static bool Approximately(this Color a, Color b)
        {
            return Mathf.Approximately(a.r, b.r) && Mathf.Approximately(a.g, b.g) && Mathf.Approximately(a.b, b.b) && Mathf.Approximately(a.a, b.a);
        }
        
        public static Color SetR(this Color c, float r)
        {
            return new Color(r, c.g, c.b, c.a);
        }
        
        public static Color SetG(this Color c, float g)
        {
            return new Color(c.r, g, c.b, c.a);
        }
        
        public static Color SetB(this Color c, float b)
        {
            return new Color(c.r, c.g, b, c.a);
        }
        
        public static Color SetA(this Color c, float a)
        {
            return new Color(c.r, c.g, c.b, a);
        }
        
        public static Color ToAlpha(this Color a, float alpha)
        {
            return new Color(a.r, a.g, a.b, alpha);
        }
        
        public static Color32 ToAlpha(this Color32 a, byte alpha)
        {
            return new Color32(a.r, a.g, a.b, alpha);
        }
        
        public static uint ToRGB(this Color a)
        {
            return (uint) ((Mathf.RoundToInt(a.r * 0xFF) << 16) |
                           (Mathf.RoundToInt(a.g * 0xFF) << 8) |
                           Mathf.RoundToInt(a.b * 0xFF));
        }
        
        public static uint ToRGBA(this Color a)
        {
            return (uint) ((Mathf.RoundToInt(a.a * 0xFF) << 24) |
                           (Mathf.RoundToInt(a.r * 0xFF) << 16) |
                           (Mathf.RoundToInt(a.g * 0xFF) << 8) |
                           Mathf.RoundToInt(a.b * 0xFF));
        }
        
        public static Color ToMultiplyAlpha(this Color a, float alpha)
        {
            return new Color(a.r, a.g, a.b, a.a * alpha);
        }
        
        public static Color FromRGB(this int a)
        {
            return new Color(((a & 0xFF0000) >> 16) / 255f, ((a & 0xFF00) >> 8) / 255f, (a & 0xFF) / 255f, 1f);
        }
        
        public static Color FromRGB(this uint a)
        {
            return new Color(((a & 0xFF0000) >> 16) / 255f, ((a & 0xFF00) >> 8) / 255f, (a & 0xFF) / 255f, 1f);
        }
        
        public static Color FromRGBA(this uint a)
        {
            return new Color(((a & 0xFF0000) >> 16) / 255f, ((a & 0xFF00) >> 8) / 255f, (a & 0xFF) / 255f, ((a & 0xFF000000) >> 24) / 255f);
        }

        /*public static Color ToGray(this Color color, float value, float alpha = -1)
        {
            if (Mathf.Approximately(value, 1))
                return color.ToAlpha(alpha >= 0 ? alpha : color.a);
            
            if (color == Color.white)
            {
                var c2 = color * value;
                c2.a = alpha >= 0 ? alpha : color.a;
                return c2;
            }
            
            var hsl = ColorUtils.RGB2HSL(color);
            hsl.y *= value;
            hsl.z *= value;
            
            var c = ColorUtils.HSL2RGB(hsl);
            c.a = alpha >= 0 ? alpha : color.a;
            
            return c;
        }*/
    }
}