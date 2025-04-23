namespace StateMachine.Interfaces
{
    /// <summary>
    /// Defines the behavior of a state in a finite state machine.
    /// </summary>
    /// <typeparam name="T">The type of context used in the state.</typeparam>
    public interface IState<T> : IIndexed, ICounted
    {
        /// <summary>
        /// Called when the state is activated.
        /// </summary>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        /// <para>This method is triggered by the <see cref="IStateActivator{T}.ActivateState"/> method.</para>
        /// </remarks>
        void EnterState(T context);

        /// <summary>
        /// Called when the state is deactivated.
        /// </summary>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        /// <para>This method is triggered by the <see cref="IStateActivator{T}.DeactivateState"/> method.</para>
        /// <para><b>Note:</b> The state remains active until its reference count (defined in <see cref="ICounted"/>) reaches zero.</para>
        /// </remarks>
        void ExitState(T context);

        /// <summary>
        /// Called to update the state during each frame or cycle.
        /// </summary>
        /// <param name="context">The context of the state.</param>
        /// <remarks>
        /// <para>This method is triggered by the <see cref="IStateActivator{T}.UpdateStates"/> method.</para>
        /// </remarks>
        void UpdateState(T context);
    }
}