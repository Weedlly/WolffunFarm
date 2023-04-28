using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public enum LandStatusType
{
    Idle,
    Growing,
    EndOfLife,
    WorkerDoing
}

public class Land
{
    ///<sumary>
    /// Represents a plot of land in a game
    /// It contains properties such as the product currently growing on it, its lifecycle, and its status
    /// And managing the status of the land
    ///</sumary>
    private float _timeToEndOfLife;
    private Product _growingProduct;
    private string _growingProductName;
    private int _numberHarvested;
    private int _currentLifecycle;
    private float _nextStatusTime;
    private float _oneCycleTime;
    private LandStatusType _landStatus;
    private float _workerDoingTime;
    [XmlIgnore]
    public Product GrowingProduct
    {
        set { _growingProduct = value; }
        get { return _growingProduct; }
    }
    [XmlElement(ElementName = "product")]
    public string GrowingProductName
    {
        set { _growingProductName = value; }
        get { return _growingProductName; }
    }
    [XmlElement(ElementName = "numberHarvested")]
    public int NumberHarvested
    {
        set { _numberHarvested = value; }
        get { return _numberHarvested; }
    }
    [XmlElement(ElementName = "currentLifeCycle")]
    public int CurrentLifeCycle
    {
        set { _currentLifecycle = value; }
        get { return _currentLifecycle; }
    }
    [XmlElement(ElementName = "nextStatusTime")]
    public float NextStatusTime
    {
        set { _nextStatusTime = value; }
        get { return _nextStatusTime; }
    }
    [XmlElement(ElementName = "oneCycleTime")]
    public float OneCycleTime
    {
        set { _oneCycleTime = value; }
        get { return _oneCycleTime; }
    }
    [XmlElement(ElementName = "landStatus")]
    public LandStatusType LandStatus
    {
        set { _landStatus = value; }
        get { return _landStatus; }
    }
    [XmlElement(ElementName = "workerDoingTime")]
    public float WorkerDoingTime
    {
        get { return _workerDoingTime; }
        set { _workerDoingTime = value; }
    }
    public void NextStatus()
    {
        switch (_landStatus)
        {
            case LandStatusType.Idle:
                {
                    ResetLand();
                    break;
                }
            case LandStatusType.Growing:
                {
                    GrowingAction();
                    break;
                }
            case LandStatusType.EndOfLife:
                {
                    EndOfLifeAction();
                    break;
                }
        }
    }

    void ResetLand()
    {
        _growingProduct = null;
        _currentLifecycle = 0;
        _numberHarvested = 0;
        _nextStatusTime = 0f;
        _oneCycleTime = 0f;
    }
    public void Cropping()
    {
        if (_growingProduct != null)
        {
            WareHouse.Bin bin = DataLive.Instance.UserResource.UserWareHouse.FindBinOfProduct(_growingProduct);
            if (bin != null)
            {
                bin.HarvestingProduct(_numberHarvested);
                _numberHarvested = 0;
            }
        }
    }
    void GrowingAction()
    {
        _currentLifecycle++;
        _numberHarvested++;
        if (_currentLifecycle == _growingProduct.Lifecycle)
        {
            _nextStatusTime = DataLive.Instance.UserResource.ProductDestroyTime;
            _landStatus = LandStatusType.EndOfLife;
        }
        else
        {
            _nextStatusTime = _oneCycleTime;
            _landStatus = LandStatusType.Growing;
        }
    }
    void EndOfLifeAction()
    {
        if (_nextStatusTime > 0f)
        {
            Cropping();
        }
        ResetLand();
        _landStatus = LandStatusType.Idle;
    }
    public bool IsNeedWorker()
    {
        if (_nextStatusTime <= 0)
        {
            return true;
        }
        return false;
    }
    public Product FindProduct()
    {
        if (_growingProductName != null)
        {
            _growingProduct = DataLive.Instance.UserResource.UserWareHouse.FindProduct(_growingProductName);
        }
        return null;
    }
    public bool PlantingOnLand(WareHouse.Bin bin)
    {
        if (bin.UsingASeed())
        {
            Product product = bin.ProductOfBin;
            _growingProduct = product;
            _growingProductName = product.Name;
            _oneCycleTime = DataLive.Instance.UserResource.Equipment.RemainTimeAfterBuff(product.GrowingTime);
            _nextStatusTime = _oneCycleTime;
            _numberHarvested = 0;
            _currentLifecycle = 0;
            _landStatus = LandStatusType.Growing;
            return true;
        }
        return false;
    }
}
