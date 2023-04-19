using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public WareHouse _wareHouse;
    public List<ShopView> _shopViews;
    void Start()
    {
        _wareHouse = DataController.LocalLoadXML<UserResource>("UserResource.xml").UserWareHouse;
    }

    void Update()
    {
        for (int i = 0; i < _wareHouse.ProductBins.Count && i <_shopViews.Count; i++)
        {
            Product product = _wareHouse.ProductBins[i].ProductOfBin;
            _shopViews[i]._purchaseProductBt.onClick.AddListener(
                    delegate {
                        PurchaseSeed(product);
                        });
                _shopViews[i].UpdateShopView(_wareHouse.ProductBins[i]);
        }
    }
    void PurchaseSeed(Product product){
        // _userResource.
    }
}

