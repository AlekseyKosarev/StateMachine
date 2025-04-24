namespace StateMachine.Interfaces
{
    /// <summary>
    /// Defines the behavior for managing a reference count in a state.
    /// </summary>
    /// <remarks>
    /// <para>This interface is used to implement reference counting for states. A state remains active as long as its reference count is greater than zero.</para>
    /// <para><b>Behavior:</b> Each call to <see cref="IncrementCount"/> increases the count, and each call to <see cref="DecrementCount"/> decreases it. The state is fully deactivated only when the count reaches zero.</para>
    /// </remarks>
    public interface ICounted
    {
        /// <summary>
        /// Gets the current reference count of the state.
        /// </summary>
        /// <value>The current reference count.</value>
        int Count { get;}

        /// <summary>
        /// Increments the reference count by one.
        /// </summary>
        /// <remarks>
        /// <para>This method is typically called when the state is activated.</para>
        /// </remarks>
        void IncrementCount();

        /// <summary>
        /// Decrements the reference count by one.
        /// </summary>
        /// <remarks>
        /// <para>This method is typically called when the state is deactivated.</para>
        /// <para><b>Note:</b> The state remains active until the count reaches zero.</para>
        /// </remarks>
        void DecrementCount();

        /// <summary>
        /// Resets the reference count to zero.
        /// </summary>
        /// <remarks>
        /// <para>This method can be used to force-deactivate the state.</para>
        /// </remarks>
        void ResetCount();
    }
}