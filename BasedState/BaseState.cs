using StateMachine.Interfaces;

namespace StateMachine.BasedState
{
    public abstract class BaseState<T> : IState<T>, IInitializable
    {
        private bool _isFirstEnter = true;

        bool IInitializable.IsFirstEnter
        {
            get => _isFirstEnter;
            set => _isFirstEnter = value;
        }

        public uint Index { get; set; }

        public abstract void Init(object context);

        public virtual void EnterState(T context)
        {
            if (_isFirstEnter)
            {
                _isFirstEnter = false;
                Init(context);
            }
        }

        public abstract void ExitState(T context);

        public abstract void UpdateState(T context);

        public void ResetState()
        {
            _isFirstEnter = true;
        }

        public virtual bool IsCounted { get; set; }
        public int Count { get; private set; }

        public void IncrementCount()
        {
            if (IsCounted)
            {
                Count++;
            }
        }

        public void DecrementCount()
        {
            if (IsCounted)
            {
                Count--;
            }
        }

        public void ResetCount()
        {
            if (IsCounted)
            {
                Count = 0;
            }
        }

        public bool IsCountZero()
        {
            if (IsCounted)
            {
                return Count == 0;
            }

            return true;
        }
    }
}