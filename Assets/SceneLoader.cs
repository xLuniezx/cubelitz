using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1;
    }
    public void LoadStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.ResetGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadShopScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSettingsScene()
    {
        SceneManager.LoadScene(2);
    }

}