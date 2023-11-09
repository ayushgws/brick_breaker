using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private static Launcher instance;
    [SerializeField] private Transform launchPosition;
    private Vector3 launchPoint ;
   
    private Vector3 collectPoint;
    private bool collectPointSet;
    private Vector3 TouchPosition;
    [SerializeField] private int numberOfBalls;
    private List<Ball> ballList;
    public bool launchReady;
    public int collectBallCount;
    public static Launcher Instance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        launchPoint = launchPosition.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            TouchPosition = Camera.main.ScreenToWorldPoint(screenPos);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

           StartCoroutine(ShootBalls());

        }
    }

    IEnumerator ShootBalls()
    {
        Vector3 Direction = Vector3.Normalize(TouchPosition - launchPoint);
        if (launchReady)
        {
            launchReady = false;
            collectPointSet = false;
            if (ballList == null)
            {
                ballList = new List<Ball>();
                
                int firedBall = 0;
                while (numberOfBalls > firedBall)
                {
                    GameObject ballObject = PoolingManager.Instance().GetPrefab("Ball");
                    firedBall++;
                    ballObject.transform.position = launchPoint;
                    ballObject.SetActive(true);
                 
                    Ball ball = ballObject.GetComponent<Ball>();
                    ball.SetDirection(Direction);
                    ball.Shoot();
                    ballList.Add(ball);
                    yield return new WaitForSeconds(.05f);
                }
            }
            else
            {
                for(int i =0;i<ballList.Count;i++)
                {
                    ballList[i].transform.position = launchPoint;
                    ballList[i].SetDirection(Direction);
                    ballList[i].Shoot();
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }

    public void CollectBall(Ball ball)
    {
        
        if (!collectPointSet)
        {
            collectPointSet = true;
            collectPoint = ball.transform.position;
            ball.StopMoving();
        }
        else
        {
            ball.SetLaunchDestination(collectPoint);
        }

        collectBallCount++;
        if(collectBallCount>=numberOfBalls)
        {
            launchReady = true;
            launchPoint = collectPoint;
            collectBallCount = 0;
            GridSystem.Instance().MoveDown();
        }
    }

    public void StartGame()
    {
        launchReady =true;
    }

}

