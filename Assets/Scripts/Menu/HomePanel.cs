using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{

    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnAchievement;
    [SerializeField] private Button btnShop;
    [SerializeField] private Button btnSetting;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(OpenLevel);
        btnAchievement.onClick.AddListener(OpenAchievement);
        btnShop.onClick.AddListener(OpenShop);
        btnSetting.onClick.AddListener(OpenSetting);
    }

    public void OpenLevel()
    {
        MenuController.Instance().OpenLevel();
    }

    public void OpenSetting()
    {
        MenuController.Instance().OpenSetting();
    }

    public void OpenAchievement()
    {
        MenuController.Instance().OpenAchievement();
    }

    public void OpenShop()
    {
        MenuController.Instance().OpenShop();
    }
}
