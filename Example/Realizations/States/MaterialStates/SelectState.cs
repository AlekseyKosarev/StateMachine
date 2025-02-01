using UnityEngine;

namespace _Project.System.StateMachine.Example.Realizations.States.MaterialStates
{
    public class SelectState: BaseState<IMaterialState>
    {
        
        public override void EnterState(IMaterialState context)
        {
            
            Debug.Log("Entering Pause State");
        }

        public override void ExitState(IMaterialState context)
        {
            Debug.Log("Exiting Pause State");
        }

        public override void UpdateState(IMaterialState context)
        {
            Debug.Log("Updating Pause State");
        }
        // void InitBurnState()
        // {
        //     var stateRegistry = new StateRegistry<IGameState>();
        //     var stateActivator = new StateActivator<IGameState>();
        //
        //     var stateMachine = new StateMachine<IGameState>(stateRegistry, stateActivator);
        //     _globalStates = stateMachine;
        // }
    }
}