using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    private static GameplayUI instance;

    public WinnerScreen script; 

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

    private void Start()
    {
        ShowGamePlayScreen();
    }

    public void ResetScreen()
    {
        gameplayScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameWinnerScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    public void UpdateScore()
    {
        gameplayScreen.GetComponent<GameplayScreen>().ShowScore();
    }

    public void OpenPauseScreen()
    {
        ResetScreen();
        pauseScreen.SetActive(true);
        BackButton.Instance().SetBackButtonCallback(ShowGamePlayScreen);
    }

    public void OpenGameOver()
    {
        ResetScreen();
        gameplayScreen.SetActive(true);
        gameOverScreen.SetActive(true);
        BackButton.Instance().SetBackButtonCallback(OpenHome);
    }

    public void ShowGamePlayScreen()
    {
        ResetScreen();
        gameplayScreen.SetActive(true);
        BackButton.Instance().SetBackButtonCallback(OpenPauseScreen);
    }

    public void OpenWinnerScreen()
    {
        ResetScreen();
        gameplayScreen.SetActive(true);
        gameWinnerScreen.SetActive(true);
        BackButton.Instance().SetBackButtonCallback(OpenHome);
    }

    public void OpenHome()
    {
        SceneLoader.Instance().OpenHomeScene();
    }

    public int Get3StarScore()
    {
        int maxscore;
        maxscore = script.star3Score;  
        return maxscore;
    }
}
