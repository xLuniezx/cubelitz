using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float minX = .55f;
    [SerializeField] float maxX = 6.19f;
    public float maxBounceAngle = 75f;
    Ball theBall;
    GameSession theGameSession;
    private Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
        playerBody = GetComponent<Rigidbody2D>();
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); // telling paddle to stay in its current place
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }

        Rigidbody2D ball = collision.rigidbody;
        Collider2D paddle = collision.otherCollider;

        // Gather information about the collision
        Vector2 ballDirection = ball.velocity.normalized;
        Vector2 contactDistance = paddle.bounds.center - ball.transform.position;

        // Rotate the direction of the ball based on the contact distance
        // to make the gameplay more dynamic and interesting
        float bounceAngle = (contactDistance.x / paddle.bounds.size.x) * maxBounceAngle;
        ballDirection = Quaternion.AngleAxis(bounceAngle, Vector3.forward) * ballDirection;

        // Re-apply the new direction to the ball
        ball.velocity = ballDirection * ball.velocity.magnitude;
    }

}
