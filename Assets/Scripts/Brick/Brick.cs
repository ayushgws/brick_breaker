using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class BrickColor
{
    public Color32 startColor;
    public Color32 endColor;
}


public class Brick : MonoBehaviour
{
    
    [SerializeField] private TextMeshPro txtCount;
    [SerializeField] private SpriteRenderer imgBrick;
    [SerializeField] private GameObject touchEffect;
    [SerializeField] private GameObject explosionEffect;
    private BrickColor color;

    private int row;
    private int col;

    private int breakCount=5;

    private bool b_GameOver = false;
    private bool b_Waning = false;
    private int maxBreakStrength = 20;

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

    public void SetMaxBreakStrength(int maxBreakStrength)
    {
        this.maxBreakStrength = maxBreakStrength;
    }
    
    public void SetColor(BrickColor color)
    {
       this.color = color;
    }
    
    private void UpdateBreakCount()
    {
        txtCount.text = breakCount.ToString();
    }

    private void UpdateBrickImage()
    {
        
        int dif = maxBreakStrength - breakCount; 
        float value = (float)dif / maxBreakStrength;
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
        if(breakCount >= 1) 
        {
            Instantiate(touchEffect, transform.position, Quaternion.identity);
        }
        if (breakCount == 0)
        {
            
            GridSystem.Instance().BrickDestroyed();
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            //Instantiate(boomEffect, transform.position, Quaternion.identity);
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
