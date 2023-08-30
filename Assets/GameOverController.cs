using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI gameOverScoreText; // Reference to the UI text element to display the score

    private void Start()
    {
        // Retrieve the high score from SaveScore script and display it on the Game Over screen
        SaveScore saveScore = FindObjectOfType<SaveScore>();
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        gameOverScoreText.text = $"High Score: {highScore}";
    }

    // Rest of the GameOverController script...
}