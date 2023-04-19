using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellProductController : MonoBehaviour
{
    public List<Product> _products;
    public List<SellProductView> _sellProductViews;
    void Start()
    {
    }

    void Update()
    {
        if(_products != null && _products.Count == _sellProductViews.Count){
            for (int i = 0; i < _products.Count; i++)
            {
                _sellProductViews[i].UpdateSellProductView(_products[i]);
            }
        }
    }
}
