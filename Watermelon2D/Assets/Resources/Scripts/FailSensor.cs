using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSensor : MonoBehaviour
{

    public bool gameover { get; private set; } = false;

    [SerializeField]
    GameObject gameoverPannel;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameover = true;
        Debug.Log("gameover");
        gameoverPannel.SetActive(true);
        
    }



}
