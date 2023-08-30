using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    //[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEndabled;
    [SerializeField] public int currentScore = 0;
    [SerializeField] private int currentStars = 0;
    [SerializeField] TextMeshProUGUI starPoints;
    private int currentStarPoints;
    SaveScore saveScore;
    PauseMenu pauseMenu;
    SceneLoader sceneLoader;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        saveScore = FindObjectOfType<SaveScore>(); // Find the SaveScore script in the scene.
        PlayerPrefs.SetInt("Score", currentScore);
        pauseMenu = FindObjectOfType<PauseMenu>();
        PlayerPrefs.SetInt("Stars", currentStars);
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = gameSpeed;
        starPoints.text = "Stars: " + currentStars;
    }

    public void AddStars()
    {
        currentStars += 1;
        starPoints.text = currentStars.ToString();
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
        saveScore.HighScoreSet(currentScore); // Call HighScoreSet with the new score.
    }

    public void ResetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEndabled;
    }

}
