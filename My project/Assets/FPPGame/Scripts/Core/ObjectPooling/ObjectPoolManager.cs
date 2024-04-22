
namespace FPPGame
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class ObjectPoolManager : MonoBehaviour
    {
        private static Dictionary<Type, IObjectPool> _objectPools;

        private void Awake()
        {
            _objectPools = new Dictionary<Type, IObjectPool>();
        }

        public static T GetObject<T>(GameObject prefab) where T : MonoBehaviour
        {
            Type type = typeof(T);

            if (_objectPools == null)
            {
                _objectPools = new Dictionary<Type, IObjectPool>();
            }

            if (!_objectPools.ContainsKey(type))
            {
                IObjectPool pool = new ObjectPool<T>(100, prefab);
                _objectPools[type] = pool;
            }

            return (T)_objectPools[type].GetObject();
        }

        public static void ReturnObject<T>(T obj) where T : MonoBehaviour
        {
            if(_objectPools == null)
            {
                return;
            }
            
            Type type = typeof(T);
            if (_objectPools.ContainsKey(type))
            {
                _objectPools[type].ReturnObject(obj);
            }
        }
    }
}