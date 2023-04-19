using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum LandStatusType{ 
        Idle,
        Growing,
        EndOfLife
    }
public class Land : MonoBehaviour
{
    
    private float _timeToEndOfLife = 6f;
    [SerializeField] private Product _growingProduct;
    public Product GrowingProduct{
        set {_growingProduct = value;}
        get{return _growingProduct;}
    }
    [SerializeField] private int _numberProducing;
    public int NumberProducing{
        get{return _numberProducing;}
    }
    [SerializeField] private TMP_Text _productTitle;
    [SerializeField] private TMP_Text _nextStatusTimeText;
    [SerializeField] private int _currentLifecycle;
    [SerializeField] private float _nextStatusTime;
    [SerializeField] private LandStatusType _landStatus;
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
    public void NextStatus(){
        switch (_landStatus)
        {
            case LandStatusType.Idle:{
                
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
        Debug.Log(_numberProducing);
        _numberProducing = 0;
        // Add number

    }
    void ResetLand(){
        _growingProduct = null;
        _currentLifecycle = 0;
        _numberProducing = 0;
        _nextStatusTime = 0f;
    }
    void EndOfLifeAction(){
        if(_nextStatusTime > 0f){
            //Lifecycle time is over, collect all product
            Cropping();
            ResetLand();
        }
        else{
            // Lifecycle time is over, destroy all product
            ResetLand();
        }
        _landStatus = LandStatusType.Idle;
    }
    void GrowingAction(){
        _currentLifecycle ++;
        _numberProducing++;
        if(_currentLifecycle == _growingProduct.Lifecycle){
            _nextStatusTime = _timeToEndOfLife;
            _landStatus = LandStatusType.EndOfLife;
        }else{
            _nextStatusTime = _growingProduct.GrowingTime;
            _landStatus = LandStatusType.Growing;
        }
    }
    public void SetGrowingProduct(){
        if(UserToolController._productGrowing != null){
            _growingProduct = UserToolController._productGrowing;
            
            _productTitle.text = _growingProduct.Name;
            _nextStatusTime = _growingProduct.GrowingTime;
            LandTaskController.AddToLandTaskController(this);

            _numberProducing = 0;
            _currentLifecycle = 0;
            _nextStatusTime = _growingProduct.GrowingTime;
            _landStatus = LandStatusType.Growing;
        }
    }
    void Update()
    {
        if(_growingProduct != null){
            if(_nextStatusTime < 0){
                _nextStatusTimeText.text =_nextStatusTime.ToString() +" "+ "Waitting";
            }
            else{
                _nextStatusTimeText.text = _nextStatusTime.ToString() + " "+_landStatus;
            }
        }else{
            _nextStatusTimeText.text = "Idle";
        }
    }
}
