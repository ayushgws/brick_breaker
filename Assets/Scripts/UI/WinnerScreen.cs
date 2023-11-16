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

    public void Start()
    {
        btnRestart.onClick.AddListener(RestartLevel);
        btnMenu.onClick.AddListener(OpenMenu);
        btnNextLevel.onClick.AddListener(NextLevel);

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
        
    }
}
