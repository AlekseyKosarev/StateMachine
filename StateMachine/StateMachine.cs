using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;

namespace _Project.System.StateMachine.StateMachine
{
    public class StateMachine<T>: BaseStateMachine<T>
    {
        public StateMachine(StateRegistry<T> stateRegistry, StateActivator<T> stateActivator)
            : base(stateRegistry, stateActivator) { }
        /// <summary>
        /// Adds a state to the registry.
        /// </summary>
        /// <typeparam name="TState">The type of the state, which must implement IState<T>.</typeparam>
        /// <param name="state">The state to add to the registry.</param>
        public void AddStateToRegistry<TState>(TState state) where TState : IState<T>
        {
            base.AddStateToRegistryBase(state);
        }

        /// <summary>
        /// Removes a state from the registry.
        /// </summary>
        /// <typeparam name="TState">The type of the state to remove.</typeparam>
        public void RemoveStateFromRegistry<TState>() where TState : IState<T>
        {
            base.RemoveStateFromRegistryBase<TState>();
        }

        /// <summary>
        /// Activates or deactivates a state.
        /// </summary>
        /// <typeparam name="TState">The type of the state to activate/deactivate.</typeparam>
        /// <param name="setActive">True to activate the state, false to deactivate it.</param>
        /// <param name="context">The context passed to the state.</param>
        public void SetStateActive<TState>(bool setActive, T context) where TState : IState<T>
        {
            base.SetStateActiveBase<TState>(setActive, context);
        }

        /// <summary>
        /// Switches to a specific state.
        /// </summary>
        /// <typeparam name="TState">The type of the state to switch to.</typeparam>
        /// <param name="context">The context passed to the state.</param>
        public void SwitchToState<TState>(T context) where TState : IState<T>
        {
            base.SwitchToStateBase<TState>(context);
        }

        /// <summary>
        /// Checks if a specific state is active.
        /// </summary>
        /// <typeparam name="TState">The type of the state to check.</typeparam>
        /// <returns>True if the state is active, otherwise false.</returns>
        public bool IsStateActive<TState>() where TState : IState<T>
        {
            return base.IsStateActiveBase<TState>();
        }
        
        public IState<T> GetStateFromRegistry<TState>() where TState : IState<T>
        {
            return base.GetStateFromRegistryBase<TState>();
        }
    }
}