using UnityEditor;
using UnityEngine;

namespace JD.Extensions
{
    public static class MaterialExtensions
    {
        public static void SaveFloat(this Material material, int property, float value)
        {
            material.SetFloat(property, value);
            
#if UNITY_EDITOR
            EditorUtility.SetDirty(material);
            AssetDatabase.SaveAssetIfDirty(material);
#endif
        }
    }
}