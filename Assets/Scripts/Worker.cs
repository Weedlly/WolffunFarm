using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public enum TaskType{ 
        Idle,
        Planting,
        Growing,
    }
    [SerializeField] private int _price;
    [SerializeField] private float _doingTaskTime;
    [SerializeField] private TaskType _task;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
