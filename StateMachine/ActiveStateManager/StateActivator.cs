using StateMachineTools.BitMaskArray;
using StateMachineTools.Interfaces;

namespace StateMachineTools.StateMachine.ActiveStateManager
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
        public void DeactivateAllStates(T context)
        {
            foreach (var state in _activeStates.GetIndexesFromMask()) _all[state].ExitState(context);
            _activeStates.ClearMask();
        }
        public void SetStateActive(IState<T> state, bool setActive, T context)
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

        public IState<T>[] GetActiveStates()
        {
            var indexesActiveStates = _activeStates.GetIndexesFromMask();
            var currentActiveStates = new IState<T>[indexesActiveStates.Length];
            for (var i = 0; i < indexesActiveStates.Length; i++)
            {
                currentActiveStates[i] = _all[indexesActiveStates[i]];
            }

            return currentActiveStates;
        }
        public void Update(T context)
        {
            var indexesActiveStates = _activeStates.GetIndexesFromMask();
            foreach (var state in indexesActiveStates) _all[state].UpdateState(context);
        }
    }
}