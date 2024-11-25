using System;
using System.Collections.Generic;
using System.Linq;
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
        AudioManager.Instance.PlayAudio(c.ToString());
        
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

    private bool IsLastCharDecimalNotation()
    {
        char lastChar = _expressionString[_expressionString.Length - 1];
        if (lastChar == '.')
            return true;
        
        return false;
    }

    private void AddOperator(char c)
    {
        if (IsLastValueOperator())
            Backspace();
        
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
    
    private void Calculate()
    {
        char lastChar = _expressionString[_expressionString.Length - 1];
        if (IsOperator(lastChar))
            Backspace();
        
        List<float> numList = new List<float>();
        List<Char> opList = new List<char>();

        float num = 0;
        string currentNum = string.Empty;
        foreach (char c in _expressionString)
        {
            if (IsOperator(c))
            {
                numList.Add(float.Parse(currentNum));
                currentNum = string.Empty;

                opList.Add(c);
            }
            else
            {
                currentNum += c;
            }
        }

        if (!string.IsNullOrEmpty(currentNum))
        {
            numList.Add(float.Parse(currentNum));
        }
        
        
        for (int i = 0; i < opList.Count; i++)
        {
            if (opList[i] == '*' || opList[i] == '/' || opList[i] == '%')
            {
                float result = 0;
                switch (opList[i])
                {
                    case '*':
                        result = numList[i] * numList[i + 1];
                        break;
                    case '/':
                        result = numList[i] / numList[i + 1];
                        break;
                    case '%':
                        result = numList[i] % numList[i + 1];
                        break;
                }

                numList[i] = result;
                numList.RemoveAt(i+1);
                opList.RemoveAt(i);
                i--;
            }
        }
        
        for (int i = 0; i < opList.Count; i++)
        {
            if (opList[i] == '+' || opList[i] == '-')
            {
                float result = 0;
                switch (opList[i])
                {
                    case '+':
                        result = numList[i] + numList[i + 1];
                        break;
                    case '-':
                        result = numList[i] - numList[i + 1];
                        break;
                }

                numList[i] = result;
                numList.RemoveAt(i+1);
                opList.RemoveAt(i);
                i--;
            }
        }
        _expressionString = numList[0].ToString();
    }

    private void RefreshExpressionsTextUI()
    {
        _expressionsText.text = _expressionString;
    }
    
}
