using StateMachine.BasedState;
using UnityEngine;

namespace StateMachine.Example.MiniTest
{
    public class TwoState : BaseStateCounted<TestContext>
    {
        public override void Init(TestContext context)
        {
        }

        public override void EnterState(TestContext context)
        {
            base.EnterState(context);
            Debug.Log("Enter Two");
        }

        public override void ExitState(TestContext context)
        {
            Debug.Log("Exit Two");
        }

        public override void UpdateState(TestContext context)
        {
            // Debug.Log("UPD -------- One");
            // throw new NotImplementedException();
        }
    }
}