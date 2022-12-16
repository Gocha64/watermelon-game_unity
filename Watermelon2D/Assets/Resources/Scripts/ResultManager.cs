using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{

    public FailSensor failsensor; 

    void Update()
    {
        if (failsensor.gameover)
        {
            Debug.Log("gameover");
        }
    }
}
