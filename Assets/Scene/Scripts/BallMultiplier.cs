using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMultiplier : MonoBehaviour
{
 public GameObject Ball;

    public void MultiplyBalls()
    {
        Instantiate(Ball,new Vector3(0,0,0),Quaternion.identity);
        Instantiate(Ball, new Vector3(1, 0, 0), Quaternion.identity);
    }
}
