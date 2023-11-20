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

    [SerializeField] private TextMeshProUGUI txtScore;

     
    void Start()
    {
        btnRestart.onClick.AddListener(RestartLevel);
        btnMenu.onClick.AddListener(OpenMenu);
        btnResume.onClick.AddListener(Resume);
    }

     void OnEnable()
    {
        ShowScore();    
    }
    public void ShowScore()
    {
        //Time.timeScale = 1;
        txtScore.text = ScoreManager.Instance().GetScore().ToString();
       
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
