using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{


   
    private int maxscore;

    [SerializeField] private int brickBreakScore;

    private int scoreMultiplier =1;
    private int currentScore;
    private static ScoreManager instance;

    public static ScoreManager Instance() 
    {  return instance; 
    }

    private void Awake()
    {
        instance = this;
    }

    public void BrickBreak()
    {
        currentScore += brickBreakScore * scoreMultiplier;
        scoreMultiplier++;
    }

    public void ResetMultiplier()
    {
        scoreMultiplier = 1;
    }
   

    public int GetScore() { return currentScore; }
   

}
