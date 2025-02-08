using UnityEngine;

namespace _Project.System.StateMachine.Example.EmptyTest
{
    public class OnlyUpdate: MonoBehaviour
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
    }
}