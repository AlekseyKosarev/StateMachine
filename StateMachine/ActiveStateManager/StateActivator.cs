using System.Collections.Generic;
using System.Linq;
using _Project.System.StateMachine.Interfaces;
using UnityEngine;

namespace _Project.System.StateMachine.StateMachine.ActiveStateManager
{
    public class StateActivator<T> : IStateActivator<T>
    {
        private HashSet<IState<T>> activeStates = new HashSet<IState<T>>();

        public void ActivateState(IState<T> state, T context)
        {
            if (!activeStates.Contains(state))
            {
                state.EnterState(context);
                activeStates.Add(state);
            }
        }

        public void DeactivateState(IState<T> state, T context)
        {
            if (activeStates.Contains(state))
            {
                state.ExitState(context);
                activeStates.Remove(state);
            }
        }
        
        private void DeactivateAllStates(T context)
        {
            foreach (var state in activeStates.ToList())
            {
                DeactivateState(state, context);
            }
        }
        public void ChangeStatusState(IState<T> state, bool setActive, T context)
        {
            if (setActive)
            {
                ActivateState(state, context);
            }
            else
            {
                DeactivateState(state, context);
            }
        }
        public void SwitchToState<TState>(IState<T> state, T context) where TState : IState<T>
        {
            if (IsStateActive<TState>())
            {
                Debug.Log ("State already active");
                return; // Если состояние уже активно, ничего не делаем
            }
            DeactivateAllStates(context);
            ActivateState(state, context);
        }
        public bool IsStateActive<TState>() where TState : IState<T>
        {
            return activeStates.OfType<TState>().Any();
        }
        public void Update(T context)
        {
            foreach (var state in activeStates.ToList())
            {
                state.UpdateState(context);
            }
        }
    }
}