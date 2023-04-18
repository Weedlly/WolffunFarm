using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Land : MonoBehaviour
{
    public enum LandStatusType{ 
        Idle,
        Planting,
        Cropping,
        Reset

    }
    private float _timeToReset = 60f * 60f;
    [SerializeField] private Product _growingProduct;
    public Product GrowingProduct{
        set {_growingProduct = value;}
        get{return _growingProduct;}
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
                ResetLand();
                break;
            }
            case LandStatusType.Planting:{
                _currentLifecycle = 1;
                _nextStatusTime = _growingProduct.GrowingTime;
                _landStatus = LandStatusType.Cropping;
                break;
            }
            case LandStatusType.Cropping:{
                if(_currentLifecycle != _growingProduct.Lifecycle - 1){
                    _landStatus = LandStatusType.Reset;
                    _nextStatusTime = _timeToReset;
                }else{
                    _currentLifecycle ++;
                    _nextStatusTime = _growingProduct.GrowingTime;
                }
                break;
            }
            case LandStatusType.Reset:{
                if(_nextStatusTime > 0f){
                    //Crooping and reset
                }
                else{
                    // Cropping full lifecycle time is over
                    ResetLand();
                }
                _landStatus = LandStatusType.Idle;
                break;
            }
        }
    }
    void ResetLand(){
        _growingProduct = null;
        _currentLifecycle = 0;
        _nextStatusTime = 0f;
    }
    public void SetGrowingProduct(){
        _growingProduct = GrowingProductController._productGrowing;
        _productTitle.text = _growingProduct.Name;
        _landStatus = LandStatusType.Planting;
        _nextStatusTime = _growingProduct.GrowingTime;
        LandTaskController.AddToLandTaskController(this);
    }
    void Update()
    {
        if(_growingProduct != null){
            if( _nextStatusTime < 0){
                _nextStatusTimeText.text = "Waitting";
            }
            else{
                _nextStatusTimeText.text = _nextStatusTime.ToString();
            }
            
        }
    }
}
