using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{

    private static GameplayUI instance;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameplayScreen;
    [SerializeField] private GameObject gameOverScreen;



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

    }

    public void ShowPauseScreen(bool show)
    {
        pauseScreen.SetActive(show);
    }

    public void ShowGameOverScreen(bool show)
    {
        gameOverScreen.SetActive(show);
    }

    public void ShowGamePlayScreen()
    {
            
    }
}
