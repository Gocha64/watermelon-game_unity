using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessSensor : MonoBehaviour
{

    public bool gameWin = false;

    [SerializeField]
    GameObject winPannel;


    private void Update()
    {
        //게임 내에 목표 레벨에 도달한 과일이 있는지 체크
        if (gameWin)
        {
            Debug.Log("you win");
            winPannel.SetActive(true);
            gameWin = false;
        }

    }

}
