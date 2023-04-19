using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopView : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _price;
    public Button _productBt;
    private const string CONST_POSTFIX = "Coin";

    public void UpdateShopView(Product product)
    {
        _title.text = product.Name;
        _price.text = product.BuyingPrice.ToString() + " " + CONST_POSTFIX;
    }
}

