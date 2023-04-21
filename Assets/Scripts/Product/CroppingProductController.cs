using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class CroppingProductController : MonoBehaviour
{
    static public bool IsCroppingProduct;
    public Button _croppingProductBt;
    public EventSystem _eventSystem;
    
    void Update()
    {
        if(_eventSystem.currentSelectedGameObject == null){
            IsCroppingProduct = false;
        }
    }
    void Start()
    {
        _croppingProductBt.onClick.AddListener(CroppingProductBtButtonOnClick);
    }
    void CroppingProductBtButtonOnClick(){
       IsCroppingProduct = true;
       GrowingProductController.ProductBinGrowing = null;
    }
}

