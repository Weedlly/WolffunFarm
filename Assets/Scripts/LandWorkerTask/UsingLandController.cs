using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingLandController
{
    private List<Land> _usinglands;
    public List<Land> Usinglands
    {
        get {
            if(_usinglands == null){
                _usinglands = new List<Land>();
            }
            return _usinglands; 
        }
        set { _usinglands = value; }
    }
    
    public void AddToUsingLandTaskController(Land land){
        if(_usinglands.Contains(land)){
            _usinglands.Remove(land);
        }
        _usinglands.Add(land);
    }
    public void RemoveLandsNotUsing(){
        _usinglands.RemoveAll(IsLandNotUsing);
    }  
    public bool IsLandNotUsing(Land land){
        if(land.GrowingProduct == null || land.LandStatus == LandStatusType.Idle){
            return true;
        }
        return false;
    } 
}


