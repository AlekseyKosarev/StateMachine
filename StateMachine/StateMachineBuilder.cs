using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;
using UnityEngine;

namespace _Project.System.StateMachine.StateMachine
{
    public class StateMachineBuilder<T>
    {
        private readonly StateRegistry<T> _stateRegistry;
        private readonly StateActivator<T> _stateActivator;
        private StateMachine<T> _stateMachine;

        public StateMachineBuilder()
        {
            _stateRegistry = new StateRegistry<T>();
            _stateActivator = new StateActivator<T>();
            _stateMachine = new StateMachine<T>(_stateRegistry, _stateActivator);
        }
        public StateMachineBuilder<T> AddState<TState>(TState state) where TState : IState<T>
        {
            // Debug.Log(state);
            _stateMachine.AddStateToRegistry(state);
            return this;
        }
        public StateMachine<T> Build()
        {
            return _stateMachine;
        }
    }
    public class StateMachineMonoBuilder<T>
    {
        private readonly StateRegistry<T> _stateRegistry;
        private readonly StateActivator<T> _stateActivator;
        private StateMachineMono<T> _stateMachine;

        public StateMachineMonoBuilder()
        {
            _stateRegistry = new StateRegistry<T>();
            _stateActivator = new StateActivator<T>();
            _stateMachine = new StateMachineMono<T>(_stateRegistry, _stateActivator);
        }
        public StateMachineMonoBuilder<T> AddState<TState>(TState state) where TState : MonoBehaviour, IState<T>
        {
            // Debug.Log(state);
            _stateMachine.AddStateToRegistryMono(state);
            return this;
        }
        public StateMachineMono<T> Build()
        {
            return _stateMachine;
        }
    }
}