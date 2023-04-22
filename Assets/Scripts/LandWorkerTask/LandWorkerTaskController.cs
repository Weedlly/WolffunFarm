using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandWorkerTaskController : MonoBehaviour
{
    ///<sumary>
    /// Control lands have product
    ///</sumary>
    const float TIME_UNIT = 1f;
    [SerializeField] private List<LandView> _landViews;
    private int _maxLand;
    private List<Land> _lands = new List<Land>();
    private UsingLandController _usingLandController = new UsingLandController();
    private List<Land> _usinglands = new List<Land>();
    private List<Worker> _workers = new List<Worker>();
    private float _time = TIME_UNIT;
    private float _timeNeedToBoottrap;
    private int _numLand;
    
    void Start()
    {
        InitLand();
        InitWorker();
        UserActionButtonOnClick(_lands.Count);
        InitUsingLand();
        Bootstrap();
        _maxLand = _landViews.Count;
    }
    void InitLand(){
        Farmland farmland = DataLive.Instance.UserResource.Farmland;
        _lands = farmland.Lands;
        while(farmland.NumLands > _lands.Count){
            _lands.Add(new Land());
        }
        
        _numLand = farmland.NumLands;
        foreach (var land in _lands)
        {
            land.FindProduct();
        }
    }
    void InitWorker(){
        UserResource userResource = DataLive.Instance.UserResource;
        for (int i = 0; i < userResource.NumWorkers; i++)
        {
            _workers.Add(new Worker(userResource.WorkerPrice,userResource.TaskFinishingTime));
        }
    }
    void UserActionButtonOnClick(int num){
        for (int i = 0; i < num; i++)
        {
            _landViews[i].gameObject.SetActive(true);
            _landViews[i].UpdateLandView(_lands[i]);
            Land land = _lands[i];
            _landViews[i]._userActionBt.onClick.AddListener(
                delegate {
                    UserActionHandler(land);
                    });
        }
    }
    void InitUsingLand(){
        _usinglands = _usingLandController.Usinglands;
        foreach (var land in _lands)
        {
            if(_usingLandController.IsLandNotUsing(land) == false){
                _usingLandController.AddToUsingLandTaskController(land);
            }
        }
    }
    void Bootstrap(){
        _timeNeedToBoottrap = DataLive.Instance.UserResource.TimeUserOffline();
        Debug.Log("User offline time:" + ((int)_timeNeedToBoottrap).ToString());
        while((int)_timeNeedToBoottrap >= 0){
            DoingTasks();
            _timeNeedToBoottrap -= 1f;
        }
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
        if(_lands.Count > _numLand && _numLand < _maxLand){
            UserActionButtonOnClick(_lands.Count);
            _numLand++;
        }
        for (int i = 0; i < _landViews.Count && i < _lands.Count; i++)
        {
            _landViews[i].UpdateLandView(_lands[i]);
        }
        if(DataLive.Instance.UserResource.NumWorkers > _workers.Count){
            UserResource userResource = DataLive.Instance.UserResource;
            _workers.Add(new Worker(userResource.WorkerPrice,userResource.TaskFinishingTime));
        }
        
    }
    void DoingTasks(){
        _usingLandController.RemoveLandsNotUsing();
        DoingLandTask();
        DoingWorkerTask();
    }
    void DoingLandTask(){

        for (int i = 0; i < _usinglands.Count; i++)
        {
            _usinglands[i].NextStatusTime -= TIME_UNIT;
            if(_usinglands[i].IsNeedWorker()){
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
                    land.Cropping();
                    land = null;
                    _workers[i].ResetRemainTaskTime();
                }
            }
        }
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
    void UserActionHandler(Land land){
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
        land.GrowingProductName = land.GrowingProduct.Name;
        land.NextStatusTime = DataLive.Instance.UserResource.Equipment.RemainTimeAfterBuff(land.GrowingProduct.GrowingTime);

        land.NumberHarvested = 0;
        land.CurrentLifeCycle = 0;

        land.LandStatus = LandStatusType.Growing;

        _usingLandController.AddToUsingLandTaskController(land);
    }
    private void UserCroppingProduct(Land land){
        if(land.NumberHarvested > 0 && (land.LandStatus == LandStatusType.Growing || land.LandStatus == LandStatusType.EndOfLife)){
            land.Cropping();
            land.NextStatus();
        }
    } 
}
