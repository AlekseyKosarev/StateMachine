using UnityEngine;

namespace _Project.System.StateMachine.Example.Realizations.States.GameStates
{
    public class InGameState : BaseState<IGameState>
    {
        public override void EnterState(IGameState context)
        {
            Debug.Log("Entering InGame State");
        }

        public override void ExitState(IGameState context)
        {
            Debug.Log("Exiting InGame State");
        }

        public override void UpdateState(IGameState context)
        {
            Debug.Log("Updating InGame State");
        }
    }
}