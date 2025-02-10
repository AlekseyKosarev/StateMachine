using _Project.System.StateMachine.Interfaces;

namespace _Project.System.StateMachine.Example.Realizations.States
{
    public abstract class BaseState<T> : IState<T>
    {
        public abstract void EnterState(T context);
        public abstract void ExitState(T context);
        public abstract void UpdateState(T context);
        public uint Index { get; set; }
    }
}