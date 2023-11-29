using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
   public static Toast Instance { get; private set; }

    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI txtMessage;
    [SerializeField] private Button btnClose;
    private void Awake()
    {
        if (Instance) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        btnClose.onClick.AddListener(Close);
    }

    public void ShowMessage(string message)
    {
        messagePanel.SetActive(true);
        txtMessage.text = message;
    }

    public void Close()
    {
        messagePanel.SetActive(false);
    }
}
