using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;
using UnityEngine;

namespace _Project.System.StateMachine.StateMachine
{
    public class StateMachineBuilder<T>
    {
        private StateRegistry<T> _stateRegistry;
        private StateActivator<T> _stateActivator;
        private StateMachine<T> _stateMachine;

        public StateMachineBuilder<T> Init()
        {
            _stateRegistry = new StateRegistry<T>();
            _stateActivator = new StateActivator<T>();
            _stateMachine = new StateMachine<T>(_stateRegistry, _stateActivator);
            return this;
        }
        public StateMachineBuilder<T> AddState<TState>(TState state) where TState : IState<T>
        {
            Debug.Log(state);
            _stateMachine.AddStateToRegistry(state);
            return this;
        }
        public StateMachine<T> Build()
        {
            return _stateMachine;
        }
    }
}