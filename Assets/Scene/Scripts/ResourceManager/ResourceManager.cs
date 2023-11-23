using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private List<Resources> resources;

    private static ResourceManager instance;

    public static ResourceManager Instance()
    {
        return instance;
    }
    


    // Start is called before the first frame update
    void Start()
    {
        GetLocalStore();
    }

    public void GetLocalStore()
    {
        for (int i = 0; i < resources.Count; i++)
        {

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Resources
{
    public string name;
    public int count;
    public string PrefName;
}
