using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;
    private Rigidbody2D playerBody;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
        playerBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
        playerBody = GetComponent<Rigidbody2D>();
    }
}