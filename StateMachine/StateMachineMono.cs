// Managers/MonoStateMachine.cs

using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;
using UnityEngine;

namespace _Project.System.StateMachine.StateMachine
{
    public class StateMachineMono<T> : BaseStateMachine<T>
    {
        public StateMachineMono(StateRegistry<T> stateRegistry, StateActivator<T> stateActivator)
            : base(stateRegistry, stateActivator) { }

        public void AddStateToRegistryMono<TState>(TState state) where TState : MonoBehaviour, IState<T>
        {
            base.AddStateToRegistryBase(state);
        }

        public void SetStateActiveMono<TState>(bool setActive, T context) where TState : MonoBehaviour, IState<T>
        {
            // Call the base class method to handle state activation/deactivation
            base.SetStateActiveBase<TState>(setActive, context);

            // Handle MonoBehaviour-specific logic (enabling/disabling the component)
            //var state = GetStateFromRegistryMono<TState>();
            // if (context is MonoBehaviour monoBehaviour)
            // {
            //     monoBehaviour.enabled = setActive;
            // }
            //вопрос - зачем то, что выше?
            //
        }
        public IState<T> GetStateFromRegistryMono<TState>() where TState : MonoBehaviour, IState<T>
        {
            return base.GetStateFromRegistryBase<TState>();
        }
    }
}