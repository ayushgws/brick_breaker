using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    [SerializeField] private AudioSource background_audioSource;
    [SerializeField] private AudioSource sfx_AudioSource;

    [SerializeField] private AudioClip backgroundSound;
    [SerializeField] private AudioClip collideSound;
    [SerializeField] private AudioClip gameoverSound;
    [SerializeField] private AudioClip gamewinSound;

    [SerializeField] private bool gameoverSoundPlayed;
    [SerializeField] private bool gamewinSoundPlayed;
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
<<<<<<< HEAD
        //soundplayed = false;
=======
        CheckSetting();
    }

    public void CheckSetting()
    {
        sfx_AudioSource.mute = (PlayerPrefs.GetInt("Sound",1)==1)?false:true;
        background_audioSource.mute = (PlayerPrefs.GetInt("Music", 1) == 1) ? false : true;
>>>>>>> 12d87bbf0156a253eb840f917e36f2bfebb50b7c
    }

    public void PlayCollideSound()
    {
        sfx_AudioSource.clip = collideSound;
        sfx_AudioSource.Play();
    }
    public void GameOverSound()
    {

        if (!gameoverSoundPlayed)
        {
            sfx_AudioSource.clip = gameoverSound;
            sfx_AudioSource.Play();
            gameoverSoundPlayed = true;
        }
       
    }

    public void GameWinSound()
    {
        sfx_AudioSource.clip = gamewinSound;
        sfx_AudioSource.Play();
        gamewinSoundPlayed = true;
    }
}
