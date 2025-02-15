using StateMachine.Interfaces;
using StateMachine.StateMachineSystems.StateActivatorSystem;
using StateMachine.StateMachineSystems.StateRegistrySystem;
using UnityEngine;

namespace StateMachine.StateMachineSystems
{
    public class StateMachineBuilder<T>
    {
        private StateActivator<T> _stateActivator;
        private StateMachine<T> _stateMachine;
        private readonly StateRegistry<T> _stateRegistry;

        public StateMachineBuilder()
        {
            _stateRegistry = new StateRegistry<T>();
        }
        public StateMachineBuilder<T> AddStatesFromList(IState<T>[] states)
        {
            foreach (var state in states)
            {
                _stateRegistry.AddStateToRegistry(state);
            }
            return this;
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
        private StateActivator<T> _stateActivator;
        private StateMachineMono<T> _stateMachine;
        private readonly StateRegistry<T> _stateRegistry;

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