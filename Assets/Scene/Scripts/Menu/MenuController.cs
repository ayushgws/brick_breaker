using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    private static MenuController instance;

    public static MenuController Instance()
    {
        return instance;
    }

    [SerializeField] private GameObject homePanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject achievementPanel;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        OpenHome();
    }

    public void ResetMenu()
    {
        homePanel.SetActive(false);
        levelPanel.SetActive(false);
        settingPanel.SetActive(false);
        achievementPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void OpenSetting()
    {
        homePanel.SetActive(true);
        settingPanel.SetActive(true);
        BackButton.Instance().SetBackButtonCallback(OpenHome);
    }

    public void OpenHome()
    {
        ResetMenu();
        homePanel.SetActive(true);
        BackButton.Instance().SetBackButtonCallback(QuitGame);
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
        BackButton.Instance().SetBackButtonCallback(QuitGame);
    }

    public void OpenLevel()
    {
        ResetMenu();
        levelPanel.SetActive(true);
        BackButton.Instance().SetBackButtonCallback(OpenHome);
    }

    public void OpenAchievement()
    {
        ResetMenu();
        achievementPanel.SetActive(true);
    }

    public void OpenShop()
    {
        ResetMenu();
        shopPanel.SetActive(true);
        homePanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }



}
