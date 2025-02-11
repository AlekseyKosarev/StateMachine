using _Project.System.StateMachine.BitMaskArray;
using _Project.System.StateMachine.Interfaces;

namespace _Project.System.StateMachine.StateMachine.ActiveStateManager
{
    public class StateActivator<T> : IStateActivator<T>
    {
        private readonly MaskArray _activeStates;
        private readonly IState<T>[] _all;

        public StateActivator(IState<T>[] states)
        {
            _activeStates = new MaskArray(states);
            _all = states;
        }

        public void ActivateState(IState<T> state, T context)
        {
            if (_activeStates.Contains(state.GetIndex())) return;

            _activeStates.Add(state.GetIndex());
            state.EnterState(context);
        }

        public void DeactivateState(IState<T> state, T context)
        {
            if (!_activeStates.Contains(state.GetIndex())) return;

            _activeStates.Remove(state.GetIndex());
            state.ExitState(context);
        }

        public void Update(T context)
        {
            var a = _activeStates.GetIndexesFromMask();
            foreach (var state in a) _all[state].UpdateState(context);
        }

        public void DeactivateAllStates(T context)
        {
            foreach (var state in _activeStates.GetIndexesFromMask()) _all[state].ExitState(context);
            _activeStates.ClearMask();
        }

        public void ChangeStatusState(IState<T> state, bool setActive, T context)
        {
            if (setActive)
                ActivateState(state, context);
            else
                DeactivateState(state, context);
        }

        public void SwitchToState(IState<T> state, T context)
        {
            if (IsStateActive(state)) return;
            DeactivateAllStates(context);
            ActivateState(state, context);
        }

        public bool IsStateActive(IState<T> state)
        {
            return _activeStates.Contains(state.GetIndex());
        }
    }
}