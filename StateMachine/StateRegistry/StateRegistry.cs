using System;
using System.Collections.Generic;
using _Project.System.StateMachine.Interfaces;

namespace _Project.System.StateMachine.StateMachine.StateRegistry
{
    public class StateRegistry<T>
    {
        private List<IState<T>> states = new List<IState<T>>();
        private Dictionary<Type, IState<T>> currentStateMap = new Dictionary<Type, IState<T>>();

        public void AddStateToRegistry<TState>(TState state) where TState : IState<T>
        {
            states.Add(state);
            currentStateMap[typeof(TState)] = state;
        }

        public bool ContainsStateInRegistry<TState>() where TState : IState<T>
        {
            return currentStateMap.ContainsKey(typeof(TState));
        }

        public IState<T> GetStateFromRegistry<TState>() where TState : IState<T>
        {
            return currentStateMap.TryGetValue(typeof(TState), out var state) ? state : null;
        }

        public void RemoveStateFromRegistry<TState>() where TState : IState<T>
        {
            var stateType = typeof(TState);
            if (currentStateMap.ContainsKey(stateType) && states.Contains(currentStateMap[stateType]))
            {
                states.Remove(currentStateMap[stateType]);
                currentStateMap.Remove(stateType);
            }
        }
    }
}