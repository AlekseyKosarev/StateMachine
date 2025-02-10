using _Project.System.StateMachine.Interfaces;
using NotImplementedException = System.NotImplementedException;

namespace _Project.System.StateMachine.Example.DirSimObj
{
    public class PauseState: IState<SimulateObj>
    {
        public void EnterState(SimulateObj context)
        {
            // throw new NotImplementedException();
        }

        public void ExitState(SimulateObj context)
        {
            // throw new NotImplementedException();
        }

        public void UpdateState(SimulateObj context)
        {
            // throw new NotImplementedException();
        }

        public uint Index { get; set; }
    }
}