using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnSound;
    [SerializeField] private Button btnMusic;
    [SerializeField] private GameObject music;
    [SerializeField] private GameObject sound;

    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;


    // Start is called before the first frame update
    void Start()
    {

        btnClose.onClick.AddListener(Close);
        btnSound.onClick.AddListener(ToggleSound);
        btnMusic.onClick.AddListener(ToggleMusic);
    }

    private void OnEnable()
    {
        UpdateImage();
    }

    public void UpdateImage()
    {
        sound.SetActive((PlayerPrefs.GetInt("Sound", 1) == 1) ? true : false);
        music.SetActive((PlayerPrefs.GetInt("Music", 1) == 1) ? true : false);

        //btnSound.GetComponent<Image>().sprite = (PlayerPrefs.GetInt("Sound", 1) == 1) ? soundOn : soundOff;
        //btnMusic.GetComponent<Image>().sprite = (PlayerPrefs.GetInt("Music", 1) == 1) ? musicOn : musicOff;
    }

    private void Close()
    {
        MenuController.Instance().CloseSetting();
    }

    private void ToggleSound()
    {
        PlayerPrefs.SetInt("Sound", (PlayerPrefs.GetInt("Sound", 1)==0)?1:0);
        AudioManager.Instance().CheckSetting();
        UpdateImage();
    }

    private void ToggleMusic()
    {
        PlayerPrefs.SetInt("Music", (PlayerPrefs.GetInt("Music", 1) == 0) ? 1 : 0);
        AudioManager.Instance().CheckSetting();
        UpdateImage();
    }
}
