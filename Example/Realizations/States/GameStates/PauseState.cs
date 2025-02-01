using UnityEngine;

namespace _Project.System.StateMachine.Example.Realizations.States.GameStates
{
    public class PauseState : BaseState<IGameState>
    {
        public override void EnterState(IGameState context)
        {
            Debug.Log("Entering Pause State");
        }

        public override void ExitState(IGameState context)
        {
            Debug.Log("Exiting Pause State");
        }

        public override void UpdateState(IGameState context)
        {
            Debug.Log("Updating Pause State");
        }
    }
}