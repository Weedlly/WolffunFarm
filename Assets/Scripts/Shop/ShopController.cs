using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public List<Product> _products;
    public List<ShopView> _shopViewViews;
    public UserResource _userResource;
    void Start()
    {
    }
    void Update()
    {
        if(_products != null && _products.Count == _shopViewViews.Count){
            for (int i = 0; i < _products.Count; i++)
            {
                _shopViewViews[i]._productBt.onClick.AddListener(
                    delegate {
                        BuySeed(_products[i]);
                        });
                _shopViewViews[i].UpdateShopView(_products[i]);
            }
        }
    }
    void BuySeed(Product product){
        // _userResource.
    }
}

