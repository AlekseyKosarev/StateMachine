using System.Collections.Generic;
using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;
using UnityEngine;

namespace _Project.System.StateMachine.StateMachine
{
    public class StateMachine<T>: BaseStateMachine<T>
    {
        public StateMachine(StateRegistry<T> stateRegistry, StateActivator<T> stateActivator)
            : base(stateRegistry, stateActivator) { }
        public void AddStateToRegistry<TState>(TState state) where TState : IState<T>
        {
            base.AddStateToRegistryBase(state);
        }
        public void RemoveStateFromRegistry<TState>() where TState : IState<T>
        {
            base.RemoveStateFromRegistryBase<TState>();
        }
        public void SetStateActive<TState>(bool setActive, T context) where TState : IState<T>
        {
            base.SetStateActiveBase<TState>(setActive, context);
        }
        public void SwitchToState<TState>(T context) where TState : IState<T>
        {
            base.SwitchToStateBase<TState>(context);
        }
        public bool IsStateActive(IState<T> state)
        {
            return base.IsStateActiveBase(state);
        }
        public bool IsStateActiveOfType<TState>() where TState : IState<T>
        {
            IState<T> state = GetStateFromRegistry<TState>();
            return IsStateActive(state);
        }
        
        public IState<T> GetStateFromRegistry<TState>() where TState : IState<T>
        {
            return base.GetStateFromRegistryBase<TState>();
        }
        
        public int GetCountStates() => _stateRegistry.GetCountStatesBase();
        public List<IState<T>> GetStates() => _stateRegistry.GetStatesBase();
    }
}