using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private bool startGame;

    private bool isPaused;

    private bool isWin;
    private bool isGameOver;
    public static GameManager Instance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {

    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused= false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

     public void GameOver()
    {
        if (!isGameOver)
        {
            AdsManager.Instance().CheckAdsTime();
            GameplayUI.Instance().OpenGameOver();

            isGameOver = true;
        }
    }

    /*public void Time()
    {
        Invoke("Winner", 3);
    }*/


    public void SetWinner()
    {
        //Invoke(" GameplayUI.Instance().OpenWinnerScreen()", 3);
        string count = SceneManager.GetActiveScene().name.Substring(5);
        int levelCount = int.Parse(count)+1;
        if (PlayerPrefs.GetInt("UnlockedLevel")<levelCount)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelCount);
        }
        
        isWin = true;
    }

    public bool IsWin()
    {
        return isWin;
    }

    public void ShowWinner()
    {
        AdsManager.Instance().CheckAdsTime();
        GameplayUI.Instance().OpenWinnerScreen();
    }
}