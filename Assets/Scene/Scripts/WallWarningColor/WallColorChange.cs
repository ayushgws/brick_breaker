using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer[] WallColor;
    private static WallColorChange instance;




    public static WallColorChange Instance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    public void WarningColor()
    {
        StartCoroutine(ChangeColor());
    }
    public IEnumerator ChangeColor()
    {
        for (int i = 0; i < 4; i++)
        {
            WallColor[i].GetComponent<SpriteRenderer>().color = Color.red;

        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 4; i++)
        {
            WallColor[i].GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
