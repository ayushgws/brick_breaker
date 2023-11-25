using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    
    [SerializeField] private TextMeshPro txtCount;
    [SerializeField] private SpriteRenderer imgBrick;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject TouchEffect;

    private int row;
    private int col;

    private int breakCount=5;

    private bool b_GameOver = false;
    private bool b_Waning = false;

    public void SetRowAndCol(int row,int col)
    {
        this.row = row;
        this.col = col;
    }

    public void SetBreakCount(int count)
    {
        this.breakCount = count;
        UpdateBrickImage();
        UpdateBreakCount();
        
    }
    
    private void UpdateBreakCount()
    {
        txtCount.text = breakCount.ToString();
    }

    private void UpdateBrickImage()
    {
        int dif = 20 - breakCount;
        float value = (float)dif / 20;
        imgBrick.color = new Color(value, value, 1, 1);

        //if (ImageLoader.Instance())
        //{
        //    Debug.LogError("Image Change");
        //    imgBrick.sprite = ImageLoader.Instance().GetImage(breakCount);
        //}
    }

    public void BallCollide()
    {
        breakCount--;

        AudioManager.Instance()?.PlayCollideSound();
        if(breakCount > 1) 
        {
            Instantiate(TouchEffect, transform.position, Quaternion.identity);
        }
        if (breakCount == 0)
        {
            
            GridSystem.Instance().BrickDestroyed();
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioManager.Instance().BrickDestroyedSound();

            gameObject.SetActive(false);
        }
        else
        {
            UpdateBreakCount();
            UpdateBrickImage();
        }
    }

    public void GameOverLineTouch()
    {
        if (!b_GameOver)
        {
            GameManager.Instance().GameOver();
            Debug.Log("GameOver");
        }
    }

    public void WarningLineTouch()
    {
        if (!b_Waning)
        {
            Debug.Log("Waning");
            AudioManager.Instance().warningsound();
            WallColorChange.Instance().WarningColor();
        }
    }

   
}
