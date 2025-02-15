using StateMachineTools.BitMaskArray;

namespace StateMachineTools.Interfaces
{
    public interface IState<T> : IIndexed
    {
        void EnterState(T context);
        void ExitState(T context);
        void UpdateState(T context);
    }
}