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
    public float speed;             //The amount of units that the ball will move each second
    
    public Vector2 direction;       //The Vector2 direction that the ball will move in (eg: diagonal = Vector2(1, 1))
    public Rigidbody2D rig;         //The ball's Rigidbody 2D component
  

    public GameObject upRay;
    public GameObject downRay;
    public GameObject leftRay;
    public GameObject rightRay;
    public GameDirection lastDirection;
    public GameDirection closetEntity;
    public LayerMask layer;

    public float distance = 0.05f;

    public float topDistance;
    public float bottomDistance;
    public float leftDistance;
    public float rightDistance;
    public float closestDistance;
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
                Debug.Log("Stopint Lauch");
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
            rig.mass = 1000;
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
        StartCoroutine(Co_Shoot());
    }

    IEnumerator Co_Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        startCheckingMove = true;
    }
    
  
}
