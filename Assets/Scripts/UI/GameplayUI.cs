using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    private static GameplayUI instance;
    
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameplayScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameWinnerScreen;

    public static GameplayUI Instance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public void ResetScreen()
    {
        gameplayScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameWinnerScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    public void OpenPauseScreen()
    {
        ResetScreen();
        pauseScreen.SetActive(true);
    }

    public void OpenGameOver()
    {
        ResetScreen();
        gameOverScreen.SetActive(true); ;
    }

    public void ShowGamePlayScreen()
    {
        ResetScreen();
        gameplayScreen.SetActive(true);
    }

    public void OpenWinnerScreen()
    {
        ResetScreen();
        gameWinnerScreen.SetActive(true);
    }
}
