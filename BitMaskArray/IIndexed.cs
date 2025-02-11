namespace _Project.System.StateMachine.BitMaskArray
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