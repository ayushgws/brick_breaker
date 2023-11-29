using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour, RewardCallback
{

    [SerializeField] private Button btnPlay;
    
    [SerializeField] private Button btnShop;
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button RewardButton;
    [SerializeField] private TextMeshProUGUI txtCoin;
    [SerializeField] private TextMeshProUGUI txtLevelName;
    [SerializeField] private TextMeshProUGUI txtBallCount;

    [SerializeField] private Button btnQuit;
    [SerializeField] private Button btnLevel;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(PlayButton);

        //btnAchievement.onClick.AddListener(OpenAchievement);
        btnShop.onClick.AddListener(OpenShop);
        btnSetting.onClick.AddListener(OpenSetting);
        btnLevel.onClick.AddListener(OpenLevel);
        btnQuit.onClick.AddListener(Quit);
        RewardButton.onClick.AddListener(Reward);

        UpdateCoin();
        UpdateLevel();
        UpdateBallCount();
        AdsManager.Instance().SetRewardCallback(this);

    }

    public void UpdateBallCount()
    {
        txtBallCount.text = ResourceManager.Instance().GetCount("Ball").ToString();
    }

    public void UpdateCoin()
    {
        txtCoin.text = ResourceManager.Instance().GetCount("Coin").ToString();
    }

    public void UpdateLevel()
    {
         level = ResourceManager.Instance().GetCount("Level");
        if(level > ResourceManager.Instance().MaxLevel)
        {
            level = ResourceManager.Instance().MaxLevel;
        }
  
        txtLevelName.text = "PLAY LEVEL "+level.ToString();
    }

    public void Reward()
    {
        AdsManager.Instance().ShowRewardedAd();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        SceneLoader.Instance().OpenLevel("Level" + level);
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



    public void RewardGranted()
    {
        ResourceManager.Instance().AddData("Coin", 30);
        UpdateCoin();
    }
}
