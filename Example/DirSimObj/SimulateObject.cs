using _Project.System.StateMachine.Example.EVENTS;
using _Project.System.StateMachine.StateMachine;
using UnityEngine;

namespace _Project.System.StateMachine.Example.DirSimObj
{
    public class SimulateObject: MonoBehaviour
    {
        private StateMachine<SimulateObj> _states;
        private SimulateObj _simulateObj;
        
        public void Awake()
        {
            _simulateObj = new SimulateObj();
            _simulateObj.WalkState = GetComponent<WalkState>();
            _simulateObj.IdleState = GetComponent<IdleState>();
            
            _simulateObj.WalkStateCopy = _simulateObj.WalkState;
            _simulateObj.IdleStateCopy = _simulateObj.IdleState;
            
            var builder = new StateMachineBuilder<SimulateObj>()
                .AddState(new SimState())
                .AddState(new PauseState());
            _states = builder.Build();
        }

        private void OnEnable()
        {
            GameSwitch.OnGame += ActivateSimulate;
            GameSwitch.OnPause += ActivatePause;
        }

        private void OnDisable()
        {
            GameSwitch.OnGame -= ActivateSimulate;
            GameSwitch.OnPause -= ActivatePause;
        }

        private void ActivateSimulate()
        {
            _states.SwitchToState<SimState>(_simulateObj);
        }

        private void ActivatePause()
        {
            _states.SwitchToState<PauseState>(_simulateObj);
        }

        private void Update()
        {
            _states.Update(_simulateObj);
        }
    }
}