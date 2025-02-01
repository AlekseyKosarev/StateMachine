using _Project.System.StateMachine.Example.MonoBehaviorStates;
using _Project.System.StateMachine.Example.Realizations.States.GameStates;
using _Project.System.StateMachine.Example.Realizations.States.MaterialStates;
using _Project.System.StateMachine.StateMachine;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;
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
            _globalStates.AddStateToRegistry(new InGameState());
            _globalStates.AddStateToRegistry(new PauseState());
            _globalStates.SetStateActive<InGameState>(true, null);
            
            InitMaterial();
            _materialStates.AddStateToRegistry(new SimulateState());
        }

        void InitGame()
        {
            var stateRegistry = new StateRegistry<IGameState>();
            var stateActivator = new StateActivator<IGameState>();

            var stateMachine = new StateMachine<IGameState>(stateRegistry, stateActivator);
            _globalStates = stateMachine;
        }

        void InitMaterial()
        {
            var stateRegistry = new StateRegistry<IMaterialState>();
            var stateActivator = new StateActivator<IMaterialState>();

            var stateMachine = new StateMachine<IMaterialState>(stateRegistry, stateActivator);
            _materialStates = stateMachine;
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