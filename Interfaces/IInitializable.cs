namespace StateMachine.Interfaces
{
    public interface IInitializable<T>
    {
        public bool IsFirstEnter { get; set; }
        public void Init(T context);
        public void ResetState();
    }
}