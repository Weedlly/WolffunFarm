using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public enum UserActionTypeEnum{
    GrowingProduct,
    CroppingProduct,
    SellingProduct
}
public class UserToolController : MonoBehaviour
{
    
    static public Product _productGrowing;
    static public UserActionTypeEnum _userActionTypeEnum;
    public EventSystem _eventSystem;
    void Start()
    {
        
    }
    public void SetProductGrowing(Product product){
        _productGrowing = product;
        _userActionTypeEnum = UserActionTypeEnum.GrowingProduct;
    }
    // Update is called once per frame
    void Update()
    {
        if(_eventSystem.currentSelectedGameObject != null){
            GameObject go = _eventSystem.currentSelectedGameObject;
            Debug.Log(go); 
        }
    }
}
