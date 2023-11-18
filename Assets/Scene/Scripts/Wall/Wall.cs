using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

   [SerializeField] GameDirection direction;
   [SerializeField] private bool stickWall;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (!stickWall)
            {
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
            }
            else
            {
                Launcher.Instance().CollectBall(ball);
            }
        }
    }




}
