using StateMachine.BitMaskArray;
using StateMachine.Interfaces;
using UnityEngine;

namespace StateMachine.Example.MiniTest
{
    public class OneState : IState<TestContext>
    {
        public void EnterState(TestContext context)
        {
            // throw new NotImplementedException();
        }

        public void ExitState(TestContext context)
        {
            // throw new NotImplementedException();
        }

        public void UpdateState(TestContext context)
        {
            Debug.Log("UPD -------- One");
            // throw new NotImplementedException();
        }

        public uint Index { get; set; }
        public bool IsCounted { get; set; }
        public int Count { get; private set; }

        public void IncrementCount()
        {
            if(IsCounted) Count++;
        }

        public void DecrementCount()
        {
            if(IsCounted) Count--;
        }

        public void ResetCount()
        {
            Count = 0;
        }
        public bool IsCountZero()
        {
            return Count == 0;
        }
    }
}