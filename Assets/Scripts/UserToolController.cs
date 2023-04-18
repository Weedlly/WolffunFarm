using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class UserToolController : MonoBehaviour
{
    enum UserActionTypeEnum{
        GrowingProduct,
        CroppingProduct,
        SellingProduct
    }
    public EventSystem _eventSystem;
    void Start()
    {
        
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
