using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private int star1Score;
    [SerializeField] private int star2Score;
    [SerializeField] private int star3Score;

    [SerializeField] private int brickBreakScore;

    private int scoreMultiplier;
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
