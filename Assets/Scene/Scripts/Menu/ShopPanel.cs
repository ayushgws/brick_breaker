using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPanel : MonoBehaviour
{


    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnBuy;

    //[SerializeField] private TextMeshProUGUI btnText;
   // [SerializeField] private TextMeshProUGUI btnCoinText;

    private int btnCoin;
    private int btntext1;
    // Start is called before the first frame update
    void Start()
    {
        btnClose.onClick.AddListener(Close);
        btnBuy.onClick.AddListener(Buy);
    }


    private void Close()
    {
        MenuController.Instance().OpenHome();
    }
    private void Buy()
    {
       ShopCost.Instance().buyCoin();   
        
        //Debug.Log(btnText.text);
    }
}
