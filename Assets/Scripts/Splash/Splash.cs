using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{

    [SerializeField] private float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SplashTimer());
    }

    IEnumerator SplashTimer()
    {
        yield return new WaitForSeconds(time);
        SceneLoader.Instance().OpenHomeScene();
    }
   
}
