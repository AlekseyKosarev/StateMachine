using StateMachineTools.BitMaskArray;
using StateMachineTools.Interfaces;

namespace StateMachineTools.Example.MiniTest
{
    public class OneState : IState<TestContext>, IIndexed
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
    }
}