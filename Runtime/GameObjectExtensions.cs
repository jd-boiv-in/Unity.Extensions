using UnityEngine;

namespace JD.Extensions
{
    public static class GameObjectExtensions
    {
        public static void RemoveAll(this GameObject obj)
        {
            while (obj.transform.childCount > 0)
                Object.Destroy(obj.transform.GetChild(0));
        }
        
        public static void RemoveAll(this Transform trs)
        {
            while (trs.childCount > 0)
                Object.Destroy(trs.GetChild(0));
        }
    }
}