using UnityEngine;

namespace _Project.System.StateMachine.Example.EVENTS
{
    public class TestHandler: MonoBehaviour
    {
        private void OnEnable()
        {
            GameSwitch.OnGame += OnGame;
            GameSwitch.OnPause += OnPause;
            GameSwitch.OnLoad += OnLoad;
            GameSwitch.OnExit += OnExit;
        }

        private void OnDisable()
        {
            GameSwitch.OnGame -= OnGame;
            GameSwitch.OnPause -= OnPause;
            GameSwitch.OnLoad -= OnLoad;
            GameSwitch.OnExit -= OnExit;
        }

        private void OnGame() => Debug.Log("OnGame Handler");
        private void OnPause() => Debug.Log("OnPause Handler");
        private void OnLoad() => Debug.Log("OnLoad Handler");
        private void OnExit() => Debug.Log("OnExit Handler");
    }
}