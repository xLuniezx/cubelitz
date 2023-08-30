using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoseCollider : MonoBehaviour
{
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip minusLife;
    [SerializeField] int lives = 3;
    public GameObject[] hearts;
    Ball theBall;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    void Start()
    {
        theBall = FindObjectOfType<Ball>();
        bool value = theBall.hasStarted;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lives >= 2)
        {
            LoseLives();
            theBall.hasStarted = false;
            AudioSource.PlayClipAtPoint(minusLife, Camera.main.transform.position);
        }
        else
        {
            LoseLives();
            AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position);
            StartCoroutine(LoadGameOver());
        }
    }
    private void Update()
    {
        if (!theBall.hasStarted)
        {
            theBall.GetComponent<Ball>().LockBallToPaddle();
            theBall.GetComponent<Ball>().LaunchOnMouseClick();
        }
        if (lives < 1)
        {
            heart3.SetActive(false);
        }
        else if (lives < 2)
        {
            heart2.SetActive(false);
        }
        else if (lives < 3)
        {
            heart1.SetActive(false);
        }
        if (lives == 3)
        {
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
    }

    private void LoseLives()
    {
        lives = lives - 1;
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");
    }
}