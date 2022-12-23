using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // 메인페이지로 이동
    public void moveToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    //게임스테이지로 이동
    public void moveToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    //게임종료
    public void moveToDesktop()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit(); // 어플리케이션 종료
    #endif
    }

}
