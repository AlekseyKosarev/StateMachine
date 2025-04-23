using System.Linq;
using StateMachine.Interfaces;
using StateMachine.StateMachineSystems.StateActivatorSystem;
using StateMachine.StateMachineSystems.StateRegistrySystem;

namespace StateMachine.StateMachineSystems
{
    public class StateMachineBuilder<T>
    {
        private readonly StateRegistry<T> _stateRegistry;
        private StateActivator<T> _stateActivator;
        private StateMachine<T> _stateMachine;

        public StateMachineBuilder()
        {
            _stateRegistry = new StateRegistry<T>();
        }

        /// <summary>
        ///     Adds multiple states to the state registry.
        /// </summary>
        /// <param name="states">An array of states implementing the <see cref="IState{T}" /> interface.</param>
        /// <returns>The current <see cref="StateMachineBuilder{T}" /> instance for method chaining.</returns>
        public StateMachineBuilder<T> AddStates(params IState<T>[] states)
        {
            foreach (var state in states) _stateRegistry.AddStateToRegistry(state);
            return this;
        }

        /// <summary>
        ///     Adds a single state to the state registry.
        /// </summary>
        /// <typeparam name="TState">The type of the state to add, which must implement the <see cref="IState{T}" /> interface.</typeparam>
        /// <param name="state">The state to add to the registry.</param>
        /// <returns>The current <see cref="StateMachineBuilder{T}" /> instance for method chaining.</returns>
        public StateMachineBuilder<T> AddState<TState>(TState state) where TState : IState<T>
        {
            _stateRegistry.AddStateToRegistry(state);
            return this;
        }

        /// <summary>
        ///     Builds and returns the configured <see cref="StateMachine{T}" /> instance.
        /// </summary>
        /// <returns>A fully configured <see cref="StateMachine{T}" /> instance.</returns>
        public StateMachine<T> Build()
        {
            _stateActivator = new StateActivator<T>(_stateRegistry.GetRegisteredStates().ToArray());
            _stateMachine = new StateMachine<T>(_stateRegistry, _stateActivator);
            return _stateMachine;
        }
    }
}