using System;
using _Project.System.StateMachine.Example.EVENTS;
using UnityEngine;

namespace _Project.System.StateMachine.Example
{
    public class LevelBuilder: MonoBehaviour
    {
        public GameObject prefab;
        private GameObject[] _instances;
        public int countCopys = 1;

        private void Build()
        {
            if (prefab == null) return;
            
            _instances = new GameObject[countCopys];
            for (int i = 0; i < countCopys; i++)
            {
                _instances[i] = Instantiate(prefab);
            }
        }

        private void DestroyInstances()
        {
            if (_instances == null) return;
            for (int i = 0; i < _instances.Length; i++)
            {
                Destroy(_instances[i]);
            }
            _instances = null;
        }

        private void OnEnable()
        {
            GameSwitch.OnLoad += Build;
            GameSwitch.OnExit += DestroyInstances;
        }

        private void OnDisable()
        {
            GameSwitch.OnLoad -= Build;
            GameSwitch.OnExit -= DestroyInstances;
        }
    }
}