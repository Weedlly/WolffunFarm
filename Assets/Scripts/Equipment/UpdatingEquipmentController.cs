using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdatingEquipmentController : MonoBehaviour
{
    public Button _updateBt;
    void Start()
    {
        _updateBt.onClick.AddListener(UpdatingButtonOnClick);
    }
    void UpdatingButtonOnClick(){
       if(DataLive.Instance.UserResource.UpdateEquipmentLevel()){
            Debug.Log("Updated equipment");
            return;
        }
        Debug.Log("Not enough money");
    }
}
