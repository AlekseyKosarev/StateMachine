using _Project.System.StateMachine.Interfaces;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace _Project.System.StateMachine.Example.DirSimObj
{
    public class WalkState: MonoBehaviour, IState<SimulateData>
    {
        public void EnterState(SimulateData context)
        {
            // throw new NotImplementedException();
        }

        public void ExitState(SimulateData context)
        {
            // throw new NotImplementedException();
        }

        public void UpdateState(SimulateData context)
        {
            // Debug.Log(context.Dir);
        }
    }
}