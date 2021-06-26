using System;
using System.Collections.Generic;
using Saving;
using UnityEngine;

namespace Chemicals
{
    public class ChemicalManager: MonoBehaviour
    {
        public static Chemical selectedChemical { get; private set; }
        public static float selectedValue { get; private set; } = 1;

        private static readonly Dictionary<string, Chemical> GuidToChemicalCache = new Dictionary<string, Chemical>();
        private static readonly Dictionary<string, Chemical> NameToChemicalCache = new Dictionary<string, Chemical>();
        public static readonly List<Chemical> allChemicals = new List<Chemical>();

        public static Action onCacheRefreshed;

        private void Awake()
        {
            CacheManager.onEarlyCacheRefresh += OnCacheRefreshHandler;
        }
        
        public static Chemical GetChemicalWithGuid(string guid)
        {
            return GuidToChemicalCache[guid];
        }

        private static void OnCacheRefreshHandler()
        {
            GuidToChemicalCache.Clear();
            NameToChemicalCache.Clear();
            allChemicals.Clear();
            
            var allSaves = SaveManager.LoadAll<Chemical>(SaveManager.chemicalSubDir);
            foreach (var chemical in allSaves)
            {
                GuidToChemicalCache.Add(chemical.guid, chemical);
                NameToChemicalCache.Add(chemical.chemicalName, chemical);
                allChemicals.Add(chemical);
            }

            onCacheRefreshed?.Invoke();
        }
        
        public static void ChangeSelectedChemical(string chemicalName)
        {
            selectedChemical = NameToChemicalCache[chemicalName];
        }
    }
}