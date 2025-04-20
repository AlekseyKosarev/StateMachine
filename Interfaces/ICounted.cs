public interface ICounted
{
    public bool IsCounted { get; set; }
    public int Count { get; }
    public void IncrementCount();
    public void DecrementCount();
    public void ResetCount();
    public bool IsCountZero();
}