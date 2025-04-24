using StateMachine.BasedState;
using UnityEngine;

namespace StateMachine.Example.MiniTest
{
    public class TwoState_SM_EX : BaseStateCounted<TestContext_SM_EX>
    {
        public override void Init(TestContext_SM_EX contextSmEx)
        {
        }

        public override void EnterState(TestContext_SM_EX contextSmEx)
        {
            base.EnterState(contextSmEx);
            Debug.Log("Enter Two");
        }

        public override void ExitState(TestContext_SM_EX contextSmEx)
        {
            Debug.Log("Exit Two");
        }

        public override void UpdateState(TestContext_SM_EX contextSmEx)
        {
            // Debug.Log("UPD -------- One");
            // throw new NotImplementedException();
        }
    }
}