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
        
        if (gameWin)
        {
            Debug.Log("you win");
            winPannel.SetActive(true);
        }

    }

}
