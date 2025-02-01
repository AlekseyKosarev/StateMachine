using _Project.System.StateMachine.Example.Realizations.States.MaterialStates;
using UnityEngine;

namespace _Project.System.StateMachine.Example.MonoBehaviorStates
{
    public class BurnStateMono: BaseStateMono<IEffectStates>
    {
        public string textEnter = "Enter Burn State";
        public string textExit = "Exit Burn State";
        public string textUpdate = "Update Burn State";
        public override void EnterState(IEffectStates context)
        {
            Debug.Log(textEnter);
        }

        public override void ExitState(IEffectStates context)
        {
            Debug.Log(textExit);
        }

        public override void UpdateState(IEffectStates context)
        {
            Debug.Log(textUpdate);
        }
    }
}