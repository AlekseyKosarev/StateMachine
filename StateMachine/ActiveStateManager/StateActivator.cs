using System.Collections.Generic;
using System.Linq;
using _Project.System.StateMachine.Interfaces;

namespace _Project.System.StateMachine.StateMachine.ActiveStateManager
{
    public class StateActivator<T> : IStateActivator<T>
    {
        private HashSet<IState<T>> _activeStates = new();

        public void ActivateState(IState<T> state, T context)
        {
            if (!_activeStates.Contains(state))
            {
                state.EnterState(context);
                _activeStates.Add(state);
            }
        }

        public void DeactivateState(IState<T> state, T context)
        {
            if (_activeStates.Contains(state))
            {
                state.ExitState(context);
                _activeStates.Remove(state);
            }
        }
        
        private void DeactivateAllStates(T context)
        {
            foreach (var state in _activeStates)
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
        public void SwitchToState(IState<T> state, T context)
        {
            if (IsStateActive(state))
            {
                // Debug.Log ("State already active");
                return; // Если состояние уже активно, ничего не делаем
            }
            DeactivateAllStates(context);
            ActivateState(state, context);
        }
        public bool IsStateActive(IState<T> state)
        {
            return _activeStates.Contains(state);
            //return activeStates.OfType<TState>().Any();
        }
        public void Update(T context)
        {
            // activeStates.C
            foreach (var state in _activeStates)
            {
                state.UpdateState(context);
            }
        }
    }
}