using _Project.System.StateMachine.BitMaskArray;
using _Project.System.StateMachine.Interfaces;

namespace _Project.System.StateMachine.Example.MiniTest
{
    public class TwoState: IState<TestContext>, IIndexed
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