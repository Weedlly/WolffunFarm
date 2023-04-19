using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellProductController : MonoBehaviour
{
    public WareHouse _wareHouse;
    public List<SellProductView> _sellProductViews;
    void Start()
    {
        _wareHouse = DataController.LocalLoadXML<UserResource>("UserResource.xml").UserWareHouse;
    }

    void Update()
    {
        for (int i = 0; i < _wareHouse.ProductBins.Count && i <_sellProductViews.Count; i++)
        {
            _sellProductViews[i].UpdateSellProductView(_wareHouse.ProductBins[i]);
        }
    }
}
