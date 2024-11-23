using UnityEngine;

public class CalculatorKey : MonoBehaviour
{
    [SerializeField] private char _keyValue = '0';
    
    public void KeyPressed()
    {
        Calculator.Instance.AddValue(_keyValue);
    }
}
