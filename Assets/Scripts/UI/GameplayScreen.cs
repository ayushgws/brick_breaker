using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private Button btnPause;

    void Start()
    {
        btnPause.onClick.AddListener(Pause);
    }

    public void Pause()
    {
       
        GameplayUI.Instance().OpenPauseScreen();
        Time.timeScale = 0;
    }
   
    
}
