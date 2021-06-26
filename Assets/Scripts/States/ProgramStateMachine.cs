using System;
using System.Collections;
using System.Collections.Generic;
using Canvas;
using Chemicals;
using Play;
using UI;
using UnityEngine;


namespace States
{
    public class ProgramStateMachine: MonoBehaviour
    {
        public static ProgramState currentState { get; private set; }

        private static Dictionary<Type, ProgramState> states = new Dictionary<Type, ProgramState>()
        {
            {typeof(ProgramDefaultState), new ProgramDefaultState()},
            {typeof(ProgramDrawState), new ProgramDrawState()},
            {typeof(ProgramPlayingState), new ProgramPlayingState()},
        };
        
        private void Awake()
        {
            SwitchState<ProgramDefaultState>();
        }
        
        public static void SwitchState<T>() where T: ProgramState
        {
            currentState?.End();
            currentState = states[typeof(T)];
            currentState.Start();
        }

        private void Update()
        {
            currentState.Update();
        }
    }

    public abstract class ProgramState
    {
        public virtual void Start()
        {
        }
        public virtual void Update()
        {
        }

        public virtual void End()
        {
        }
    }
    
    public class ProgramDefaultState: ProgramState {

    }
    
    public class ProgramDrawState: ProgramState {
        
        
        public override void Update()
        {
            if (Input.GetButton("Cancel"))
            {
                ProgramStateMachine.SwitchState<ProgramDefaultState>();
            }

            if (Input.GetMouseButton(0))
            {
                if (TilemapManager.GetMouseTilePosition(out Vector2Int position))
                {
                    CanvasManager.OverwriteCell(position, ChemicalManager.selectedChemical, ChemicalManager.selectedValue);
                }
            }
        }
    }
    
    public class ProgramPlayingState: ProgramState
    {
        private float m_Timer;
        public override void Start()
        {
            m_Timer = 0;
        }

        public override void Update()
        {
            m_Timer += Time.deltaTime;

            if (m_Timer > PlayManager.speed)
            {
                m_Timer = 0;
                CanvasManager.NextGenerationCells();
            }
        }
    }
}
