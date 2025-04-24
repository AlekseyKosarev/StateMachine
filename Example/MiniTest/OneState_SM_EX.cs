using StateMachine.BasedState;
using UnityEngine;

namespace StateMachine.Example.MiniTest
{
    public class OneState_SM_EX : BaseState<TestContext_SM_EX>
    {
        public override void Init(TestContext_SM_EX contextSmEx)
        {
        }

        public override void EnterState(TestContext_SM_EX contextSmEx)
        {
            base.EnterState(contextSmEx);
            Debug.Log("Enter One");
        }

        public override void ExitState(TestContext_SM_EX contextSmEx)
        {
            Debug.Log("Exit One");
        }

        public override void UpdateState(TestContext_SM_EX contextSmEx)
        {
            // Debug.Log("UPD -------- One");
            // throw new NotImplementedException();
        }
    }
}