using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;
using UnityEngine;

namespace _Project.System.StateMachine.StateMachine
{
    public abstract class BaseStateMachine<T>
    {
        protected readonly StateRegistry<T> _stateRegistry;
        protected readonly StateActivator<T> _stateActivator;

        protected BaseStateMachine(StateRegistry<T> stateRegistry, StateActivator<T> stateActivator)
        {
            _stateRegistry = stateRegistry;
            _stateActivator = stateActivator;
        }

        protected virtual void AddStateToRegistryBase<TState>(TState state) where TState : IState<T>
        {
            _stateRegistry.AddStateToRegistry(state);
        }

        protected void RemoveStateFromRegistryBase<TState>() where TState : IState<T>
        {
            _stateRegistry.RemoveStateFromRegistry<TState>();
        }

        protected virtual void SetStateActiveBase<TState>(bool setActive, T context) where TState : IState<T>
        {
            var state = GetStateFromRegistryBase<TState>();
            if (state == null)
            {
                return;
            }
            _stateActivator.ChangeStatusState(state, setActive, context);
        }
        
        protected void SwitchToStateBase<TState>(T context) where TState : IState<T>
        {
            var state = GetStateFromRegistryBase<TState>();
            if (state == null)
            {
                return;
            }
            _stateActivator.SwitchToState<TState>(state, context);
        }

        protected bool IsStateActiveBase<TState>() where TState : IState<T>
        {
            var status = _stateActivator.IsStateActive<TState>();
            return status;
        }

        protected IState<T> GetStateFromRegistryBase<TState>() where TState : IState<T>
        {
            var state = _stateRegistry.GetStateFromRegistry<TState>();;
            if (state == null)
            {
                Debug.LogError($"State of type {typeof(TState)} not found.");
                return null;
            }

            return state;
        }
        /// <summary>
        /// Updates all active states.
        /// </summary>
        /// <param name="context">The context passed to the state.</param>
        public void Update(T context)
        {
            _stateActivator.Update(context);
        }
    }
}