using StateMachine.Interfaces;

namespace StateMachine.StateMachineSystems.StateActivatorSystem
{
    /// <summary>
    /// Defines the behavior for activating and deactivating states in a state machine.
    /// </summary>
    /// <typeparam name="T">The type of context used in the state.</typeparam>
    public interface IStateActivator<T>
    {
        /// <summary>
        /// Activates the specified state.
        /// </summary>
        /// <param name="state">The state to activate.</param>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        /// <para>This method triggers the <see cref="IState{T}.EnterState"/> method of the state.</para>
        /// <para><b>Note:</b> The state must be registered in the state registry before activation.</para>
        /// </remarks>
        void ActivateState(IState<T> state, T context);

        /// <summary>
        /// Deactivates the specified state.
        /// </summary>
        /// <param name="state">The state to deactivate.</param>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        /// <para>This method triggers the <see cref="IState{T}.ExitState"/> method of the state.</para>
        /// <para><b>Note:</b> The state remains active until its reference count (if applicable) reaches zero.</para>
        /// </remarks>
        void DeactivateState(IState<T> state, T context);

        /// <summary>
        /// Updates all active states.
        /// </summary>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        /// <para>This method triggers the <see cref="IState{T}.UpdateState"/> method for all active states.</para>
        /// </remarks>
        void UpdateStates(T context);
    }
}