using UnityEngine;
using UnityEngine.UI;

namespace JD.Extensions
{
    public static class UIExtensions
    {
        public static Image SetAlpha(this Image image, float value)
        {
            image.color = image.color.ToAlpha(value);
            return image;
        }
    }
}