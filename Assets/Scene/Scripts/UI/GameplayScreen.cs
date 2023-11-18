using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private Button btnPause;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtLevel;
    void Start()
    {
        btnPause.onClick.AddListener(Pause);
        txtLevel.text = "Level "+SceneManager.GetActiveScene().name.Substring(5);
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
   
    
   
    
}
