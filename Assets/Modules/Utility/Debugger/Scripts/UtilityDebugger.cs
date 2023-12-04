using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityDebugger : MonoBehaviour
{
    private static UtilityDebugger instance;

    public static UtilityDebugger Instance { get { return instance; } }

    [SerializeField] private bool showInformation;
    [SerializeField] private bool showWarning;
    [SerializeField] private bool showError;

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowDebugInformation(string message)
    {
        if (showInformation)
        {
            Debug.Log(message);
        }
    }
    public void ShowWarning(string message)
    {
        if (showWarning)
        {
            Debug.LogWarning(message);
        }
    }
    public void ShowError(string message)
    {
        if (showError)
        {
            Debug.LogError(message);
        }
    }
}
