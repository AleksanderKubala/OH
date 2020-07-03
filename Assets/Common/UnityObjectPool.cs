using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Common
{
    public abstract class UnityObjectPool<T> : ScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private int _initialPoolSize;

        private LinkedList<T> _pooled;
        private HashSet<T> _used;

        public Transform Parent { get; set; }

        public virtual void Init()
        {
            if(_prefab == null) { throw new ArgumentNullException("No prefab set for object pool"); }
            if(_prefab.GetComponent<T>() == null) { throw new ArgumentException("Prefab profivded to pool does not contain required component"); }

            _pooled = new LinkedList<T>();
            _used = new HashSet<T>();

            for(int i = 0; i < _initialPoolSize; i++)
            {
                _pooled.AddLast(Create());
            }
        }

        public T GetObjectFromPool()
        {
            T retrievedFromPool;
            if(!_pooled.Any())
            {
                retrievedFromPool = Create();
            }
            else
            {
                retrievedFromPool = _pooled.First.Value;
                _pooled.Remove(retrievedFromPool);
            }
            _used.Add(retrievedFromPool);

            return retrievedFromPool;
        }

        public void ReturnObject(T usedObject)
        {
            _used.Remove(usedObject);
            Reset(usedObject);
            _pooled.AddLast(usedObject);
        }

        protected T Create()
        {
            var gameObject = Instantiate(_prefab, Vector3.zero, Quaternion.identity, Parent);
            var newInstance = gameObject.GetComponent<T>();

            return newInstance;
        }

        protected abstract void Reset(T usedObject);
    }
}
