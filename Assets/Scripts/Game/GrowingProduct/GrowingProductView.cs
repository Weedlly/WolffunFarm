using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GrowingProductView : MonoBehaviour
{
    ///<sumary>
    ///  Update the UI elements for a specific product bin that is being grown
    ///</sumary>
    public TMP_Text _title;
    public TMP_Text _number;
    public Button _growingProductBt;
    private const string CONST_PREFIX = "Numbers :";

    public void UpdateGrowingProductView(WareHouse.Bin bin)
    {
        _title.text = bin.ProductOfBin.Name;
        _number.text = CONST_PREFIX + bin.NumProductSeed.ToString();
    }
}
