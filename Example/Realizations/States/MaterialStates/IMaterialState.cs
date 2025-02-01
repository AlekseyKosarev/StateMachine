using _Project.System.StateMachine.Example.MonoBehaviorStates;

namespace _Project.System.StateMachine.Example.Realizations.States.MaterialStates
{
    public interface IMaterialState
    {
        public BaseStateMono<IEffectStates> State{ get; set; }
    }
}