using StateMachine.BitMaskArray;
using StateMachine.Interfaces;

namespace StateMachine.StateMachineSystems.StateActivatorSystem
{
    /// <summary>
    ///     This class is responsible for switching between states and updating them.
    /// </summary>
    /// <typeparam name="T">The type of the context object that the states belong to.</typeparam>
    public class StateActivator<T> : IStateActivator<T>
    {
        private readonly MaskArray _activeStates;
        private readonly IState<T>[] _all;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StateActivator{T}" /> class.
        /// </summary>
        /// <param name="states">
        ///     An array of all possible states. Important: After initialization, adding new states is not
        ///     allowed.
        /// </param>
        public StateActivator(IState<T>[] states)
        {
            _activeStates = new MaskArray(states);
            _all = states;
        }

        /// <summary>
        ///     Activates the specified state.
        /// </summary>
        /// <param name="state">The state to activate.</param>
        /// <param name="context">The context object passed to the state.</param>
        /// <remarks>
        ///     <para>Cannot activate an already active state.</para>
        ///     <para>
        ///         If state inherits from <see cref="ICounted" />, the activation counter is incremented by 1 regardless of the current state.
        ///     </para>
        /// </remarks>
        public void ActivateState(IState<T> state, T context)
        {
            if (state is ICounted countedState)
                countedState.IncrementCount();
            if (_activeStates.Contains(state.GetIndex())) return;

            _activeStates.Add(state.GetIndex());
            state.EnterState(context);
        }

        /// <summary>
        ///     Deactivates the specified state.
        /// </summary>
        /// <param name="state">The state to deactivate.</param>
        /// <param name="context">The context object passed to the state.</param>
        /// <remarks>
        ///     <para>If the state is not active, this method does nothing.</para>
        ///     <para>
        ///         If state inherits from <see cref="ICounted" />, the activation counter is decremented.
        ///     <para>The state is deactivated only if the counter reaches zero.</para>
        ///     </para>
        /// </remarks>
        public void DeactivateState(IState<T> state, T context)
        {
            if (!_activeStates.Contains(state.GetIndex())) return;
            if (state is ICounted countedState)
            {
                countedState.DecrementCount();
                if (countedState.Count != 0) return;
            }

            _activeStates.Remove(state.GetIndex());
            state.ExitState(context);
        }

        /// <summary>
        ///     Updates all currently active states by invoking their <see cref="IState{T}.UpdateState" /> methods.
        /// </summary>
        /// <param name="context">The context object passed to the states.</param>
        public void UpdateStates(T context)
        {
            var indexesActiveStates = GetActiveStatesIndexes();
            foreach (var state in indexesActiveStates) _all[state].UpdateState(context);
        }

        /// <summary>
        ///     Deactivates all currently active states.
        /// </summary>
        /// <param name="context">The context object passed to the states.</param>
        /// <remarks>
        ///     <para>Clears the mask of active states.</para>
        ///     <para>
        ///         Resets the activation counter for states that inherit from <see cref="ICounted" /> 
        ///     </para>
        /// </remarks>
        public void DeactivateAllStates(T context)
        {
            foreach (var state in GetActiveStatesIndexes())
            {
                if (_all[state] is ICounted countedState)
                    countedState.ResetCount();
                _all[state].ExitState(context);
            }

            _activeStates.ClearMask();
        }

        /// <summary>
        ///     Sets the specified state as active or inactive based on the provided flag.
        /// </summary>
        /// <param name="state">The state to modify.</param>
        /// <param name="setActive">A flag indicating whether to activate (<c>true</c>) or deactivate (<c>false</c>) the state.</param>
        /// <param name="context">The context object passed to the state.</param>
        public void SetStateActive(IState<T> state, bool setActive, T context)
        {
            if (setActive)
                ActivateState(state, context);
            else
                DeactivateState(state, context);
        }

        /// <summary>
        ///     Switches to the specified state by deactivating all other states and activating the target state.
        /// </summary>
        /// <param name="state">The state to switch to.</param>
        /// <param name="context">The context object passed to the state.</param>
        /// <remarks>
        ///     <para>If the target state is already active, this method does nothing.</para>
        /// </remarks>
        public void SwitchToState(IState<T> state, T context)
        {
            if (IsStateActive(state)) return;
            DeactivateAllStates(context);
            ActivateState(state, context);
        }

        /// <summary>
        ///     Determines whether the specified state is currently active.
        /// </summary>
        /// <param name="state">The state to check.</param>
        /// <returns><c>true</c> if the state is active; otherwise, <c>false</c>.</returns>
        public bool IsStateActive(IState<T> state)
        {
            return _activeStates.Contains(state.GetIndex());
        }

        /// <summary>
        ///     Retrieves an array of all currently active states.
        /// </summary>
        /// <returns>An array of active states.</returns>
        public IState<T>[] GetActiveStates()
        {
            var indexesActiveStates = GetActiveStatesIndexes();
            var currentActiveStates = new IState<T>[indexesActiveStates.Length];
            for (var i = 0; i < indexesActiveStates.Length; i++) currentActiveStates[i] = _all[indexesActiveStates[i]];

            return currentActiveStates;
        }

        /// <summary>
        ///     Retrieves an array of indices representing the currently active states.
        /// </summary>
        /// <returns>An array of indices of active states.</returns>
        public int[] GetActiveStatesIndexes()
        {
            return _activeStates.GetIndexesFromMask();
        }
    }
}