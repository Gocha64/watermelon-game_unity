using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void moveToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void moveToGame()
    {
        SceneManager.LoadScene("GameScene");
    }


    public void moveToDesktop()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit(); // 어플리케이션 종료
    #endif
    }

}
