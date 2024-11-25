using System;
using Unity.Mathematics;
using UnityEngine;

public class ButtonSizeModifier : MonoBehaviour
{
    private RectTransform _rt;
    private Vector2 _defaultOffsetMin;
    private Vector2 _defaultOffsetMax;
    //private 
    private void Awake()
    {
        _rt = GetComponent<RectTransform>();
        _defaultOffsetMin = _rt.offsetMin;
        _defaultOffsetMax = _rt.offsetMax;
    }
    private void OnEnable()
    {
        UpdateDimensions();
        
        OrientationManager.Instance.OnOrientationChanged += UpdateDimensions;
    }
    
    private void OnDisable()
    {
        OrientationManager.Instance.OnOrientationChanged -= UpdateDimensions;
    }

    private void UpdateDimensions()
    {
        float defaultHeight = 1080;
        float defaultWidth = 1920;
        
        float widthDiff = Screen.width / defaultWidth;
        float heightDiff = Screen.height / defaultHeight;
        
        float num = 1.0f;
        if(Screen.width > defaultWidth || Screen.height > defaultHeight)
        {
            num = 1.5f;
        }

        widthDiff = math.max(widthDiff, heightDiff);
        heightDiff = widthDiff;
        
        _rt.offsetMin = new Vector2(_defaultOffsetMin.x * widthDiff * num, _defaultOffsetMin.y * heightDiff * num); 
        _rt.offsetMax = new Vector2(_defaultOffsetMax.x * widthDiff * num, _defaultOffsetMax.y * heightDiff * num); 

    }
}
