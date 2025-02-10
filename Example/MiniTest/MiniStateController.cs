using _Project.System.StateMachine.Example.EVENTS;
using _Project.System.StateMachine.Example.LevelBuilderSystem;
using _Project.System.StateMachine.StateMachine;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace _Project.System.StateMachine.Example.MiniTest
{
    public class MiniStateController: BaseInstance
    {
        private StateMachine<TestContext> _states;
        private TestContext _testContext;
        
        private void Awake()
        {
            _states = new StateMachineBuilder<TestContext>()
                .AddState(new OneState())
                .AddState(new TwoState())
                .Build();
        }
        
        private void Update()
        {
        }

        public override void OnGame()
        {
            _states.SetStateActive<OneState>(true, _testContext);
        }

        public override void OnPause()
        {
            _states.SwitchToState<TwoState>(_testContext);
        }
        
        // private void OnEnable()
        // {
        //     GameSwitch.OnGame += OnGame;
        //     GameSwitch.OnPause += OnPause;
        //     _testContext = new TestContext();
        // }
        //
        // private void OnDisable()
        // {
        //     GameSwitch.OnGame -= OnGame;
        //     GameSwitch.OnPause -= OnPause;
        // }
        public void Tick()
        {
            _states.Update(_testContext);

        }
    }
}