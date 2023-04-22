using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public enum LandStatusType{ 
    Idle,
    Growing,
    EndOfLife,
    WorkerDoing
}

public class Land
{
    private float _timeToEndOfLife;
    [SerializeField] private Product _growingProduct;
    [SerializeField] private string _growingProductName;
    [SerializeField] private int _numberHarvested;
    [SerializeField] private int _currentLifecycle;
    [SerializeField] private float _nextStatusTime;
    [SerializeField] private LandStatusType _landStatus; 

    [XmlIgnore]
    public Product GrowingProduct{
        set {_growingProduct = value;}
        get{return _growingProduct;}
    }
    [XmlElement(ElementName = "product")]
    public string GrowingProductName{
        set {_growingProductName = value;}
        get{return _growingProductName;}
    }
    [XmlElement(ElementName = "numberHarvested")]
    public int NumberHarvested{
        set {_numberHarvested = value;}
        get{return _numberHarvested;}
    }
    [XmlElement(ElementName = "currentLifeCycle")]
    public int CurrentLifeCycle{
        set {_currentLifecycle = value;}
        get{return _currentLifecycle;}
    }
    [XmlElement(ElementName = "nextStatusTime")]
    public float NextStatusTime{
        set{_nextStatusTime = value;}
        get{return _nextStatusTime;}
    }
    [XmlElement(ElementName = "landStatus")]
    public LandStatusType LandStatus{
        set{_landStatus = value;}
        get{return _landStatus;}
    }
    public void NextStatus(){
        switch (_landStatus)
        {
            case LandStatusType.Idle:{
                ResetLand();
                break;
            }
            case LandStatusType.Growing:{
                GrowingAction();
                break;
            }
            case LandStatusType.EndOfLife:{
                EndOfLifeAction();
                break;
            }
        }
    }
    
    void ResetLand(){
        _growingProduct = null;
        _currentLifecycle = 0;
        _numberHarvested = 0;
        _nextStatusTime = 0f;
    }
    public void Cropping(){
        Debug.Log(_numberHarvested);
        WareHouse.Bin bin = DataLive.Instance.UserResource.UserWareHouse.FindBinOfProduct(_growingProduct);
        if(bin != null){
            bin.HarvestingProduct(_numberHarvested);
            _numberHarvested = 0;
        }
    }
    void GrowingAction(){
        _currentLifecycle ++;
        _numberHarvested++;
        if(_currentLifecycle == _growingProduct.Lifecycle){
            _nextStatusTime = DataLive.Instance.UserResource.ProductDestroyTime;
            _landStatus = LandStatusType.EndOfLife;
        }else{
            _nextStatusTime = _growingProduct.GrowingTime;
            _landStatus = LandStatusType.Growing;
        }
    }
    void EndOfLifeAction(){
        if(_nextStatusTime > 0f){
            Cropping();
        }
        ResetLand();
        _landStatus = LandStatusType.Idle;
    }
    public bool IsNeedWorker(){
        if(_nextStatusTime <= 0 && _landStatus != LandStatusType.EndOfLife){
            NextStatus();
            return true;
        }
        else if((_nextStatusTime <= 0)){
            return true;
        }
        return false;
    }
    public Product FindProduct(){
        if(_growingProductName != null){
            _growingProduct = DataLive.Instance.UserResource.UserWareHouse.FindProduct(_growingProductName);
        }
        return null;
    }
}
