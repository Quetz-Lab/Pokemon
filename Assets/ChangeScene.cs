using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Main()
    {
        Debug.Log("MenuEscena");
        SceneManager.LoadScene(0);
    }
    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void WinScene()
    {
        SceneManager.LoadScene(2);
    }
    public void GameOverScene()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
