using StateMachineTools.Interfaces;

namespace StateMachineTools.StateMachine.StateRegistry
{
    public interface IStateRegistry<T>
    {
        void AddState<TState>(TState state) where TState : IState<T>;
        bool ContainsState<TState>() where TState : IState<T>;
        IState<T> GetState<TState>() where TState : IState<T>;
        void RemoveState<TState>() where TState : IState<T>;
    }
}