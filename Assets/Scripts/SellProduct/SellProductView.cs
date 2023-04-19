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

    public void UpdateSellProductView(Product product)
    {
        _title.text = product.Name;
        _price.text = product.PurchasePrice.ToString() + " " + CONST_POSTFIX;
    }
}
