using StateMachine.Example.LevelBuilderSystem;
using StateMachine.Interfaces;
using StateMachine.StateMachineSystems;
using UnityEngine;

namespace StateMachine.Example.MiniTest
{
    public class MiniStateController : BaseInstance
    {
        private StateMachine<TestContext> _states;
        private TestContext _testContext;

        private void Awake()
        {
            // _states = new StateMachineBuilder<TestContext>()
            //     .AddState(new OneState())
            //     .AddState(new TwoState())
            //     .Build();
            
            _states = new StateMachineBuilder<TestContext>()
                .AddStates(new OneState(), new TwoState())
                .Build();
            
            var st = _states.GetStatesRegistry();
            Debug.Log(st.Count);
            Debug.Log(st[0].GetType().Name);
        }

        private void Update()
        {
            Tick();
        }

        public override void OnGame()
        {
            _states.SwitchToState<OneState>(_testContext);
        }

        public override void OnPause()
        {
            _states.SwitchToState<TwoState>(_testContext);
        }
        public void Tick()
        {
            _states.UpdateStates(_testContext);
        }
    }
}