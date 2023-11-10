using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{

    private static string PREFSTAR = "PREFSTAR";

    private int starCount;

    // Start is called before the first frame update
    void Start()
    {
          starCount = PlayerPrefs.GetInt(PREFSTAR, 0);
    }

    public void UpdateStarCount(int star)
    {
        starCount += star;
        PlayerPrefs.SetInt(PREFSTAR, starCount);
    }

    public int GetStarCount()
    {
        return starCount;
    }

}
