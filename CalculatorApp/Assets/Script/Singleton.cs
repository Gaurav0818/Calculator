using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    
    private static T _Instance;
    

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<T>();

                if (_Instance == null)
                {
                    GameObject newObject = new GameObject(typeof(T).Name);
                    _Instance = newObject.AddComponent<T>();
                }
            }

            return _Instance;
        }
    }
    
    protected virtual void Awake()
    {
        if (_Instance == null)
            _Instance = this as T;
        else
            Destroy(gameObject);
    }
    
    void OnDestroy()
    {
        if( _Instance == this )
            _Instance = null;
    }
}