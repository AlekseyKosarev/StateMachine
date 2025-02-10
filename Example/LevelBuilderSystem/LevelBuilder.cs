using System;
using System.Collections.Generic;
using _Project.System.StateMachine.Example.EVENTS;
using _Project.System.StateMachine.Example.MiniTest;
using UnityEngine;

namespace _Project.System.StateMachine.Example.LevelBuilderSystem
{
    public class LevelBuilder: MonoBehaviour
    {
        public BaseInstance prefab;
        public int countCopys = 1;
        public LevelData levelData;

        private MiniStateController[] a;
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

            a = levelData.Instances.ConvertAll(a=>a as MiniStateController).ToArray();
        }

        private void Update()
        {
            if (a == null)
            {
                return;
            }
            for (var i = 0; i < a.Length; i++)
            {
                var b = a[i];
                b.Tick();
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