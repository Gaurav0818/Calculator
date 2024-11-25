using System;
using UnityEngine;

public class OrientationManager : Singleton<OrientationManager>
{
    public delegate void OrientationChangeHandler();
    public event OrientationChangeHandler OnOrientationChanged;
    
    private int _width;
    private int _height;
    void Start()
    {
        _width = Screen.width;
        _height = Screen.height;
    }

    private void LateUpdate()
    {
        if(Screen.width != _width || Screen.height != _height)
        {
            _width = Screen.width;
            _height = Screen.height;
            OnOrientationChanged?.Invoke();
        }
    }
}
