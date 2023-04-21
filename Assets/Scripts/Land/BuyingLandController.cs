using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyingLandController : MonoBehaviour
{
    public Button _buyingLandBt;
    void Start()
    {
        _buyingLandBt.onClick.AddListener(BuyingLandButtonOnClick);
    }
    void BuyingLandButtonOnClick(){
       if(DataLive.Instance.UserResource.BuyLand()){
            Debug.Log("Bought a land");
            return;
        }
        Debug.Log("Not enough money");
    }
}
