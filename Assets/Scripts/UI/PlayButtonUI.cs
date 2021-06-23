using States;
using UnityEngine;

namespace UI
{
    public class PlayButtonUI: MonoBehaviour
    {
        public void OnPlayButtonPressed()
        {
            if (ProgramStateMachine.currentState is ProgramPlayingState)
            {
                ProgramStateMachine.SwitchState<ProgramDefaultState>();
            }
            else
            {
                ProgramStateMachine.SwitchState<ProgramPlayingState>();
            }
        }
    }
}