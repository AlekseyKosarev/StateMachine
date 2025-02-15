using System;
using System.Collections.Generic;
using System.Linq;
using StateMachine.Interfaces;

namespace StateMachine.StateMachineSystems.StateRegistrySystem
{
    public class StateRegistry<T>
    {
        private readonly Dictionary<Type, IState<T>> _states = new();

        public void AddStateToRegistry<TState>(TState state) where TState : IState<T>
        {
            _states[typeof(TState)] = state;
        }

        public bool ContainsStateInRegistry<TState>() where TState : IState<T>
        {
            return _states.ContainsKey(typeof(TState));
        }

        public IState<T> GetStateFromRegistry<TState>() where TState : IState<T>
        {
            return _states.GetValueOrDefault(typeof(TState));
        }

        public int GetCountStatesBase()
        {
            return _states.Count;
        }
        public List<Type> GetStatesTypesBase()
        {
            return _states.Keys.ToList();
        }

        public List<IState<T>> GetStatesBase()
        {
            return _states.Values.ToList();
        }

        public IState<T>[] GetStatesBaseArray()
        {
            return _states.Values.ToArray();
        }
    }
}