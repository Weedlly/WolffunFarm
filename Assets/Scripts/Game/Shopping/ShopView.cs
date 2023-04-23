using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopView : MonoBehaviour
{
    ///<sumary>
    /// Updating the UI of a shop view for a given product
    ///</sumary>
    public TMP_Text _title;
    public TMP_Text _price;
    public Button _purchaseProductBt;
    private const string CONST_POSTFIX = "Coin";

    public void UpdateShopView(WareHouse.Bin bin)
    {
        _title.text = bin.ProductOfBin.Name;
        _price.text = bin.ProductOfBin.PurchasePrice.ToString() + " " + CONST_POSTFIX;
    }
}

