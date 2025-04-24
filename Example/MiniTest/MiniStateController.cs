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
            _states = new StateMachineBuilder<TestContext>()
                .AddStates(new OneState(), new TwoState())
                .Build();
            
            _states.SetStateActive<OneState>(true, _testContext);
            _states.SetStateActive<TwoState>(true, _testContext);
        }

        private void Update()
        {
            Tick();
        }

        public override void OnGame()
        {
            _states.SetStateActive<OneState>(false, _testContext);
            _states.SetStateActive<TwoState>(false, _testContext);
        }

        public override void OnPause()
        {
            _states.SetStateActive<OneState>(true, _testContext);
            _states.SetStateActive<TwoState>(true, _testContext);
        }

        public void Tick()
        {
            _states.UpdateStates(_testContext);
        }
    }
}