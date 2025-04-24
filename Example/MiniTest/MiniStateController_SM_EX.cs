using StateMachine.Example.LevelBuilderSystem;
using StateMachine.Systems;

namespace StateMachine.Example.MiniTest
{
    public class MiniStateController_SM_EX : BaseInstance_SM_EX
    {
        private StateMachine<TestContext_SM_EX> _states;
        private TestContext_SM_EX _testContextSmEx;

        private void Awake()
        {
            _states = new StateMachineBuilder<TestContext_SM_EX>()
                .AddStates(new OneState_SM_EX(), new TwoState_SM_EX())
                .Build();

            _states.SetStateActive<OneState_SM_EX>(true, _testContextSmEx);
            _states.SetStateActive<TwoState_SM_EX>(true, _testContextSmEx);
        }

        private void Update()
        {
            Tick();
        }

        public override void OnGame()
        {
            _states.SetStateActive<OneState_SM_EX>(false, _testContextSmEx);
            _states.SetStateActive<TwoState_SM_EX>(false, _testContextSmEx);
        }

        public override void OnPause()
        {
            _states.SetStateActive<OneState_SM_EX>(true, _testContextSmEx);
            _states.SetStateActive<TwoState_SM_EX>(true, _testContextSmEx);
        }

        public void Tick()
        {
            _states.UpdateStates(_testContextSmEx);
        }
    }
}