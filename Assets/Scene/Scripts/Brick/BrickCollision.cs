using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    [SerializeField] private GameDirection direction;
    [SerializeField] private Brick brick;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ball")
        {
            Ball ball = collision.transform.GetComponent<Ball>();
            switch (direction)
            {
                case GameDirection.top:
                    ball.SetDirection(new Vector3(ball.direction.x, -ball.direction.y)); break;
                case GameDirection.bottom:
                    ball.SetDirection(new Vector3(ball.direction.x, -ball.direction.y)); break;
                case GameDirection.left:
                    ball.SetDirection(new Vector3(-ball.direction.x, ball.direction.y)); break;
                case GameDirection.right:
                    ball.SetDirection(new Vector3(-ball.direction.x, ball.direction.y)); break;
            }
            brick.BallCollide();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="GameOverLine")
        {
            brick.GameOverLineTouch();
        }

        if(collision.tag == "WarningLine")
        {
            brick.WarningLineTouch();

        }    
    }
}
