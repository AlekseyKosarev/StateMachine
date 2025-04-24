using StateMachine.Interfaces;
using Unity.VisualScripting;

namespace StateMachine.BasedState
{
    public abstract class BaseState<T> : IState<T>, IInitializable<T>
    {
        private bool _isFirstEnter = true;

        bool IInitializable<T>.IsFirstEnter
        {
            get => _isFirstEnter;
            set => _isFirstEnter = value;
        }

        public uint Index { get; set; }

        public abstract void Init(T context);

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
    }
}