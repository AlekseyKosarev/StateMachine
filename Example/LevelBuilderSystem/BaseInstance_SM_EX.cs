using UnityEngine;

namespace StateMachine.Example.LevelBuilderSystem
{
    public abstract class BaseInstance_SM_EX : MonoBehaviour
    {
        public abstract void OnGame();
        public abstract void OnPause();
    }
}