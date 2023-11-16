using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnRestart;
    
    public void Start()
    {
        btnRestart.onClick.AddListener(RestartLevel);
        btnMenu.onClick.AddListener(OpenMenu);
        btnResume.onClick.AddListener(Resume);
     
    }

    private void RestartLevel()
    {
        Time.timeScale = 1;
        SceneLoader.Instance().RestartCurrentLevel();
    }
    private void OpenMenu()
    {
        Time.timeScale = 1;
        SceneLoader.Instance().OpenHomeScene();
    }
    private void Resume()
    {
        
        Time.timeScale = 1;
        GameManager.Instance().Resume();
        GameplayUI.Instance().ShowGamePlayScreen();
    }
}
