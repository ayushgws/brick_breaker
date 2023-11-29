using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCost : MonoBehaviour
{
    private static ShopCost instance;

    public static ShopCost Instance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
   public void buyCoin()
    {

    }
}
