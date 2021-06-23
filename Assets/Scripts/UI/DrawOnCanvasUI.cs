using System.Collections.Generic;
using Chemicals;
using Rules;
using States;
using UnityEngine;

namespace UI
{
    public class DrawOnCanvasUI : MonoBehaviour
    {
        public static Chemical selectedChemical { get; private set; }
        public static float selectedValue { get; private set; } = 1;

        private void Awake()
        {
            List<Color> tempColors = new List<Color>()
            {
                Color.white,
                Color.cyan,
                Color.blue
            };

            ChemicalColors colors = new ChemicalColors(tempColors);
            
            var rule = new Rule(new List<NumberPair>()
            {
                new NumberPair(0.2f, 0.3f),
                new NumberPair(0.5f, 0.6f)
            });
            selectedChemical = new Chemical(colors, rule);
        }
        
        public void OnDrawOnCanvasButtonPressed()
        {
            ProgramStateMachine.SwitchState<ProgramDrawState>();
        }
    
        
    }
}
