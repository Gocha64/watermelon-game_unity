using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSensor : MonoBehaviour
{

    public bool gameover { get; private set; } = false;

    [SerializeField]
    GameObject gameoverPannel;

    //센서에 오브젝트가 충돌시, 게임오버
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameover = true;
        Debug.Log("gameover");
        gameoverPannel.SetActive(true);
        
    }



}
