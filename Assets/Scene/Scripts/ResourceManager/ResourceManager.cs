using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private List<Resources> resources;

    private static ResourceManager instance;

    [SerializeField] private int maxLevel;

    public int MaxLevel { get { return maxLevel; } }
    public static ResourceManager Instance()
    {
        return instance;
    }

    

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
        PlayerPrefs.SetInt("UnlockedLevel", 92);
        GetLocalStore();
    }

    public void GetLocalStore()
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (PlayerPrefs.HasKey(resources[i].name))
            {
                resources[i].count = PlayerPrefs.GetInt(resources[i].PrefName, 0);
            }
            else
            {
                PlayerPrefs.SetInt(resources[i].name, resources[i].count);
            }
        }
    }

    public void SaveData(string name, int count)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (resources[i].name == name)
            {
                resources[i].count = count;
                PlayerPrefs.SetInt(resources[i].PrefName, resources[i].count);
            }
        }
    }

    public void AddData(string name,int count)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (resources[i].name == name)
            {
                resources[i].count += count;
                PlayerPrefs.SetInt(resources[i].PrefName, resources[i].count);
            }
        }
    }

    public int GetCount(string name)
    {
        for(int i=0; i<resources.Count;i++)
        {
            if(resources[i].name == name)
            {
                return resources[i].count;
            }
        }
        return 0;
    }
}

[System.Serializable]
public class Resources
{
    public string name;
    public int count;
    public string PrefName;
}
