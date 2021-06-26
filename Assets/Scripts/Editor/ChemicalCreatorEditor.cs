using System.Collections.Generic;
using Chemicals;
using Rules;
using Saving;
using UnityEngine;
using UnityEditor;

namespace Editor
{
    public class ChemicalCreatorEditor: EditorWindow
    {
        [MenuItem("Chemicals/Create chemical")]
        static void Init()
        {
            CreateChemical();
        }

        private static void CreateChemical()
        {
            var chemicalName = "test chemical 3";
            
            var chemicalColors = new List<Color32>()
            {
                Color.white,
                Color.green,
            };

            var rule = new Rule(new List<NumberPair>()
            {
                new NumberPair(0.2f, 0.3f),
                new NumberPair(0.5f, 0.6f)
            });
            
            var newChemical = new Chemical(chemicalColors, rule, chemicalName);
            
            SaveManager.Save(newChemical, SaveManager.chemicalSubDir, chemicalName);
        }
    }
}