using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private Button btnPause;
    [SerializeField] private TextMeshProUGUI txtScore;
    void Start()
    {
        btnPause.onClick.AddListener(Pause);
        
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
