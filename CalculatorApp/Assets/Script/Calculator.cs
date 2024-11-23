using System;
using TMPro;
using UnityEngine;

public class Calculator : Singleton<Calculator>
{
    [SerializeField] private TextMeshProUGUI _expressionsText;

    private string _expressionString;
    
    private void Start()
    {
        _expressionString = "0";
        RefreshExpressionsTextUI();
    }

    public void AddValue(char c)
    {
        if(IsOperator(c))
            AddOperator(c);
        else if (c == 'C')
            Clear();
        else if (c == 'B')
            Backspace();
        else if (c == '=')
            Calculate();
        else
            AddNumber(c);
        
        RefreshExpressionsTextUI();
    }

    private void Calculate()
    {
        
    }

    private void AddNumber(char c)
    {
        if (_expressionString == "0")
            _expressionString = c.ToString();
        else
            _expressionString += c;
    }

    private void Backspace()
    {
        if (_expressionString.Length > 1)
            _expressionString = _expressionString.Substring(0, _expressionString.Length - 1);
        else
            _expressionString = "0";
    }

    private bool IsOperator(char c)
    {
        if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%')
            return true;
        
        return false;
    }

    private void AddOperator(char c)
    {
        if (IsLastValueOperator())
            return;
        
        _expressionString += c;
    }
    
    private void Clear()
    {
        _expressionString = "0";
    }
    
    private bool IsLastValueOperator()
    {
        char lastChar = _expressionString[_expressionString.Length - 1];
        return IsOperator(lastChar);
    }

    private void RefreshExpressionsTextUI()
    {
        _expressionsText.text = _expressionString;
    }
    
}
