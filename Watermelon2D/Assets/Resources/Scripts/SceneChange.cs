using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // ������������ �̵�
    public void moveToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    //���ӽ��������� �̵�
    public void moveToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    //��������
    public void moveToDesktop()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit(); // ���ø����̼� ����
    #endif
    }

}
