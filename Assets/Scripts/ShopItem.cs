using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ShopItemType
{
    Ball,
    Skin,
    MultipleBall

}

public class ShopItem : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private int itemCount;
    
    [SerializeField] private ShopItemType itemType;
    [SerializeField] private Button buy;
    [SerializeField] private TextMeshProUGUI txtCost;
    [SerializeField] private TextMeshProUGUI txtCount;
    [SerializeField] private TextMeshProUGUI txtItemName;

    private void Start()
    {
        buy.onClick.AddListener(Purchase);
        txtCount.text = itemCount.ToString();
        txtCost.text = amount.ToString();
    }

    private void Purchase()
    {
        if (amount <= ResourceManager.Instance().GetCount("Coin"))
        {
            switch (itemType)
            {
                case ShopItemType.Ball:
                    ResourceManager.Instance().AddData("Ball", itemCount);
                    ResourceManager.Instance().AddData("Coin", -amount);
                    MenuController.Instance().UpdateResource();
                    break;
            }
        }
        else
        {
            Toast.Instance.ShowMessage("Not Enough Coin");
        }
    }
}
