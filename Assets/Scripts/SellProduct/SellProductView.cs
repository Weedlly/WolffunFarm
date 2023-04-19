using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SellProductView : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _productBt;
    private const string CONST_POSTFIX = "Coin";

    public void UpdateSellProductView(WareHouse.Bin bin)
    {
        _title.text = bin.ProductOfBin.Name;
        _price.text = bin.ProductOfBin.BuyingPrice.ToString() + " " + CONST_POSTFIX;
    }
}
