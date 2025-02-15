using StateMachineTools.Example.LevelBuilderSystem;
using StateMachineTools.StateMachine;

namespace StateMachineTools.Example.MiniTest
{
    public class MiniStateController : BaseInstance
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
            Tick();
        }

        public override void OnGame()
        {
            _states.SetStateActive<OneState>(true, _testContext);
        }

        public override void OnPause()
        {
            _states.SwitchToState<TwoState>(_testContext);
        }
        public void Tick()
        {
            _states.Update(_testContext);
        }
    }
}