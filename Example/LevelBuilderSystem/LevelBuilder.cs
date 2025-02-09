using System;
using _Project.System.StateMachine.Example.EVENTS;
using UnityEngine;

namespace _Project.System.StateMachine.Example.LevelBuilderSystem
{
    public class LevelBuilder: MonoBehaviour
    {
        public BaseInstance prefab;
        public int countCopys = 1;
        public LevelData levelData;

        private void Awake()
        {
            levelData = GetComponent<LevelData>();
        }

        private void Build()
        {
            if (prefab == null) return;
            
            for (int i = 0; i < countCopys; i++)
            {
                levelData.AddInstance(Instantiate(prefab));
            }
        }

        private void DestroyInstances()
        {
            levelData.DestroyInstances();
        }

        private void OnEnable()
        {
            GameSwitch.OnLoad += Build;
            GameSwitch.OnExit += DestroyInstances;
            
            GameSwitch.OnGame += levelData.OnGame;
            GameSwitch.OnPause += levelData.OnPause;
        }

        private void OnDisable()
        {
            GameSwitch.OnLoad -= Build;
            GameSwitch.OnExit -= DestroyInstances;
            
            GameSwitch.OnGame -= levelData.OnGame;
            GameSwitch.OnPause -= levelData.OnPause;
        }
    }
}