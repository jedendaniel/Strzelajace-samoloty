using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class InputAxis
{
    [SerializeField]
    private KeyCode positiveButton;
    [SerializeField]
    private KeyCode negativeButton;
    [SerializeField]
    private float sensitivity = 0.01f;
    [SerializeField]
    private float maxRotationValue = 2;

    private float x = 0;
    private float y = 0;

    private float linearSlope = 4;
    private float linearMaxX;
    private float logBase = 1.1f;
    private float logMaxX;

    //TODO: Why constructors (or for sure that one constructor) are/is called so many times? 
    public InputAxis()
    {
        linearMaxX = maxRotationValue / linearSlope;
        logMaxX = Mathf.Pow(logBase, maxRotationValue);
        Debug.Log("Konstruktor 1");
    }

    public float GetActualValue()
    {
        logBase = 1.1f;
        if (!Input.GetKey(positiveButton) && !Input.GetKey(negativeButton))
        {
            x = 0;
            y = 0;
        }
        else { 
            if (Input.GetKey(positiveButton) && !Input.GetKey(negativeButton))
            {
                x += sensitivity;
                y = CalculateRotationLinear(x);
            }
            if (!Input.GetKey(positiveButton) && Input.GetKey(negativeButton))
            {
                x += sensitivity;
                y = -CalculateRotationLinear(x);
            }
        }
        return y;
    }

    private float CalculateRotationLogarithmic(float localX)
    {
        if (localX < logMaxX)
        {
            return (Mathf.Log(localX + 1, logBase) / 2);
        }
        else
        {
            this.x = logMaxX;
            return maxRotationValue;
        }
    }

    private float CalculateRotationLinear(float localX)
    {
        if (localX < linearMaxX)
        {
            return (linearSlope * (localX));
        }
        else
        {
            x = linearMaxX;
            return maxRotationValue;
        }
    }
}
