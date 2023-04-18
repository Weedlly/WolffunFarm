using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTaskController : MonoBehaviour
{
    ///<sumary>
    /// Control lands  have product
    ///</sumary>
    static public List<Land> _lands = new List<Land>();
    public List<Worker> _workers = new List<Worker>();
    const float TIME_UNIT = 1f;
    const float TIME_UNIT_REDUCING = 1f;
    private float _time = TIME_UNIT;
    static public void AddToLandTaskController(Land land){
        _lands.Add(land);
    }
    void DoingTask(){
        RemoveLandsNotUsing();
        for (int i = 0; i < _workers.Count; i++)
        {
            if(_workers[i].CurrentLandWorking != null){
                _workers[i].DoingTaskTime -= TIME_UNIT_REDUCING;
                if(_workers[i].DoingTaskTime <= 0){
                    _workers[i].CurrentLandWorking.NextStatus();
                }
            }
        }
        for (int i = 0; i < _lands.Count; i++)
        {
            _lands[i].NextStatusTime -= TIME_UNIT_REDUCING;
            if(IsNextToStatus(_lands[i])){
                Worker worker = FindIdleWorker();
                if(worker != null){
                    worker.CurrentLandWorking = _lands[i];
                }
            }
        }
    }
    
    bool IsLandUsing(Land land){
        if(land.GrowingProduct == null){
            return true;
        }
        return false;
    }
    Worker FindIdleWorker(){
        for (int i = 0; i < _workers.Count; i++)
        {
            if(_workers[i].CurrentLandWorking == null){
                return _workers[i];
            }
        }
        return null;
    }
    
    bool IsNextToStatus(Land land){
        if(land.NextStatusTime <= 0){
            return true;
        }
        return false;
    }
    void RemoveLandsNotUsing(){
        _lands.RemoveAll(IsLandUsing);
    }
    // void CheckProductGrowing(Land land){
    //     if(land.RemainGrowingTime)
    // }
    void ProductGrowing(){

    }

    void Start()
    {
        _workers.Add(new Worker());
    }
    void Bootstrap(){

    }
    // Update is called once per frame
    void Update()
    {
        if(_lands.Count != 0 && (_time -= Time.deltaTime) < 0){
            DoingTask();
            _time = TIME_UNIT;
        }
    }
}