using _Project.System.StateMachine.BitMaskArray;

namespace _Project.System.StateMachine.Interfaces
{
    public interface IState<T> : IIndexed
    {
        void EnterState(T context);
        void ExitState(T context);
        void UpdateState(T context);
    }
}