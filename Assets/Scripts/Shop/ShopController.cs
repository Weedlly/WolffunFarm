using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public List<WareHouse.Bin> _bins;
    public List<ShopView> _shopViews;
    public Button _showProductBt;
    public GameObject _products;
    void Start()
    {
        _bins = DataLive.Instance.UserResource.UserWareHouse.ProductBins;
        InitButtonOnclick();
    }
    void InitButtonOnclick(){
        for (int i = 0; i < _bins.Count && i <_shopViews.Count; i++)
        {
            WareHouse.Bin bin = _bins[i];
            _shopViews[i]._purchaseProductBt.onClick.AddListener(
                    delegate {
                        PurchaseSeed(bin);
                        });
        }
        _showProductBt.onClick.AddListener(
            delegate {
                ShowProductHandler(_products);
            });
    }
    void Update()
    {
        for (int i = 0; i < _bins.Count && i <_shopViews.Count; i++)
        {
            _shopViews[i].UpdateShopView(_bins[i]);
        }
    }
    void PurchaseSeed(WareHouse.Bin bin){
        if(DataLive.Instance.UserResource.PurcharseProduct(bin)){
            Debug.Log("Purcharse " + bin.ProductOfBin.Name );
            return;
        }
        Debug.Log("Not enough money");
    }
    void ShowProductHandler(GameObject gameObject){
        gameObject.SetActive(!gameObject.activeSelf);
    }
}

