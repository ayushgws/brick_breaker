using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public static class RaycastUtilities
{
    public static bool PointerIsOverUI(Vector2 screenPos)
    {
        var hitObject = UIRaycast(ScreenPosToPointerData(screenPos));
        return hitObject != null && hitObject.layer == LayerMask.NameToLayer("UI");
    }

    static GameObject UIRaycast(PointerEventData pointerData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        return results.Count < 1 ? null : results[0].gameObject;
    }

    static PointerEventData ScreenPosToPointerData(Vector2 screenPos)
       => new(EventSystem.current) { position = screenPos };
}
public class Launcher : MonoBehaviour
{
    public Camera mainCamera;
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
    [SerializeField]private LayerMask layer;
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
        if (launchReady && !GameManager.Instance().IsPaused())
        {

           
            if (Input.GetKeyDown(KeyCode.Mouse0) && RaycastUtilities.PointerIsOverUI(Input.mousePosition))
            {
             
       
                Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                TouchPosition = Camera.main.ScreenToWorldPoint(screenPos);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) && RaycastUtilities.PointerIsOverUI(Input.mousePosition))
            {
             
                StartCoroutine(ShootBalls());

            }
        }
    }

    IEnumerator ShootBalls()
    {
        Vector3 Direction = Vector3.Normalize(TouchPosition - launchPoint);

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
            for (int i = 0; i < ballList.Count; i++)
            {
                ballList[i].transform.position = launchPoint;
                ballList[i].SetDirection(Direction);
                ballList[i].Shoot();
                yield return new WaitForSeconds(0.05f);
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
            if(GameManager.Instance().IsWin())
            {
                GameManager.Instance().ShowWinner();
                return;
            }
            ScoreManager.Instance().ResetMultiplier();
            launchReady = true;
            launchPoint = collectPoint;
            collectBallCount = 0;
            GridSystem.Instance().MoveDown();
        }
    }

    public void  StartGame()
    {
        launchReady =true;
       
    }

}

