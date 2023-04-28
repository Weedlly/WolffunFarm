using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandWorkerTaskController : MonoBehaviour
{
    ///<sumary>
    ///  This code controls the production of crops on a farmland.
    ///  It also includes a User Action Handler method that controls the harvesting of crops from a specific land.
    ///</sumary>
    const float TIME_UNIT = 1f;
    private float _time = TIME_UNIT;
    private float _timeNeedToBoottrap;
    [SerializeField] private List<LandView> _landViews;
    
    private List<Land> _lands = new List<Land>();
    private int _maxLand;
    private int _numLand;
    private int _numIdleLands;
    private UsingLandController _usingLandController = new UsingLandController();
    private List<Land> _usinglands = new List<Land>();
    
    private int _numIdleWorkers;
    private int _numTotalWorkers;
    private float _workerDoingTime; 

    void Start()
    {
        UserResource userResource = DataLive.Instance.UserResource;
        InitLand();
        UserActionButtonOnClick(_lands.Count);
        InitUsingLand();

        _workerDoingTime = userResource.TaskFinishingTime;
        _maxLand = _landViews.Count;
        _numTotalWorkers = userResource.NumWorkers;
        _numIdleWorkers = _numTotalWorkers;
        Bootstrap();
    }
    private void InitLand()
    {
        Farmland farmland = DataLive.Instance.UserResource.Farmland;
        _lands = farmland.Lands;
        while (farmland.NumLands > _lands.Count)
        {
            _lands.Add(new Land());
        }

        _numLand = farmland.NumLands;
        foreach (var land in _lands)
        {
            land.FindProduct();
        }
    }
    private void UserActionButtonOnClick(int num)
    {
        for (int i = 0; i < num && i < _landViews.Count; i++)
        {
            _landViews[i].gameObject.SetActive(true);
            _landViews[i].UpdateLandView(_lands[i]);
            Land land = _lands[i];
            _landViews[i]._userActionBt.onClick.AddListener(
                delegate
                {
                    UserActionHandler(land);
                });
        }
    }
    private void InitUsingLand()
    {
        _usinglands = _usingLandController.Usinglands;
        foreach (var land in _lands)
        {
            if (_usingLandController.IsLandNotUsing(land) == false)
            {
                _usingLandController.AddToUsingLandTaskController(land);
            }
        }
    }
    private void Bootstrap()
    {
        _timeNeedToBoottrap = DataLive.Instance.UserResource.TimeUserOffline();
        Debug.Log("User offline time:" + ((int)_timeNeedToBoottrap).ToString());
        while ((int)_timeNeedToBoottrap >= 0)
        {
            DoingTasks();
            _timeNeedToBoottrap -= 1f;
        }
    }
    void Update()
    {
        if ((int)_timeNeedToBoottrap >= 0)
        {
            return;
        }
        if (_usinglands.Count != 0 && (_time -= Time.deltaTime) < 0)
        {
            DoingTasks();
            _time = TIME_UNIT;
        }
        if (_lands.Count > _numLand && _numLand < _maxLand)
        {
            UserActionButtonOnClick(_lands.Count);
            _numLand++;
        }
        for (int i = 0; i < _landViews.Count && i < _lands.Count; i++)
        {
            _landViews[i].UpdateLandView(_lands[i]);
        }
        if (DataLive.Instance.UserResource.NumWorkers > _numTotalWorkers)
        {
            _numTotalWorkers++;
        }
        UpdateIdleLandAndWorker();
    }
    private void DoingTasks()
    {
        _usingLandController.RemoveLandsNotUsing();
        DoingLandTask();
    }
    private void DoingLandTask()
    {
        int busyWorker = 0;
        for (int i = 0; i < _usinglands.Count; i++)
        {
            Land land = _usinglands[i];
            if (land.WorkerDoingTime > 0)
            {
                busyWorker++;
                land.WorkerDoingTime -= TIME_UNIT;
                if(land.WorkerDoingTime <= 0 ){
                    land.NextStatus();
                    land.Cropping();
                }
            }
            else
            {
                land.NextStatusTime -= TIME_UNIT;
                if (land.IsNeedWorker())
                {
                    if(IsExistIdleWorker()){
                        _numIdleWorkers--;
                        land.WorkerDoingTime = _workerDoingTime;
                    }
                    else
                    {
                        if (land.LandStatus != LandStatusType.EndOfLife)
                        {
                            land.NextStatus();
                        }
                    }
                }
            }
        }
        _numIdleWorkers = _numTotalWorkers - busyWorker;
    }
    private bool IsExistIdleWorker()
    {
        if(_numIdleWorkers > 0){
            return true;
        }
        return false;
    }
    private void UpdateIdleLandAndWorker()
    {
        UserResource userResource = DataLive.Instance.UserResource;
        userResource.NumIdleWorkers = _numIdleWorkers;
        userResource.NumIdleLands = _lands.Count - _usinglands.Count;
    }
    private void UserActionHandler(Land land)
    {
        WareHouse.Bin bin = GrowingProductController.ProductBinGrowing;
        bool IsCropping = CroppingProductController.IsCroppingProduct;
        if (bin != null && bin.IsEnoughSeed())
        {
            UserPlantingProduct(bin, land);
        }
        else if (IsCropping == true)
        {
            UserCroppingProduct(land);
        }
    }
    private void UserPlantingProduct(WareHouse.Bin bin, Land land)
    {
        if (land.PlantingOnLand(bin))
        {
            _usingLandController.AddToUsingLandTaskController(land);
        }
    }
    private void UserCroppingProduct(Land land)
    {
        if (land.NumberHarvested > 0 && (land.LandStatus == LandStatusType.Growing || land.LandStatus == LandStatusType.EndOfLife))
        {
            land.Cropping();
            land.NextStatus();
        }
    }
}
