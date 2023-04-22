using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTaskController : MonoBehaviour
{
    ///<sumary>
    /// Control lands have product
    ///</sumary>
    [SerializeField]private List<LandView> _landViews;
    // [SerializeField]private LandView _landViewPrefab;
    private List<Land> _lands = new List<Land>();
    private List<Land> _usinglands = new List<Land>();
    private List<Worker> _workers = new List<Worker>();
    const float TIME_UNIT = 1f;
    private float _time = TIME_UNIT;
    private float _timeNeedToBoottrap;
    
    void Start()
    {
        Farmland farmland = DataLive.Instance.UserResource.Farmland;
        _lands = farmland.Lands;
        Debug.Log(_lands.Count);
        for (int i = 0; i < DataLive.Instance.UserResource.NumWorkers; i++)
        {
            _workers.Add(new Worker());
        }
        Bootstrap();
    }
    void Update()
    {

        if((int)_timeNeedToBoottrap >= 0){
            return;
        }
        if(_usinglands.Count != 0 && (_time -= Time.deltaTime) < 0){
            DoingTasks();
            _time = TIME_UNIT;
        }
        // while(DataLive.Instance.UserResource.NumLands > _landViews.Count){
        //     _landViews.Add(Instantiate(_landViewPrefab));
        // }
        
        for (int i = 0; i < _landViews.Count && i < _lands.Count; i++)
        {
            _landViews[i].gameObject.SetActive(true);
            _landViews[i].UpdateLandView(_lands[i]);
            Land land = _lands[i];
            _landViews[i]._userActionBt.onClick.AddListener(
                delegate {
                    UserActionHandler(land);
                    });
        }
        while(DataLive.Instance.UserResource.NumWorkers > _workers.Count){
            _workers.Add(new Worker());
        }
        
    }
    void Bootstrap(){
        _timeNeedToBoottrap = DataLive.Instance.UserResource.TimeUserOffline();
        Debug.Log("time offline :" + ((int)_timeNeedToBoottrap).ToString());
        while((int)_timeNeedToBoottrap >= 0){
            DoingTasks();
            _timeNeedToBoottrap -= 1f;
        }
    }
    public void AddToUsingLandTaskController(Land land){
        _usinglands.Remove(land);
        _usinglands.Add(land);
    }
    void DoingTasks(){
        RemoveLandsNotUsing();
        DoingLandTask();
        DoingWorkerTask();
    }
    void DoingLandTask(){

        for (int i = 0; i < _usinglands.Count; i++)
        {
            _usinglands[i].NextStatusTime -= TIME_UNIT;
            if(IsNeedWorker(_usinglands[i])){
                Worker worker = FindIdleWorker();
                if(worker != null){
                    worker.CurrentLandWorking = _usinglands[i];
                }
            }
        }
    }
    void DoingWorkerTask(){
        for (int i = 0; i < _workers.Count; i++)
        {
            Land land = _workers[i].CurrentLandWorking;
            if(land != null){
                _workers[i].RemainTaskTime -= TIME_UNIT;
                if(_workers[i].RemainTaskTime <= 0){
                    land.NextStatus();
                    if(land.LandStatus == LandStatusType.EndOfLife){
                        land.Cropping();
                    }
                    land = null;
                    _workers[i].ResetRemainTaskTime();
                }
            }
        }
    }
   
    bool IsLandUsing(Land land){
        if(land.GrowingProduct == null || land.LandStatus == LandStatusType.Idle){
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
    
    bool IsNeedWorker(Land land){
        if(land.NextStatusTime <= 0 && land.LandStatus != LandStatusType.EndOfLife){
            land.NextStatus();
            return true;
        }
        else if((land.NextStatusTime <= 0)){
            return true;
        }
        return false;
    }
    void RemoveLandsNotUsing(){
        _usinglands.RemoveAll(IsLandUsing);
    }   

    void UserActionHandler(Land land){
        Debug.Log("notnull");
        WareHouse.Bin bin = GrowingProductController.ProductBinGrowing;
        bool IsCropping = CroppingProductController.IsCroppingProduct;
        if(bin != null && bin.IsEnoughSeed()){         
            UserPlantingProduct(bin,land);
        }
        else if(IsCropping == true){
            UserCroppingProduct(land);
        }
    }
    private void UserPlantingProduct(WareHouse.Bin bin,Land land){
        bin.UsingASeed();

        land.GrowingProduct = bin.ProductOfBin;

        land.NextStatusTime = DataLive.Instance.UserResource.Equipment.RemainTimeAfterBuff(land.GrowingProduct.GrowingTime);

        land.NumberHarvested = 0;
        land.CurrentLifeCycle = 0;

        land.LandStatus = LandStatusType.Growing;

        AddToUsingLandTaskController(land);
    }
    private void UserCroppingProduct(Land land){
        if(land.NumberHarvested > 0 && (land.LandStatus == LandStatusType.Growing || land.LandStatus == LandStatusType.EndOfLife)){
            land.Cropping();
            land.NextStatus();
        }
    } 
    
    
}
