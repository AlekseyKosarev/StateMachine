using System;
using System.Collections.Generic;
using System.Linq;
using StateMachine.Interfaces;
using StateMachine.StateMachineSystems.StateActivatorSystem;
using StateMachine.StateMachineSystems.StateRegistrySystem;
using UnityEngine;

namespace StateMachine.StateMachineSystems
{
    /// <summary>
    ///     Base class for implementing finite state machines.
    /// </summary>
    /// <typeparam name="T">The type of context used in the state.</typeparam>
    public abstract class BaseStateMachine<T>
    {
        protected readonly List<IState<T>> _previousStates = new();
        protected readonly StateActivator<T> _stateActivator;
        protected readonly StateRegistry<T> _stateRegistry;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseStateMachine{T}" /> class.
        /// </summary>
        /// <param name="stateRegistry">The state registry.</param>
        /// <param name="stateActivator">The state activation system.</param>
        protected BaseStateMachine(StateRegistry<T> stateRegistry, StateActivator<T> stateActivator)
        {
            _stateRegistry = stateRegistry;
            _stateActivator = stateActivator;
        }

        /// <summary>
        ///     Adds a state to the registry.
        /// </summary>
        /// <typeparam name="TState">The type of the state to add.</typeparam>
        /// <param name="state">The state to add.</param>
        /// <remarks>
        ///     <para>This method delegates the call to <see cref="StateRegistry{T}.AddStateToRegistry" />.</para>
        ///     <para><b>Important:</b> Ensure that the state is not <c>null</c>.</para>
        /// </remarks>
        protected virtual void AddStateToRegistryBase<TState>(TState state) where TState : IState<T>
        {
            _stateRegistry.AddStateToRegistry(state);
        }

        /// <summary>
        ///     Activates or deactivates the specified state.
        /// </summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="setActive"><c>true</c> to activate the state; otherwise, <c>false</c>.</param>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        ///     <para>The method checks if the state exists in the registry before activation.</para>
        ///     <para><b>Important:</b> If the state is not found, the method exits without errors.</para>
        /// </remarks>
        protected virtual void SetStateActiveBase<TState>(bool setActive, T context) where TState : IState<T>
        {
            var state = GetStateFromRegistryBase<TState>();
            if (state == null) return;
            _stateActivator.SetStateActive(state, setActive, context);
        }

        /// <summary>
        ///     Switches the current state to the specified state.
        /// </summary>
        /// <typeparam name="TState">The type of the target state.</typeparam>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        ///     <para>The method checks if the state exists in the registry before switching.</para>
        ///     <para><b>Important:</b> If the state is not found, the method exits without errors.</para>
        /// </remarks>
        protected void SwitchToStateBase<TState>(T context) where TState : IState<T>
        {
            var state = GetStateFromRegistryBase<TState>();
            if (state == null) return;
            _stateActivator.SwitchToState(state, context);
        }
        
        /// <inheritdoc cref="StateActivator{T}.DeactivateAllStates" />
        protected void DeactivateAllStatesBase(T context)
        {
            _stateActivator.DeactivateAllStates(context);
        }
        
        /// <inheritdoc cref="StateActivator{T}.IsStateActive" />
        protected bool IsStateActiveBase(IState<T> state)
        {
            return _stateActivator.IsStateActive(state);
        }

        /// <summary>
        ///     Clears the list of previous states.
        /// </summary>
        private void ClearPreviousState()
        {
            _previousStates.Clear();
        }

        /// <summary>
        ///     Saves the currently active states into the list of previous states.
        /// </summary>
        protected void SaveCurrentStatesToPreviousBase()
        {
            _previousStates.AddRange(GetActiveStatesBase());
        }

        /// <summary>
        ///     Activates all saved previous states.
        /// </summary>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        ///     <para>After activating all states, the list of previous states is cleared.</para>
        /// </remarks>
        protected void ActivateAllPreviousStates(T context)
        {
            foreach (var state in _previousStates) _stateActivator.SetStateActive(state, true, context);
            ClearPreviousState();
        }

        /// <summary>
        ///     Retrieves a state from the registry by its type.
        /// </summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <returns>An instance of the state, or <c>null</c> if the state is not found.</returns>
        /// <remarks>
        ///     <para>If the state is not found, an error message is logged.</para>
        ///     <para><b>Important:</b> The method requires the state to be properly registered in the registry.</para>
        /// </remarks>
        protected IState<T> GetStateFromRegistryBase<TState>() where TState : IState<T>
        {
            var state = _stateRegistry.GetRegisteredStateByType<TState>();
            if (state == null)
            {
                Debug.LogError($"State of type {typeof(TState)} not found.");
                return null;
            }

            return state;
        }

        /// <inheritdoc cref="StateRegistry{T}.GetRegisteredStatesTypes" />
        protected IEnumerable<Type> GetStatesTypesBase()
        {
            return _stateRegistry.GetRegisteredStatesTypes();
        }

        /// <inheritdoc cref="StateRegistry{T}.GetRegisteredStates" />
        protected IEnumerable<IState<T>> GetStatesRegistryBase()
        {
            return _stateRegistry.GetRegisteredStates();
        }

        /// <inheritdoc cref="StateActivator{T}.GetActiveStates" />
        protected List<IState<T>> GetActiveStatesBase()
        {
            return _stateActivator.GetActiveStates().ToList();
        }

        /// <summary>
        ///     Updates all active states.
        /// </summary>
        /// <param name="context">The context of the state.</param>
        /// <inheritdoc cref="StateActivator{T}.UpdateStates" />
        public void UpdateStates(T context)
        {
            _stateActivator.UpdateStates(context);
        }
    }
}