using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker
{
    private int _price;
    private float _taskFinishingTime;
    private float _remainTaskTime;
    private Land _currentLandWorking;
    public int Price{
        set{_price = value;}
        get{return _price; }
    }
    public float TaskFinishingTime
    {
        get { return _taskFinishingTime; }
        set { _taskFinishingTime = value; }
    }
    
    public float RemainTaskTime
    {
        get { return _remainTaskTime; }
        set { _remainTaskTime = value; }
    }
    public Land CurrentLandWorking
    {
        get { return _currentLandWorking; }
        set { _currentLandWorking = value; }
    }

    public void ResetRemainTaskTime(){
        if(RemainTaskTime <= 0){
            RemainTaskTime = TaskFinishingTime;
            Debug.Log("reset doing task time");
        }
    }
    public Worker(int price,float taskFinishingTime){
        _price = price;
        _taskFinishingTime = taskFinishingTime;
    }
}
