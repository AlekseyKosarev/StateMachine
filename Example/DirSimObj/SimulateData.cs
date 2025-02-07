using UnityEngine;

namespace _Project.System.StateMachine.Example.DirSimObj
{
    public struct SimulateData
    {
        public Vector2 Dir;
        public SimulateData (Vector2 dir) => Dir = dir;
    }
}