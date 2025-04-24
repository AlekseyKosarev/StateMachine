using StateMachine.Interfaces;

namespace StateMachine.BasedState
{
    public abstract class BaseStateCounted<T> : BaseState<T>, ICounted
    {
        public int Count { get; private set; }

        public void IncrementCount()
        {
            Count++;
        }

        public void DecrementCount()
        {
            Count--;
        }

        public void ResetCount()
        {
            Count = 0;
        }
    }
}