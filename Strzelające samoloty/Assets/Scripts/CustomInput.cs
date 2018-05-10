using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class CustomInput
{
    private Dictionary<string, InputAxis> axesDict = new Dictionary<string, InputAxis>();

    [SerializeField]
    private InputAxis[] axesArray;

    public InputSettings inputSettings = new InputSettings();

    static private string[] actionsArray = {
        "Horizontal"
    };

    public void Init(Plane plane, int teamNumber)
    {
        inputSettings.InitDict(plane, teamNumber);
        for (int i = 0; i < actionsArray.Length; i++)
        {
            axesDict.Add(actionsArray[i], axesArray[i]);
        }
    }

    public float GetAxis(string name)
    {
        return axesDict[name].GetActualValue();
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
