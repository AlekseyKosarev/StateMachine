using UnityEngine;

namespace StateMachine.Example.LevelBuilderSystem
{
    public abstract class BaseInstance : MonoBehaviour
    {
        public abstract void OnGame();
        public abstract void OnPause();
    }
}