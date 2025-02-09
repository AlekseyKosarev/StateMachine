using _Project.System.StateMachine.Example.LevelBuilderSystem;

namespace _Project.System.StateMachine.Example.EmptyTest
{
    public class OnlyUpdate: BaseInstance
    {
        private int _count = 0;
        private void Update()
        {
            SomeFunc();
        }

        private void SomeFunc()
        {
            _count = _count;
            // return;
        }

        public override void OnGame()
        {
            // throw new NotImplementedException();
        }

        public override void OnPause()
        {
            // throw new NotImplementedException();
        }
    }
}