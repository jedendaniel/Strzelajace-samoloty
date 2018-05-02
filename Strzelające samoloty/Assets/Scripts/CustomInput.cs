using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class CustomInput
{
    private Dictionary<string, InputAxis> axesDict = new Dictionary<string, InputAxis>();
    //{
    //    {"Horizontal", new InputAxis(KeyCode.A,KeyCode.D)}
    //};

    [SerializeField]
    private InputAxis[] axesArray;

    static private string[] actionsArray = {
        "Horizontal"
    };

    public void Init()
    {
        //axesArray = new InputAxis[axesDict.Count];
        for(int i = 0; i < actionsArray.Length; i++)
        {
            axesDict.Add(actionsArray[i], axesArray[i]);
        }
    }

    public float GetAxis(string name)
    {
        return axesDict[name].GetActualValue();
    }
}
