using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    private List<Ball> balls = new List<Ball>();


    private void Update()
    {
        Capture();
    }

    private void Capture()
    {
        for(int i =0;i < balls.Count; i++)
        {
            Ball b = balls[i];
            transform.position = Vector3.Lerp(b.transform.position, transform.position, 0.01f);
            if(Vector3.Distance(transform.position, b.transform.position) <.5f)
            {
                Destroy(b);
            }
        }
    }

    private void Destroy(Ball b)
    {
        balls.Remove(b);
        Destroy(b);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {

            Ball b = other.GetComponent<Ball>();
            balls.Add(b);
            b.StopMoving();

        }
    }
}
