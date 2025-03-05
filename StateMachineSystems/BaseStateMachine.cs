using System;
using System.Collections.Generic;
using System.Linq;
using StateMachine.Interfaces;
using StateMachine.StateMachineSystems.StateActivatorSystem;
using StateMachine.StateMachineSystems.StateRegistrySystem;
using UnityEngine;

namespace StateMachine.StateMachineSystems
{
    public abstract class BaseStateMachine<T>
    {
        protected readonly StateActivator<T> _stateActivator;
        protected readonly StateRegistry<T> _stateRegistry;
        
        protected readonly List<IState<T>> _previousStates = new List<IState<T>>();

        protected BaseStateMachine(StateRegistry<T> stateRegistry, StateActivator<T> stateActivator)
        {
            _stateRegistry = stateRegistry;
            _stateActivator = stateActivator;
        }

        protected virtual void AddStateToRegistryBase<TState>(TState state) where TState : IState<T>
        {
            _stateRegistry.AddStateToRegistry(state);
        }

        protected virtual void SetStateActiveBase<TState>(bool setActive, T context) where TState : IState<T>
        {
            var state = GetStateFromRegistryBase<TState>();
            if (state == null) return;
            _stateActivator.SetStateActive(state, setActive, context);
        }

        protected void SwitchToStateBase<TState>(T context) where TState : IState<T>
        {
            var state = GetStateFromRegistryBase<TState>();
            if (state == null) return;
            _stateActivator.SwitchToState(state, context);
        }
        protected void DeactivateAllStatesBase(T context) => _stateActivator.DeactivateAllStates(context);

        protected bool IsStateActiveBase(IState<T> state)
        {
            return _stateActivator.IsStateActive(state);
        }
        private void ClearPreviousState() => _previousStates.Clear();
        protected void SaveCurrentStatesToPreviousBase() => _previousStates.AddRange(GetActiveStatesBase());

        protected void ActivateAllPreviousStates(T context)
        {
            foreach (var state in _previousStates)
            {
                _stateActivator.SetStateActive(state, true, context);
            }
            ClearPreviousState();
        }

        protected IState<T> GetStateFromRegistryBase<TState>() where TState : IState<T>
        {
            var state = _stateRegistry.GetStateFromRegistry<TState>();
            if (state == null)
            {
                Debug.LogError($"State of type {typeof(TState)} not found.");
                return null;
            }

            return state;
        }

        protected List<Type> GetStatesTypesBase() => _stateRegistry.GetStatesTypesBase();
        protected List<IState<T>> GetStatesRegistryBase() => _stateRegistry.GetStatesBase();
        protected List<IState<T>> GetActiveStatesBase() => _stateActivator.GetActiveStates().ToList();

        public void Update(T context)
        {
            _stateActivator.Update(context);
        }
    }
}