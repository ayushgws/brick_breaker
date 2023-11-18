using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private bool startGame;

    private bool isPaused;

    private bool isWin;
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
        GameplayUI.Instance().OpenGameOver();
    }

    /*public void Time()
    {
        Invoke("Winner", 3);
    }*/
    public void Winner()
    {
        //Invoke(" GameplayUI.Instance().OpenWinnerScreen()", 3);
        
        isWin = true;
    }

    public bool IsWin()
    {
        return isWin;
    }

    public void ShowWinner()
    {
        GameplayUI.Instance().OpenWinnerScreen();
    }
}
