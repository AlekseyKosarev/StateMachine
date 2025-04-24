using StateMachine.Example.EVENTS;
using UnityEngine;
using UnityEngine.Serialization;

namespace StateMachine.Example.LevelBuilderSystem
{
    public class LevelBuilder_SM_EX : MonoBehaviour
    {
        public BaseInstance_SM_EX prefab;
        public int countCopys = 1;
        [FormerlySerializedAs("levelData")] public LevelData_SM_EX levelDataSmEx;

        private void Awake()
        {
            levelDataSmEx = GetComponent<LevelData_SM_EX>();
        }

        private void OnEnable()
        {
            GameSwitch_SM_EX.OnLoad += Build;
            GameSwitch_SM_EX.OnExit += DestroyInstances;

            GameSwitch_SM_EX.OnGame += levelDataSmEx.OnGame;
            GameSwitch_SM_EX.OnPause += levelDataSmEx.OnPause;
        }

        private void OnDisable()
        {
            GameSwitch_SM_EX.OnLoad -= Build;
            GameSwitch_SM_EX.OnExit -= DestroyInstances;

            GameSwitch_SM_EX.OnGame -= levelDataSmEx.OnGame;
            GameSwitch_SM_EX.OnPause -= levelDataSmEx.OnPause;
        }

        private void Build()
        {
            if (prefab == null) return;

            for (var i = 0; i < countCopys; i++) levelDataSmEx.AddInstance(Instantiate(prefab));
        }

        private void DestroyInstances()
        {
            levelDataSmEx.DestroyInstances();
        }
    }
}