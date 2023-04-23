using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiringWorkerController : MonoBehaviour
{
    ///<sumary>
    /// Handle the logic of hiring workers in the game.
    ///</sumary>
    public Button _hiringBt;
    void Start()
    {
        _hiringBt.onClick.AddListener(HiringWorkerButtonOnClick);
    }
    void HiringWorkerButtonOnClick()
    {
        if (DataLive.Instance.UserResource.BuyWorker())
        {
            Debug.Log("Bought a worker");
            return;
        }
        Debug.Log("Not enough money");
    }
}
