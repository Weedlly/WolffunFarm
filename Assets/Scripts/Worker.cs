using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker
{
    public enum TaskType{ 
        Idle,
        Planting,
        Growing,
    }
    [SerializeField] private int _price;
    public float DoingTaskTime = 5f;
    [SerializeField] private TaskType _task;
    public Land CurrentLandWorking;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DoingTaskTime <= 0){
            DoingTaskTime = 5f;
        }
    }
}
