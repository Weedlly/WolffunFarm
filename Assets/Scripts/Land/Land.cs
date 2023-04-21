using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum LandStatusType{ 
        Idle,
        Growing,
        EndOfLife,
        WorkerDoing
    }
public class Land : MonoBehaviour
{
    private float _timeToEndOfLife;
    [SerializeField] private Product _growingProduct;
    [SerializeField] private int _numberHarvested;
    [SerializeField] private int _currentLifecycle;
    [SerializeField] private float _nextStatusTime;
    [SerializeField] private LandStatusType _landStatus;
    [SerializeField] private TMP_Text _productTitle;
    [SerializeField] private TMP_Text _nextStatusTimeText;  
    [SerializeField] private TMP_Text _numberHarvestedText;  
    public Product GrowingProduct{
        set {_growingProduct = value;}
        get{return _growingProduct;}
    }
    public int NumberHarvested{
        get{return _numberHarvested;}
    }
    public int CurrentLifeCycle{
        set {_currentLifecycle = value;}
        get{return _currentLifecycle;}
    }
    
    public float NextStatusTime{
        set{_nextStatusTime = value;}
        get{return _nextStatusTime;}
    }
    
    public LandStatusType LandStatus{
        set{_landStatus = value;}
        get{return _landStatus;}
    }
    void Start() {
        _landStatus = LandStatusType.Idle;
    }
    void Update()
    {
        if(_growingProduct != null){
            if(_nextStatusTime < 0){
                _nextStatusTimeText.text =((int)_nextStatusTime).ToString() +" "+ LandStatusType.WorkerDoing;
            }
            else{
                _nextStatusTimeText.text = ((int)_nextStatusTime).ToString() + " " + _landStatus;
            }
            _numberHarvestedText.gameObject.SetActive(true);
            _numberHarvestedText.text = "X" + _numberHarvested.ToString();
        }else{
            _productTitle.text = "None";
            _numberHarvestedText.gameObject.SetActive(false);
            _nextStatusTimeText.text = LandStatusType.Idle.ToString();
        }
    }
    public void UserActionHandler(){
        WareHouse.Bin bin = GrowingProductController.ProductBinGrowing;
        bool IsCropping = CroppingProductController.IsCroppingProduct;
        if(bin != null && bin.IsEnoughSeed()){         
            UserPlantingProduct(bin);
        }
        else if(IsCropping == true){
            UserCroppingProduct();
        }
    }
    private void UserPlantingProduct(WareHouse.Bin bin){
        bin.UsingASeed();

        _growingProduct = bin.ProductOfBin;

        _productTitle.text = _growingProduct.Name;
        _nextStatusTime = DataLive.Instance.UserResource.Equipment.RemainTimeAfterBuff(_growingProduct.GrowingTime);

        _numberHarvested = 0;
        _currentLifecycle = 0;

        _landStatus = LandStatusType.Growing;

        LandTaskController.AddToLandTaskController(this);
    }

    private void UserCroppingProduct(){
        if(_numberHarvested > 0 && (_landStatus == LandStatusType.Growing || _landStatus == LandStatusType.EndOfLife)){
            Cropping();
            NextStatus();
        }
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
