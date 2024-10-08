using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------
// 入力を反映するクラス
// ----------------------------------

public interface IInput
{
    bool IsInputPressed(string inputName);
    void UpdateKeyState();
}
public class PlayerInput : IInput
{
    private Dictionary<string, int> _inputStatements;
    private Dictionary<string, Func<bool>> _inputStateUpdateMethods;
    // Start is called before the first frame update

    public PlayerInput()
    {
        // 押された:1   離された:-1     押されていない:0
        _inputStatements = new Dictionary<string, int>()
        {
            ["SelectLeft"] = 0,
            ["SelectRight"] = 0,
            ["SelectUp"] = 0,
            ["SelectDown"] = 0
        };
        _inputStateUpdateMethods = new Dictionary<string, Func<bool>>()
        {
            ["SelectLeft"] = IsSelectLeftPressed,
            ["SelectRight"] = IsSelectRightPressed,
            ["SelectUp"] = IsSelectUpPressed,
            ["SelectDown"] = IsSelectDownPressed
        };
    }

    ~PlayerInput()
    {
        _inputStatements.Clear();
        _inputStateUpdateMethods.Clear();
    }
    // Update is called once per frame
    public void UpdateKeyState()
    {
        foreach (var updateMethod in _inputStateUpdateMethods)
        {
            bool keyState = updateMethod.Value.Invoke();
            if (keyState)
            {
                _inputStatements[updateMethod.Key] = 1;
            }
            else
            {
                if (_inputStatements[updateMethod.Key] == -1)
                {
                    _inputStatements[updateMethod.Key] = 0;
                }
                else
                {
                    _inputStatements[updateMethod.Key] *= -1;
                }
            }
        }
    }

    public bool IsInputPressed(string inputName)
    {
        if (_inputStatements.TryGetValue(inputName, out int state))
        {
            return state == 1;
        }

        return false;
    }

    
    private bool IsSelectLeftPressed()
    {
        // select left          (keyboard)                          
        return Input.GetKeyDown(KeyCode.A);
    }
    private bool IsSelectRightPressed()
    {
        // select right         (keyboard)                         
        return Input.GetKeyDown(KeyCode.D);
    }

    private bool IsSelectUpPressed()
    {
        // select up            (keyboard)                        
        return Input.GetKeyDown(KeyCode.W);
    }

    private bool IsSelectDownPressed()
    {
        // select down          (keyboard)                         
        return Input.GetKeyDown(KeyCode.S);
    }
}
