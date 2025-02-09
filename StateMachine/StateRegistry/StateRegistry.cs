using System;
using System.Collections.Generic;
using System.Linq;
using _Project.System.StateMachine.Interfaces;
using UnityEngine;
using Enumerable = System.Linq.Enumerable;

namespace _Project.System.StateMachine.StateMachine.StateRegistry
{
    public class StateRegistry<T>
    {
        private Dictionary<Type, IState<T>> _states = new();

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
        public List<IState<T>> GetStatesBase() => _states.Values.ToList();
    }
}