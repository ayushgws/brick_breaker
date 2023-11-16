using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private bool startGame;

    private bool isPaused;
    public static GameManager Instance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {

    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused= false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

     

}
