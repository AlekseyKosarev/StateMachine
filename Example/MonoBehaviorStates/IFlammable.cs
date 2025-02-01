namespace _Project.System.StateMachine.Example.MonoBehaviorStates
{
    public interface IFlammable
    {
        float Temperature { get; }
        void Ignite();
    }
}