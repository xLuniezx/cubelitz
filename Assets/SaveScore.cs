using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    void Start()
    {
        UpdateHighScoreText();
    }

    public void HighScoreSet(int newHighScore)
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (newHighScore > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", newHighScore);
            UpdateHighScoreText();
        }
    }

    public void UpdateHighScoreText()
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"HighScore: {currentHighScore}";
    }
}