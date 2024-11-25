using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortBasedOnPreferredRatio : MonoBehaviour
{
    [SerializeField] private List<Transform> _lg;
    [SerializeField] private int _ratioCount = 0;
    [SerializeField] private int _padding = 0; 
    void OnEnable()
    {
        UpdateHeight();
        OrientationManager.Instance.OnOrientationChanged += UpdateHeight;
    }
    
    void OnDisable()
    {
        OrientationManager.Instance.OnOrientationChanged -= UpdateHeight;
    }

    private void UpdateHeight()
    {
        float pHight = transform.GetComponent<RectTransform>().rect.height - 2*_padding;
     
        _ratioCount = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            var ratioComp = child.GetComponent<SetPreferredRatio>();
            if (ratioComp)
            {
                _lg.Add(child);
                _ratioCount += ratioComp.GetRatio();
            }
        }

        foreach (var child in _lg)
        {
            int ratio = child.GetComponent<SetPreferredRatio>().GetRatio();
            RectTransform rt = child.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, ratio * pHight / _ratioCount);
        }
    }
}
