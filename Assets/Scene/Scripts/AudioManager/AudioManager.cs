using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    [SerializeField] private AudioSource background_audioSource;
    [SerializeField] private AudioSource sfx_AudioSource;

    [SerializeField] private AudioClip backgroundSound;
    [SerializeField] private AudioClip collideSound;
    public static AudioManager Instance()
    {
        return instance;
    }

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

    private void Start()
    {
        background_audioSource.clip = backgroundSound;
        background_audioSource.Play();
        CheckSetting();
    }

    public void CheckSetting()
    {
        sfx_AudioSource.mute = (PlayerPrefs.GetInt("Sound",1)==1)?false:true;
        background_audioSource.mute = (PlayerPrefs.GetInt("Music", 1) == 1) ? false : true;
    }

    public void PlayCollideSound()
    {
        sfx_AudioSource.clip = collideSound;
        sfx_AudioSource.Play();
    }
}
