using StateMachine.BitMaskArray;
using StateMachine.Interfaces;

namespace StateMachine.Example.MiniTest
{
    public class TwoState : IState<TestContext>
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
            if(IsCounted) Count = 0;
        }

        public bool IsCountZero()
        {
            if(IsCounted) return Count == 0;
            return true;
        }
    }
}