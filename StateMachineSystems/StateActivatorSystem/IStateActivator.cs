using StateMachine.Interfaces;

namespace StateMachine.StateMachineSystems.StateActivatorSystem
{
    public interface IStateActivator<T>
    {
        void ActivateState(IState<T> state, T context);
        void DeactivateState(IState<T> state, T context);
        void Update(T context);
    }
}