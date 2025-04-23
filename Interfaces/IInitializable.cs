namespace StateMachine.Interfaces
{
    public interface IInitializable
    {
        public bool IsFirstEnter { get; set; }
        public void Init(object context);
        public void ResetState();
    }
}