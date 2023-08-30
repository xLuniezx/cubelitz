using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    GameSession gameSession;
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
