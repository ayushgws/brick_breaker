using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyManager: MonoBehaviour
{

    private static string PREFRUBY = "PREFRuby";

    private int rubyCount;

    // Start is called before the first frame update
    void Start()
    {
        rubyCount = PlayerPrefs.GetInt(PREFRUBY, 0);
    }

    public void UpdateRubyCount(int ruby)
    {
        rubyCount += ruby;
        PlayerPrefs.SetInt(PREFRUBY, rubyCount);
    }

    public int GetRubyCount()
    {
        return rubyCount;
    }

    public bool SubRubyCount(int ruby)
    {
        if(rubyCount< ruby)
        {
            return false;
        }
        else
        {
            rubyCount -= ruby;
            return true;
        }
    }

}
