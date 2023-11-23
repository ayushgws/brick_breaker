using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum GameDirection
{
    top,
    bottom,
    right,
    left
}

public class Ball : MonoBehaviour
{
   

    public float speed;             
    public Vector2 direction;       
    public Rigidbody2D rig;         
    public float distance = 0.05f;
    private Vector3 launchDestination;
    private Vector3 laucherCollidePosition;
    private bool ballStopped;
    public bool startCheckingMove;
    private bool move;
    private bool movingtoLaunchLocation;


    void Update()
    {
        if (movingtoLaunchLocation)
        {

            transform.position = Vector2.Lerp(transform.position, launchDestination, 0.1f);
            if (Vector2.Distance(transform.position, launchDestination) <= .001f)
            {
                movingtoLaunchLocation = false;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (move)
        {
            rig.velocity = direction * speed * Time.fixedDeltaTime;
        }

        if(ballStopped)
        {
            rig.velocity = new Vector3(0, 0, 0);
        }
    }

    public void StartMoving()
    {
        move = true;
        ballStopped = false;
    }

    public void StopMoving()
    {
        if (startCheckingMove)
        {
            ballStopped = true;
            move = false;
            rig.velocity = Vector2.zero;
        }
    }

    public void SetLaunchDestination(Vector3 destination)
    {
        StopMoving();
        laucherCollidePosition = transform.position;
        launchDestination = destination;
        movingtoLaunchLocation = true;
    }
          
    public void SetDirection(Vector3 target)
    {
        direction = target;
    }

    public void Shoot()
    {
        move = true;
        ballStopped = false;
        startCheckingMove = false;
        movingtoLaunchLocation = false;
        StartCoroutine(Co_Shoot());
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "BallCollect")
         {
             Destroy(collision.gameObject);
            
            Launcher.Instance().AddBall(transform.position,direction);  

        }
       
    }
    IEnumerator Co_Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        startCheckingMove = true;
    }
}
