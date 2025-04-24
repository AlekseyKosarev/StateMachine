using UnityEngine;

namespace StateMachine.Example.EVENTS
{
    public class TestHandler_SM_EX : MonoBehaviour
    {
        private void OnEnable()
        {
            GameSwitch_SM_EX.OnGame += OnGame;
            GameSwitch_SM_EX.OnPause += OnPause;
            GameSwitch_SM_EX.OnLoad += OnLoad;
            GameSwitch_SM_EX.OnExit += OnExit;
        }

        private void OnDisable()
        {
            GameSwitch_SM_EX.OnGame -= OnGame;
            GameSwitch_SM_EX.OnPause -= OnPause;
            GameSwitch_SM_EX.OnLoad -= OnLoad;
            GameSwitch_SM_EX.OnExit -= OnExit;
        }

        private void OnGame()
        {
            // Debug.Log("OnGame Handler");
        }

        private void OnPause()
        {
            // Debug.Log("OnPause Handler");
        }

        private void OnLoad()
        {
            // Debug.Log("OnLoad Handler");
        }

        private void OnExit()
        {
            // Debug.Log("OnExit Handler");
        }
    }
}