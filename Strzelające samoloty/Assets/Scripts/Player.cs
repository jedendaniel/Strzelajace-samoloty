using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Plane plane;
    public int teamNumber;

    public CustomInput customInput;

    void Start()
    {
        customInput.Init(plane, teamNumber);
    }

    public void Update()
    {
        float rotation = customInput.GetAxis("Horizontal");
        if (rotation != 0)
        {
            plane.Rotate(rotation);
        }
        customInput.HandleInput();
    }

}
