using StateMachineTools.Interfaces;

namespace StateMachineTools.StateMachine.ActiveStateManager
{
    public interface IStateActivator<T>
    {
        void ActivateState(IState<T> state, T context);
        void DeactivateState(IState<T> state, T context);
        void Update(T context);
    }
}