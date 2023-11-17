using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Button btnClose;
    // Start is called before the first frame update
    void Start()
    {
        btnClose.onClick.AddListener(Close);
    }


    private void Close()
    {
        MenuController.Instance().OpenHome();
    }
}
