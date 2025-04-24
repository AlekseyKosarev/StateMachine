using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Example.LevelBuilderSystem
{
    public class LevelData_SM_EX : MonoBehaviour
    {
        public List<BaseInstance_SM_EX> Instances { get; private set; }

        private void Clear()
        {
            Instances.Clear();
        }

        public bool HasInstances()
        {
            return Instances != null;
        }

        public void SetInstances(List<BaseInstance_SM_EX> instances)
        {
            Instances = instances;
        }

        public void AddInstance(BaseInstance_SM_EX instanceSmEx)
        {
            if (HasInstances() == false) Instances = new List<BaseInstance_SM_EX>();
            Instances.Add(instanceSmEx);
        }

        public void DestroyInstances()
        {
            if (HasInstances())
            {
                Instances.ForEach(instance => Destroy(instance.gameObject));
                Clear();
            }
        }

        //вызывает произвольный метод
        public void OnGame()
        {
            Instances.ForEach(instance => instance.OnGame());
        }

        public void OnPause()
        {
            Instances.ForEach(instance => instance.OnPause());
        }
    }
}