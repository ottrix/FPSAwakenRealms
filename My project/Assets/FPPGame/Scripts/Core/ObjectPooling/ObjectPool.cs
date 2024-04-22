namespace FPPGame
{
    using System;
    using UnityEngine;

    public interface IObjectPool
    {
        object GetObject();
        void ReturnObject(object obj);
    }

    public class ObjectPool<T> : IObjectPool where T : MonoBehaviour
    {
        private T[] _objects;
        private int _index;
        // private Action<T> _configureObject;
        private GameObject _prefab;

        public ObjectPool(int size, GameObject prefab)
        {
            _objects = new T[size];
            _index = 0;
            // _configureObject = configureObject;

            for (int i = 0; i < size; i++)
            {
                T obj = GameObject.Instantiate(prefab).GetComponent<T>();      
                obj.gameObject.SetActive(false);
                _objects[i] = obj;
            }
        }

        public object GetObject()
        {
            T obj = _objects[_index];
            _index = (_index + 1) % _objects.Length;
            obj.gameObject.SetActive(true);
            // _configureObject(obj);
            return obj;
        }

        public void ReturnObject(object obj)
        {
            T t = (T)obj;
            t.gameObject.SetActive(false);
        }
    }

    // public interface IConfigurator
    // {
    //     void ConfigureObject(MonoBehaviour obj);
    // }

    // public class ObjectConfigurator : MonoBehaviour, IConfigurator
    // {
    //     public void ConfigureObject(MonoBehaviour obj)
    //     {
    //          
    //     }
    // }
}