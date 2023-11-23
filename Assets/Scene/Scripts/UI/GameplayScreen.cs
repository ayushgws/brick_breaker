using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{

    //GameObject ballObject = PoolingManager.Instance().GetPrefab("Ball");
    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnMultiply;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtLevel;
    void Start()
    {
        btnPause.onClick.AddListener(Pause);
        txtLevel.text = "Level "+SceneManager.GetActiveScene().name.Substring(5);
        btnMultiply.onClick.AddListener(MultiplyBalls);
    }

    public void ShowScore()
    {
        txtScore.text = ScoreManager.Instance().GetScore().ToString();
    }
    
    public void Pause()
    {
       
        GameplayUI.Instance().OpenPauseScreen();
        Time.timeScale = 0;

    }

    public void MultiplyBalls()
    {

        Launcher.Instance().Multiply();

    }

}
