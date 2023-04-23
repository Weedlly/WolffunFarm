using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellProductController : MonoBehaviour
{

    ///<sumary>
    /// Control the selling of products in a warehouse 
    ///</sumary>
    public List<WareHouse.Bin> _bins;
    public List<SellProductView> _sellProductViews;
    public Button _showProductBt;
    public GameObject _products;
    void Start()
    {
        _bins = DataLive.Instance.UserResource.UserWareHouse.ProductBins;
        InitButtonOnClick();
    }
    void Update()
    {
        for (int i = 0; i < _bins.Count && i < _sellProductViews.Count; i++)
        {
            _sellProductViews[i].UpdateSellProductView(_bins[i]);
        }
    }
    void InitButtonOnClick()
    {
        for (int i = 0; i < _bins.Count && i < _sellProductViews.Count; i++)
        {
            WareHouse.Bin bin = _bins[i];
            _sellProductViews[i]._sellingProductBt.onClick.AddListener(
                delegate
                {
                    SellProductButtonClick(bin);
                });
        }
        _showProductBt.onClick.AddListener(
            delegate
            {
                ShowProductHandler(_products);
            });
    }

    void SellProductButtonClick(WareHouse.Bin bin)
    {
        if (DataLive.Instance.UserResource.SellProduct(bin))
        {
            Debug.Log("Sold " + bin.ProductOfBin.Name);
            return;
        }
        Debug.Log("Not enough Harvested product");
    }
    void ShowProductHandler(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
