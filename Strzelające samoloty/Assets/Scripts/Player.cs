﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Plane plane;
    public Flag flag;
    public BulletsManager bulletsManager;
    public string playerName;
    public int teamNumber;
    public Text nameText;
    public Image healthBar;
    public Color color;

    public CustomInput customInput;

    void Start()
    {
        nameText.text = playerName;
        customInput.Init(plane, teamNumber);
        plane.Init(playerName, teamNumber, healthBar, bulletsManager, color);
        flag.Init(plane, color);
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
