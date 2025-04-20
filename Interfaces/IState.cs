using StateMachine.BitMaskArray;

namespace StateMachine.Interfaces
{
    public interface IState<T> : IIndexed, ICounted
    {
        void EnterState(T context);
        void ExitState(T context);
        void UpdateState(T context);
    }
}