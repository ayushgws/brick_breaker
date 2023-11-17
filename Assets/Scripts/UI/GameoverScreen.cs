using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameoverScreen : MonoBehaviour
{

    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnContinue;

    [SerializeField] private TextMeshProUGUI txtScore;

    private void Start()
    {
        btnRestart.onClick.AddListener(RestartLevel);
        btnMenu.onClick.AddListener(OpenMenu);
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

}
