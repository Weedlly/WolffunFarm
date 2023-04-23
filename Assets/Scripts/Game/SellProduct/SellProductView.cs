using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SellProductView : MonoBehaviour
{
    ///<sumary>
    /// Responsible for updating the UI elements that display informatio
    /// about a single product that can be sold by the user
    ///</sumary>
    public TMP_Text _price;
    public Button _sellingProductBt;
    private const string CONST_POSTFIX = "Coin";

    public void UpdateSellProductView(WareHouse.Bin bin)
    {
        _price.text = bin.ProductOfBin.SellingPrice.ToString() + " " + CONST_POSTFIX;
    }
}
