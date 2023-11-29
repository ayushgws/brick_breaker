using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private List<GridRow> grids;
    [SerializeField] private Transform startLocation;
    private Vector3 startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float width;
    [SerializeField] private float height;
    [SerializeField] private Transform brickParent;

    public int totalBrick;
    public int brickDestroyCount=0;
    private List<Brick> bricks;
    private int maxWallStrength;
    

    private static GridSystem instance;
    public static GridSystem Instance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        GetMaxBrickStrength();
        CreateBricks();
    }
    public void GetMaxBrickStrength()
    {
        for (int i = 0; i < grids.Count; i++)
        {
            for (int j = 0; j < grids[i].row.Count; j++)
            {
                if (maxWallStrength < grids[i].row[j].brickStrength)
                {
                    maxWallStrength = grids[i].row[j].brickStrength;
                }
            }
        }
    }
    public void CreateBricks()
    {
        startPoint = startLocation.position;
        bricks = new List<Brick>();
        for(int i =0;i<grids.Count;i++)
        {
            for(int j = 0; j < grids[i].row.Count; j++)
            {
                if (grids[i].row[j].brickStrength != 0)
                {
                    GameObject gameobjectBrick = PoolingManager.Instance().GetPrefab("Brick");
                    gameobjectBrick.transform.parent = brickParent;
                    gameobjectBrick.transform.position = startPoint;
                    gameobjectBrick.SetActive(true);
                    Brick brick = gameobjectBrick.GetComponent<Brick>();
                    brick.SetMaxBreakStrength(maxWallStrength);
                    brick.SetBreakCount(grids[i].row[j].brickStrength);
                    brick.SetRowAndCol(i, j);
                    
                    bricks.Add(brick);
                    totalBrick++;
                    
                }
                startPoint.x += width;
            }
            startPoint.x = startLocation.position.x;
            startPoint.y -= height;
            
        }
    }

    public void MoveDown()
    {
        brickParent.transform.Translate(0, -height, 0);
    }
  public void BrickDestroyed()
    {

        ScoreManager.Instance().BrickBreak();
        GameplayUI.Instance().UpdateScore();
        
        brickDestroyCount++;


        if (brickDestroyCount >= totalBrick)
        {
            GameManager.Instance().SetWinner();

        }


    }
}

[System.Serializable]
public class GridRow
{
    public List<UnitGrid> row;
}

[System.Serializable]
public class UnitGrid
{
    public int brickStrength;
    public BrickColor color;
}