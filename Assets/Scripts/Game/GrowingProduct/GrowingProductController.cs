using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class GrowingProductController : MonoBehaviour
{
    ///<sumary>
    ///  Responsible for controlling the growing of products
    ///  Class listens to button clicks on each view and prepares the product for growing
    ///</sumary>
    static public WareHouse.Bin ProductBinGrowing;
    public List<WareHouse.Bin> _bins;
    public List<GrowingProductView> _growingProductViews;
    public Button _showProductBt;
    public GameObject _products;
    public EventSystem _eventSystem;

    void Start()
    {
        _bins = DataLive.Instance.UserResource.UserWareHouse.ProductBins;
        InitButtonOnClick();
    }
    void Update()
    {
        if (_eventSystem.currentSelectedGameObject == null)
        {
            ProductBinGrowing = null;
        }
        for (int i = 0; i < _bins.Count && i < _growingProductViews.Count; i++)
        {
            _growingProductViews[i].UpdateGrowingProductView(_bins[i]);
        }
    }
    void InitButtonOnClick()
    {
        for (int i = 0; i < _bins.Count && i < _growingProductViews.Count; i++)
        {
            WareHouse.Bin bin = _bins[i];
            _growingProductViews[i]._growingProductBt.onClick.AddListener(
                delegate
                {
                    PrepareGrowingProductButtonOnClick(bin);
                });
        }
        _showProductBt.onClick.AddListener(
            delegate
            {
                ShowProductHandler(_products);
            });
    }
    void PrepareGrowingProductButtonOnClick(WareHouse.Bin bin)
    {
        CroppingProductController.IsCroppingProduct = false;
        if (bin.IsEnoughSeed())
        {
            ProductBinGrowing = bin;
            Debug.Log("Prepare growing" + bin.ProductOfBin.Name);
            return;
        }
        ProductBinGrowing = null;
        Debug.Log("Not enough product seed");
    }
    void ShowProductHandler(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
