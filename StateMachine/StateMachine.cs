using System.Collections.Generic;
using _Project.System.StateMachine.Interfaces;
using _Project.System.StateMachine.StateMachine.ActiveStateManager;
using _Project.System.StateMachine.StateMachine.StateRegistry;

namespace _Project.System.StateMachine.StateMachine
{
    public class StateMachine<T> : BaseStateMachine<T>
    {
        public StateMachine(StateRegistry<T> stateRegistry, StateActivator<T> stateActivator)
            : base(stateRegistry, stateActivator)
        {
        }

        public void AddStateToRegistry<TState>(TState state) where TState : IState<T>
        {
            base.AddStateToRegistryBase(state);
        }

        public void SetStateActive<TState>(bool setActive, T context) where TState : IState<T>
        {
            base.SetStateActiveBase<TState>(setActive, context);
        }

        public void SwitchToState<TState>(T context) where TState : IState<T>
        {
            SwitchToStateBase<TState>(context);
        }

        public bool IsStateActive(IState<T> state)
        {
            return IsStateActiveBase(state);
        }

        public bool IsStateActiveOfType<TState>() where TState : IState<T>
        {
            var state = GetStateFromRegistry<TState>();
            return IsStateActive(state);
        }

        public IState<T> GetStateFromRegistry<TState>() where TState : IState<T>
        {
            return GetStateFromRegistryBase<TState>();
        }

        public int GetCountStates()
        {
            return _stateRegistry.GetCountStatesBase();
        }

        public List<IState<T>> GetStatesRegistry() => base.GetStatesRegistryBase();
        public List<IState<T>> GetActiveStates() => base.GetActiveStatesBase();
    }
}