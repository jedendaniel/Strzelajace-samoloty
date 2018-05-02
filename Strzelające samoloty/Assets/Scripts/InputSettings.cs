using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEntity
{
    public KeyCode InputCode { get; set; }
    public Action InputAction { get; set; }
    public bool Pressed { get; set; }

    public InputEntity(KeyCode code, Action action)
    {
        InputCode = code;
        InputAction = action;
    }
}

public class InputSettings{

    public static KeyCode[] defaultCtrl1 = new KeyCode[]{
        KeyCode.W,
        KeyCode.Space
    };
    public static KeyCode[] defaultCtrl2 = new KeyCode[]{
        KeyCode.UpArrow,
        KeyCode.Return
    };

    static string[] actions = new string[]
    {
        "forward",
        "shoot"
    };

    public KeyCode[] CtrlSettings = defaultCtrl1;

    Action[] methods;

    public Dictionary<string, InputEntity> KeyMapping { get; set; }
    public Dictionary<string, Action> ActionMapping { get; set; }

    public void InitDict(Plane plane, int teamNumber)
    {
        methods = new Action[]
        {
            plane.MoveForward,
            plane.Shoot
        };
        KeyMapping = new Dictionary<string, InputEntity>();
        ActionMapping = new Dictionary<string, Action>();
        if(teamNumber == 1)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                KeyMapping.Add(actions[i], new InputEntity(defaultCtrl1[i],methods[i]));
            }
        }
        else
        {
            for (int i = 0; i < actions.Length; i++)
            {
                KeyMapping.Add(actions[i], new InputEntity(defaultCtrl2[i], methods[i]));
            }
        }
    }

    public void LoadCtrlSettings(KeyCode[] settings)
    {
        CtrlSettings = settings;
    }
}
