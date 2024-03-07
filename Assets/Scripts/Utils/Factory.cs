using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public abstract class Factory<T> : MonoBehaviour 
        where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        private readonly List<T> _instances = new();
        public IReadOnlyList<T> instances => _instances;
        
        public virtual T Create()
        {
            T instance = Instantiate(_prefab);
            _instances.Add(instance);
            return instance;
        }
        
        public virtual void CreateMany(int count, ref List<T> items)
        {
            for (int i = 0; i < count; i++)
            {
                T instance = Create();
                items.Add(instance);
            }
        }
        
        public virtual void Destroy(T instance)
        {
            _instances.Remove(instance);
            Object.Destroy(instance.gameObject);
        }
    }
}