using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(OpenHomeScene);
    }

    public void OpenHomeScene()
    {
        SceneLoader.Instance().OpenGameScene();
    }
}
