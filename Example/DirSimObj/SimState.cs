using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine;
using UnityEngine;

namespace _Project.System.StateMachine.Example.DirSimObj
{
    public class SimState: IState<SimulateObj>
    {
        private StateMachineMono<SimulateData> _simulateStates;
        private SimulateData _simulateData = new SimulateData(Vector2.zero);
        
        
        private void InitStateMachine(SimulateObj context)
        {
            var builder = new StateMachineMonoBuilder<SimulateData>()
                .AddState(context.WalkState)
                .AddState(context.IdleState);

            _simulateStates = builder.Build();
        }
        public void EnterState(SimulateObj context)
        {
            if(_simulateStates == null) InitStateMachine(context);
            // throw new NotImplementedException();
        }

        public void ExitState(SimulateObj context)
        {
            // throw new NotImplementedException();
        }

        public void UpdateState(SimulateObj context)
        {
            if(Input.anyKey)
            {
                var dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                _simulateData.Dir = dir;
                _simulateStates.SwitchToStateMono<WalkState>(_simulateData);
            }
            else
            {
                _simulateStates.SwitchToStateMono<IdleState>(_simulateData);
            }
            _simulateStates.Update(_simulateData);
        }
    }
}