using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SellProductView : MonoBehaviour
{
    
    public TMP_Text _title;
    public TMP_Text _price;
    public Button _sellingProductBt;
    private const string CONST_POSTFIX = "Coin";

    public void UpdateSellProductView(WareHouse.Bin bin)
    {
        _title.text = bin.ProductOfBin.Name;
        _price.text = bin.ProductOfBin.SellingPrice.ToString() + " " + CONST_POSTFIX;
    }
}
