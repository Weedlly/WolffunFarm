using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker
{
    private int _price;
    public int Price{
        set{_price = value;}
        get{return _price; }
    }
    private float DoingTaskTime = 5f;
    public float RemainTaskTime = 5f;
    public Land CurrentLandWorking;

    public void ResetRemainTaskTime(){
        if(RemainTaskTime <= 0){
            RemainTaskTime = DoingTaskTime;
            Debug.Log("reset doing task time");
        }
    }
 
}
