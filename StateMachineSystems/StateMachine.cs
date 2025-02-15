using System;
using System.Collections.Generic;
using StateMachine.Interfaces;
using StateMachine.StateMachineSystems.StateActivatorSystem;
using StateMachine.StateMachineSystems.StateRegistrySystem;

namespace StateMachine.StateMachineSystems
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
        public List<Type> GetStatesTypes() => base.GetStatesTypesBase();
        public List<IState<T>> GetStatesRegistry() => base.GetStatesRegistryBase();
        public List<IState<T>> GetActiveStates() => base.GetActiveStatesBase();
        public int[] GetActiveStatesIndexes() => _stateActivator.GetActiveStatesIndexes();

        public List<Type> GetActiveStatesTypes()
        {
            var allTypes = GetStatesTypes();
            var activeStates = GetActiveStatesIndexes();

            var types = new List<Type>(activeStates.Length);
            foreach (var index in activeStates) types.Add(allTypes[index]);
            
            return types;
        }
    }
}