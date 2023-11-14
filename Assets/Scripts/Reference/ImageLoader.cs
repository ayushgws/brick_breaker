using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    private static ImageLoader instance;

    public static ImageLoader Instance()
    {
        return instance;
    }
    [SerializeField] private List<Sprite> textureList;

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
    public Sprite GetImage(int damage)
    {
        return textureList[damage];
    }
}
