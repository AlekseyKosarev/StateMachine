using _Project.System.StateMachine.Example.MonoBehaviorStates;
using _Project.System.StateMachine.StateMachine;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;
using UnityEngine;

namespace _Project.System.StateMachine.Example.Realizations.States.MaterialStates
{
    public class SimulateState: BaseState<IMaterialState>
    {
        StateMachineMono<IEffectStates> _effectStates; // для всех эффектов нужен свой интерфейс! 
        BurnStateMono _burnStateMono;
        public override void EnterState(IMaterialState context)
        {
            _burnStateMono = context.State as BurnStateMono;
            InitGame();
            _effectStates.AddStateToRegistryMono(_burnStateMono);
            Debug.Log("SimulateState = " + _effectStates.GetStateFromRegistryMono<BurnStateMono>());
        
            _effectStates.SetStateActiveMono<BurnStateMono>(true, null);
        }

        public override void ExitState(IMaterialState context)
        {
            //_effectStates.SetStateActiveMono<BurnStateMono>(false, null);
            Debug.Log("Exiting SimulateState");
        }

        public override void UpdateState(IMaterialState context)
        {
            _effectStates.Update(null);
            Debug.Log("Updating SimulateState");
        }
        void InitGame()
        {
            // var stateRegistry = new StateRegistry<IEffectStates>();
            // var stateActivator = new StateActivator<IEffectStates>();
            //
            // var stateMachine = new StateMachineMono<IEffectStates>(stateRegistry, stateActivator);
            // _effectStates = stateMachine;
        }
    }
}