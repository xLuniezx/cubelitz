using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private GameSession gameController;
    private Vector3 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.9f, Screen.height * 0.9f, 0));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ball"))
        {
            gameController.AddStars();
            Destroy(gameObject);
        }
    }

}