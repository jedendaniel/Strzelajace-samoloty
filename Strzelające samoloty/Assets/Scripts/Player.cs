using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player{

    private InputSettings inputSettings = new InputSettings();
    public Plane plane;
    public int teamNumber;   

    public void Init()
    {
        inputSettings.InitDict(plane, teamNumber);
    }

    public void HandleInput()
    {
        foreach (KeyValuePair<string, InputEntity> entry in inputSettings.KeyMapping)
        {
            InputEntity inputEntity = entry.Value;
            if (Input.GetKeyDown(inputEntity.InputCode))
            {
                inputEntity.Pressed = true;
            }
            if (Input.GetKeyUp(inputEntity.InputCode))
            {
                inputEntity.Pressed = false;
            }
            if (inputEntity.Pressed)
            {
                inputEntity.InputAction.Invoke();
            }
        }
    }
}
