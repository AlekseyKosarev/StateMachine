using StateMachine.Interfaces;

namespace StateMachine.StateMachineSystems.StateRegistrySystem
{
    /// <summary>
    /// Defines the behavior for managing the registration and retrieval of states in a state machine.
    /// </summary>
    /// <typeparam name="T">The type of context used in the state.</typeparam>
    public interface IStateRegistry<T>
    {
        /// <summary>
        /// Adds a state to the registry.
        /// </summary>
        /// <typeparam name="TState">The type of the state to add.</typeparam>
        /// <param name="state">The state to register.</param>
        /// <remarks>
        /// <para><b>Important:</b> Adding duplicate states may lead to undefined behavior.</para>
        /// </remarks>
        void AddState<TState>(TState state) where TState : IState<T>;

        /// <summary>
        /// Checks if a state of the specified type is registered.
        /// </summary>
        /// <typeparam name="TState">The type of the state to check.</typeparam>
        /// <returns><c>true</c> if the state is registered; otherwise, <c>false</c>.</returns>
        bool ContainsState<TState>() where TState : IState<T>;

        /// <summary>
        /// Retrieves a registered state by its type.
        /// </summary>
        /// <typeparam name="TState">The type of the state to retrieve.</typeparam>
        /// <returns>The registered state, or <c>null</c> if the state is not found.</returns>
        IState<T> GetState<TState>() where TState : IState<T>;

        /// <summary>
        /// Removes a state from the registry.
        /// </summary>
        /// <typeparam name="TState">The type of the state to remove.</typeparam>
        /// <remarks>
        /// <para><b>Warning:</b> Removing an active state may lead to inconsistent behavior.</para>
        /// </remarks>
        void RemoveState<TState>() where TState : IState<T>;
    }
}