using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
  
{
    public GameObject[] Star;
     
    [SerializeField] WinnerScreen winnerScreen;
    [SerializeField]  GameObject WinnerPanel; 
    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnMultiply;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtLevel;


    public Image progressbarFill;
    



    private void Awake()
    {
        winnerScreen = WinnerPanel.GetComponent<WinnerScreen>();
    }

    void Start()
    {
        btnPause.onClick.AddListener(Pause);
        txtLevel.text = "Level " + SceneManager.GetActiveScene().name.Substring(5);
                 
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            MultiplyBalls();
            Debug.Log("function called");
        }
    }

    public void ShowScore()
    {
        txtScore.text = ScoreManager.Instance().GetScore().ToString();
       
        UpdateProgressBar();
        ShowStar();
       
    }
    
    public void Pause()
    {
       
        GameplayUI.Instance().OpenPauseScreen();
        Time.timeScale = 0;

    }

    public void MultiplyBalls()
    {
        //Debug.Log("Calling successfully");
       Launcher.Instance().Multiply();

    }
   
    
    
    void UpdateProgressBar()
    {

        
        float fillAmount =  (float)ScoreManager.Instance().GetScore() / winnerScreen.star3Score ;
        progressbarFill.fillAmount = fillAmount;
       
    }
    private void ShowStar()
    {


        if (ScoreManager.Instance().GetScore() >= winnerScreen.star1Score )
        {
            //one Star
            Star[0].SetActive(true);
            Star[3].SetActive(false);
            
        }
        
        if (ScoreManager.Instance().GetScore() >= winnerScreen.star2Score)
        {

            Star[1].SetActive(true);
            Star[4].SetActive(false);

        }
        if(ScoreManager.Instance().GetScore() >= winnerScreen.star3Score)
        {

            Star[2].SetActive(true);
            Star[5].SetActive(false);
        }

    }

}
