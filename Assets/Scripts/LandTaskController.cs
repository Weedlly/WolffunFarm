using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTaskController : MonoBehaviour
{
    ///<sumary>
    /// Control lands  have product
    ///</sumary>
    static public List<Land> _lands = new List<Land>();
    public List<Worker> _workers;
    const float TIME_UNIT = 1f;
    const float TIME_UNIT_REDUCING = 1f;
    private float _time = TIME_UNIT;
    static public void AddToLandTaskController(Land land){
        _lands.Add(land);
    }
    void DoingTask(){
        RemoveLandsNotUsing();
        for (int i = 0; i < _lands.Count; i++)
        {
            _lands[i].NextStatusTime -= TIME_UNIT_REDUCING;
            Debug.Log((int)_lands[i].NextStatusTime);
            if(IsNextToStatus(_lands[i])){
                _lands[i].NextStatus();
            }
        }
    }
    bool IsLandUsing(Land land){
        if(land.GrowingProduct == null){
            return true;
        }
        return false;
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
