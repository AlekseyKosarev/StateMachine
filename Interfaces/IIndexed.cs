namespace StateMachine.Interfaces
{
    public interface IIndexed
    {
        public uint Index { get; set; }

        public uint GetIndex()
        {
            return Index;
        }

        public void SetIndex(uint index)
        {
            Index = index;
        }
    }
}