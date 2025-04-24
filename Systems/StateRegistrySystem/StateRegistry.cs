using System;
using System.Collections.Generic;
using StateMachine.Interfaces;

namespace StateMachine.Systems.StateRegistrySystem
{
    /// <summary>
    ///     Represents a registry of states for an object.
    /// </summary>
    /// <typeparam name="T">The type of object that the states belong to.</typeparam>
    public class StateRegistry<T>
    {
        private readonly Dictionary<Type, IState<T>> _states = new();

        /// <summary>
        ///     Adds a state to the state registry.
        /// </summary>
        /// <param name="state">The state to add to the registry.</param>
        /// <remarks>
        ///     The state is registered using its type as the key, allowing it to be retrieved later by its type.
        /// </remarks>
        public void AddStateToRegistry(IState<T> state)
        {
            _states[state.GetType()] = state;
        }

        /// <summary>
        ///     Checks whether the state registry contains a state of the given type.
        /// </summary>
        /// <typeparam name="TState">The type of the state to check for.</typeparam>
        /// <returns><c>true</c> if the state registry contains a state of the given type; otherwise <c>false</c>.</returns>
        public bool ContainsStateInRegistry<TState>() where TState : IState<T>
        {
            return _states.ContainsKey(typeof(TState));
        }

        /// <summary>
        ///     Retrieves a state from the registry by its type.
        /// </summary>
        /// <typeparam name="TState">The type of state to retrieve.</typeparam>
        /// <returns>The state instance if found, otherwise default.</returns>
        public IState<T> GetRegisteredStateByType<TState>() where TState : IState<T>
        {
            return _states.GetValueOrDefault(typeof(TState));
        }

        /// <summary>
        ///     Gets the types of states that are currently registered in the state registry.
        /// </summary>
        /// <returns>A collection of state types.</returns>
        public IEnumerable<Type> GetRegisteredStatesTypes()
        {
            return _states.Keys;
        }

        /// <summary>
        ///     Gets the states that are currently registered.
        /// </summary>
        /// <returns>A collection of state instances.</returns>
        public IEnumerable<IState<T>> GetRegisteredStates()
        {
            return _states.Values;
        }
    }
}