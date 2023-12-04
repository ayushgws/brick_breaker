using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinnerScreen : MonoBehaviour
{
    public GameObject[] Star;

   


    [SerializeField] public int star1Score;
    [SerializeField] public int star2Score;
    [SerializeField] public int star3Score;

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
        BackgroundSound();
        ShowStar();
    }
    public void BackgroundSound()
    {
        AudioManager.Instance().GameWinSound();
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

    private void ShowStar()
    {
        int score;
        
        int.TryParse(txtScore.text, out score);

        if (score >= star1Score)
        {
            //one Star
            Star[0].SetActive(true);
            Star[3].SetActive(false);

        }

        if (score >= star2Score)
        {

            Star[1].SetActive(true);
            Star[4].SetActive(false);

        }
        if (score >= star3Score)
        {

            Star[2].SetActive(true);
            Star[5].SetActive(false);
        }

    }
}
