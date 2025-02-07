using System.Collections.Generic;
using _Project.System.StateMachine.Example.MonoBehaviorStates;
using _Project.System.StateMachine.Example.Realizations.States.GameStates;
using _Project.System.StateMachine.Example.Realizations.States.MaterialStates;
using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine;
using UnityEngine;

namespace _Project.System.StateMachine.Example
{
    public class TestSwitchState: MonoBehaviour
    {
        StateMachine<IGameState> _globalStates;
        StateMachine<IMaterialState> _materialStates;
        public void Init()
        {
            InitGame();
            Debug.Log(_globalStates.GetStates());
            _globalStates.SetStateActive<InGameState>(true, null);
            
            InitMaterial();
        }

        void InitGame()
        {
            var stateMachine = new StateMachineBuilder<IGameState>()
                .Init()
                .AddState(new InGameState())
                .AddState(new PauseState());
            _globalStates = stateMachine.Build();
        }

        void InitMaterial()
        {
            var stateMachine = new StateMachineBuilder<IMaterialState>()
                .Init()
                .AddState(new SimulateState())
                .AddState(new SelectState());
            _materialStates = stateMachine.Build();;
        }

        public void Update()
        {
            _globalStates.Update(null);
            
            _materialStates.Update(null);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var stateStatus = _globalStates.IsStateActive<InGameState>();
                if (!stateStatus)
                {
                    _globalStates.SwitchToState<InGameState>(null);
                    Game();
                }
                else
                {
                    _globalStates.SwitchToState<PauseState>(null);
                    Pause();
                }
            }
        }

        void Pause()//imitation of game pause
        {
            IMaterialState context = new MaterialStateClass();
            context.State = GetComponent<BurnStateMono>();
            
            Debug.Log(context.State.name);
            _materialStates.SetStateActive<SimulateState>(false, context);
        }

        void Game()
        {
            IMaterialState context = new MaterialStateClass();
            context.State = GetComponent<BurnStateMono>();
            Debug.Log(context.State.name);
            _materialStates.SetStateActive<SimulateState>(true, context);
        }
        

        public void Start()
        {
            
            Init();
        }
    }
}