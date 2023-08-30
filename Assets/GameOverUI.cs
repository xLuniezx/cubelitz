using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void ShowGameOverScreen(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}