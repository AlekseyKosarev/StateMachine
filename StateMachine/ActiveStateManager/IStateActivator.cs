using _Project.System.StateMachine.Interfaces;

namespace _Project.System.StateMachine.StateMachine.ActiveStateManager
{
    public interface IStateActivator<T>
    {
        void ActivateState(IState<T> state, T context);
        void DeactivateState(IState<T> state, T context);
        void Update(T context);
    }
}