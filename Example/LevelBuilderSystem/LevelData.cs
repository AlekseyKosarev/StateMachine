using System.Collections.Generic;
using UnityEngine;

namespace _Project.System.StateMachine.Example.LevelBuilderSystem
{
    public class LevelData: MonoBehaviour
    {
        private List<BaseInstance> _instances;
        
        private void Clear() => _instances.Clear();
        public bool HasInstances() => _instances != null;
        public void SetInstances(List<BaseInstance> instances) => _instances = instances;

        public void AddInstance(BaseInstance instance)
        {
            if (HasInstances() == false) _instances = new List<BaseInstance>();
            _instances.Add(instance);
        }
        public void DestroyInstances()
        {
            if (HasInstances())
            {
                _instances.ForEach(instance => Destroy(instance.gameObject));
                Clear();
            }
        } 
        
        //вызывает произвольный метод
        public void OnGame() => _instances.ForEach(instance => instance.OnGame());
        public void OnPause() => _instances.ForEach(instance => instance.OnPause());
    }
}