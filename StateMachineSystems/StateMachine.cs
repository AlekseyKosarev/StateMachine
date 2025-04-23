using System;
using System.Collections.Generic;
using System.Linq;
using StateMachine.Interfaces;
using StateMachine.StateMachineSystems.StateActivatorSystem;
using StateMachine.StateMachineSystems.StateRegistrySystem;

namespace StateMachine.StateMachineSystems
{
    public class StateMachine<T> : BaseStateMachine<T>
    {
        public StateMachine(StateRegistry<T> stateRegistry, StateActivator<T> stateActivator)
            : base(stateRegistry, stateActivator)
        {
        }

        /// <summary>
        ///     Adds a state to the registry.
        /// </summary>
        /// <typeparam name="TState">The type of the state to add.</typeparam>
        /// <param name="state">The state to add.</param>
        /// <remarks>
        ///     <para>
        ///         This method is private because adding states after initializing <see cref="StateActivator{T}" /> may lead to
        ///         inconsistencies.
        ///     </para>
        ///     <para><b>Important:</b> States should be added before activating the state machine.</para>
        /// </remarks>
        private void AddStateToRegistry<TState>(TState state) where TState : IState<T>
        {
            base.AddStateToRegistryBase(state);
        }

        /// <summary>
        ///     Activates or deactivates the specified state.
        /// </summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="setActive"><c>true</c> to activate the state; otherwise, <c>false</c>.</param>
        /// <param name="context">The context of the state.</param>
        /// <inheritdoc cref="BaseStateMachine{T}.SetStateActiveBase{TState}" />
        public void SetStateActive<TState>(bool setActive, T context) where TState : IState<T>
        {
            base.SetStateActiveBase<TState>(setActive, context);
        }

        /// <summary>
        ///     Switches the current state to the specified state.
        /// </summary>
        /// <typeparam name="TState">The type of the target state.</typeparam>
        /// <param name="context">The context of the state.</param>
        /// <inheritdoc cref="BaseStateMachine{T}.SwitchToStateBase{TState}" />
        public void SwitchToState<TState>(T context) where TState : IState<T>
        {
            SwitchToStateBase<TState>(context);
        }

        /// <summary>
        ///     Deactivates all active states.
        /// </summary>
        /// <param name="context">The context of the state.</param>
        /// <inheritdoc cref="BaseStateMachine{T}.DeactivateAllStatesBase" />
        public void DeactivateAllStates(T context)
        {
            DeactivateAllStatesBase(context);
        }

        /// <summary>
        ///     Activates all previously saved states.
        /// </summary>
        /// <param name="context">The context of the state.</param>
        /// <inheritdoc cref="BaseStateMachine{T}.ActivateAllPreviousStates" />
        public void ActivatePreviousStates(T context)
        {
            ActivateAllPreviousStates(context);
        }

        /// <summary>
        ///     Saves the currently active states into the list of previous states.
        /// </summary>
        /// <inheritdoc cref="BaseStateMachine{T}.SaveCurrentStatesToPreviousBase" />
        public void SaveCurrentStatesToPrevious()
        {
            SaveCurrentStatesToPreviousBase();
        }

        /// <summary>
        ///     Checks if the specified state is active.
        /// </summary>
        /// <param name="state">The state to check.</param>
        /// <returns><c>true</c> if the state is active; otherwise, <c>false</c>.</returns>
        /// <inheritdoc cref="BaseStateMachine{T}.IsStateActiveBase" />
        public bool IsStateActive(IState<T> state)
        {
            return IsStateActiveBase(state);
        }

        /// <summary>
        ///     Checks if any state of the specified type is active.
        /// </summary>
        /// <typeparam name="TState">The type of the state to check.</typeparam>
        /// <returns><c>true</c> if a state of the specified type is active; otherwise, <c>false</c>.</returns>
        public bool IsStateActiveOfType<TState>() where TState : IState<T>
        {
            var state = GetStateFromRegistry<TState>();
            return IsStateActive(state);
        }

        /// <summary>
        ///     Retrieves a state from the registry by its type.
        /// </summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <returns>An instance of the state, or <c>null</c> if the state is not found.</returns>
        /// <inheritdoc cref="BaseStateMachine{T}.GetStateFromRegistryBase{TState}" />
        public IState<T> GetStateFromRegistry<TState>() where TState : IState<T>
        {
            return GetStateFromRegistryBase<TState>();
        }

        /// <summary>
        ///     Retrieves all registered state types.
        /// </summary>
        /// <returns>A list of registered state types.</returns>
        /// <inheritdoc cref="BaseStateMachine{T}.GetStatesTypesBase" />
        public List<Type> GetStatesTypes()
        {
            return GetStatesTypesBase().ToList();
        }

        /// <summary>
        ///     Retrieves all registered states.
        /// </summary>
        /// <returns>A list of registered states.</returns>
        /// <inheritdoc cref="BaseStateMachine{T}.GetStatesRegistryBase" />
        public List<IState<T>> GetStatesRegistry()
        {
            return GetStatesRegistryBase().ToList();
        }

        /// <summary>
        ///     Retrieves all currently active states.
        /// </summary>
        /// <returns>A list of active states.</returns>
        /// <inheritdoc cref="BaseStateMachine{T}.GetActiveStatesBase" />
        public List<IState<T>> GetActiveStates()
        {
            return GetActiveStatesBase();
        }

        /// <summary>
        ///     Retrieves the indices of all currently active states.
        /// </summary>
        /// <returns>An array of active state indices.</returns>
        public int[] GetActiveStatesIndexes()
        {
            return _stateActivator.GetActiveStatesIndexes();
        }

        /// <summary>
        ///     Retrieves the types of all currently active states.
        /// </summary>
        /// <returns>A list of active state types.</returns>
        /// <remarks>
        ///     <para>This method maps active state indices to their corresponding types.</para>
        ///     <para><b>Note:</b> The order of types corresponds to the order of active states.</para>
        /// </remarks>
        public List<Type> GetActiveStatesTypes()
        {
            var allTypes = GetStatesTypes();
            var activeStates = GetActiveStatesIndexes();

            var types = new List<Type>(activeStates.Length);
            foreach (var index in activeStates) types.Add(allTypes[index]);

            return types;
        }
    }
}