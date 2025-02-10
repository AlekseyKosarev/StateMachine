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

        public StateMachineBuilder()
        {
            _stateRegistry = new StateRegistry<T>();
        }
        public StateMachineBuilder<T> AddState<TState>(TState state) where TState : IState<T>
        {
            _stateRegistry.AddStateToRegistry(state);
            return this;
        }
        public StateMachine<T> Build()
        {
            _stateActivator = new StateActivator<T>(_stateRegistry.GetStatesBaseArray());
            _stateMachine = new StateMachine<T>(_stateRegistry, _stateActivator);
            return _stateMachine;
        }
    }
    public class StateMachineMonoBuilder<T>
    {
        private StateRegistry<T> _stateRegistry;
        private StateActivator<T> _stateActivator;
        private StateMachineMono<T> _stateMachine;

        public StateMachineMonoBuilder()
        {
            _stateRegistry = new StateRegistry<T>();
            
        }
        public StateMachineMonoBuilder<T> AddState<TState>(TState state) where TState : MonoBehaviour, IState<T>
        {
            // Debug.Log(state);
            _stateRegistry.AddStateToRegistry(state);
            return this;
        }
        public StateMachineMono<T> Build()
        {
            _stateActivator = new StateActivator<T>(_stateRegistry.GetStatesBaseArray());
            _stateMachine = new StateMachineMono<T>(_stateRegistry, _stateActivator);
            return _stateMachine;
        }
    }
}