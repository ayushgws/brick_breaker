using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinnerScreen : MonoBehaviour
{
    
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnNextLevel;

    [SerializeField] private TextMeshProUGUI txtScore;

    public void Start()
    {
        btnRestart.onClick.AddListener(RestartLevel);
        btnMenu.onClick.AddListener(OpenMenu);
        btnNextLevel.onClick.AddListener(NextLevel);
        ShowScore();
    }
    public void ShowScore()
    {
        txtScore.text = ScoreManager.Instance().GetScore().ToString();
    }
    private void RestartLevel()
    {
        
       SceneLoader.Instance().RestartCurrentLevel();

    }

    private void OpenMenu()
    {
        
        SceneLoader.Instance().OpenHomeScene();
    }
    private void NextLevel()
    {
        SceneLoader.Instance().LoadLevel();
    }

}
