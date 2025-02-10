using _Project.System.StateMachine.Interfaces;
using UnityEngine;

namespace _Project.System.StateMachine.Example.MonoBehaviorStates
{
    public abstract class BaseStateMono<T> : MonoBehaviour, IState<T>
    {
        public abstract void EnterState(T context);

        public abstract void ExitState(T context);

        public abstract void UpdateState(T context);
        public uint Index { get; set; }
    }
}