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
    [SerializeField] private int _numberHarvested;
    [SerializeField] private int _currentLifecycle;
    [SerializeField] private float _nextStatusTime;
    [SerializeField] private LandStatusType _landStatus; 

    [XmlElement(ElementName = "product")]
    public Product GrowingProduct{
        set {_growingProduct = value;}
        get{return _growingProduct;}
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
    // void Start() {
    //     _landStatus = LandStatusType.Idle;
    // }
    // public void UserActionHandler(){
    //     WareHouse.Bin bin = GrowingProductController.ProductBinGrowing;
    //     bool IsCropping = CroppingProductController.IsCroppingProduct;
    //     if(bin != null && bin.IsEnoughSeed()){         
    //         UserPlantingProduct(bin);
    //     }
    //     else if(IsCropping == true){
    //         UserCroppingProduct();
    //     }
    // }
    // private void UserPlantingProduct(WareHouse.Bin bin){
    //     bin.UsingASeed();

    //     _growingProduct = bin.ProductOfBin;

    //     _nextStatusTime = DataLive.Instance.UserResource.Equipment.RemainTimeAfterBuff(_growingProduct.GrowingTime);

    //     _numberHarvested = 0;
    //     _currentLifecycle = 0;

    //     _landStatus = LandStatusType.Growing;

    //     LandTaskController.AddToLandTaskController(this);
    // }

    // private void UserCroppingProduct(){
    //     if(_numberHarvested > 0 && (_landStatus == LandStatusType.Growing || _landStatus == LandStatusType.EndOfLife)){
    //         Cropping();
    //         NextStatus();
    //     }
    // } 
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
    public void Cropping(){
        Debug.Log(_numberHarvested);
        WareHouse.Bin bin = DataLive.Instance.UserResource.UserWareHouse.FindBinOfProduct(_growingProduct);
        if(bin != null){
            bin.HarvestingProduct(_numberHarvested);
            _numberHarvested = 0;
        }
    }
    void ResetLand(){
        _growingProduct = null;
        _currentLifecycle = 0;
        _numberHarvested = 0;
        _nextStatusTime = 0f;
    }
    void EndOfLifeAction(){
        if(_nextStatusTime > 0f){
            //Lifecycle time is over, collect all product
            Cropping();
        }
        else{
            // Lifecycle time is over, destroy all product
            
        }
        ResetLand();
        _landStatus = LandStatusType.Idle;
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
}
