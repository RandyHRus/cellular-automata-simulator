using System;
using UnityEngine;

namespace Saving
{
    public class CacheManager: MonoBehaviour
    {
        public static Action onEarlyCacheRefresh; //This is needed because chemical needs to be refreshed before canvas
        public static Action onCacheRefresh;
        
        private void Start()
        {
            RefreshCache();
        }

        public static void RefreshCache()
        {
            onEarlyCacheRefresh.Invoke();
            onCacheRefresh?.Invoke();
        }
        
    }
}