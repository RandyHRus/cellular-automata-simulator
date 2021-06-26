using System.Collections.Generic;
using Chemicals;
using Rules;
using States;
using UnityEngine;

namespace UI
{
    public class DrawOnCanvasUI : MonoBehaviour
    {
        public void OnDrawOnCanvasButtonPressed()
        {
            ProgramStateMachine.SwitchState<ProgramDrawState>();
        }
    
        
    }
}
