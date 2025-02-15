using System.Collections.Generic;
using UnityEngine;

namespace StateMachineTools.Example.LevelBuilderSystem
{
    public class LevelData : MonoBehaviour
    {
        public List<BaseInstance> Instances { get; private set; }

        private void Clear()
        {
            Instances.Clear();
        }

        public bool HasInstances()
        {
            return Instances != null;
        }

        public void SetInstances(List<BaseInstance> instances)
        {
            Instances = instances;
        }

        public void AddInstance(BaseInstance instance)
        {
            if (HasInstances() == false) Instances = new List<BaseInstance>();
            Instances.Add(instance);
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