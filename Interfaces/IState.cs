namespace _Project.System.StateMachine.Interfaces
{
    public interface IState<T>
    {
        void EnterState(T context);
        void ExitState(T context);
        void UpdateState(T context);
    }
}