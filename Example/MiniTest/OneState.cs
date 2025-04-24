using StateMachine.BasedState;
using UnityEngine;

namespace StateMachine.Example.MiniTest
{
    public class OneState : BaseState<TestContext>
    {
        public override void Init(TestContext context)
        {
        }

        public override void EnterState(TestContext context)
        {
            base.EnterState(context);
            Debug.Log("Enter One");
        }

        public override void ExitState(TestContext context)
        {
            Debug.Log("Exit One");
        }

        public override void UpdateState(TestContext context)
        {
            // Debug.Log("UPD -------- One");
            // throw new NotImplementedException();
        }
    }
}