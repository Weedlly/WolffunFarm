using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;

[XmlRoot(ElementName = "userResource")]
public class UserResource
{
    ///<sumary>
    ///  That defines the properties and methods related to a user's resources in a game
    ///</sumary>
    private int _coin;
    private Equipment _equipment;
    private int _workerPrice;
    private int _numWorkers;
    private int _numIdleWorkers;
    private int _taskFinishingTime;
    private int _productDestroyTime;
    private string _lastOnlineTime;
    private int _targetCoin;
    private WareHouse _userWareHouse;
    private Farmland _farmland;
    private int _numIdleLands;

    [XmlElement(ElementName = "coin")]
    public int Coin
    {
        set { _coin = value; }
        get { return _coin; }
    }
    [XmlElement(ElementName = "equipment")]
    public Equipment Equipment
    {
        set { _equipment = value; }
        get { return _equipment; }
    }
    [XmlElement(ElementName = "numWorkers")]
    public int NumWorkers
    {
        set { _numWorkers = value; }
        get { return _numWorkers; }
    }
    [XmlIgnore]
    public int NumIdleWorkers
    {
        get { return _numIdleWorkers; }
        set { _numIdleWorkers = value; }
    }
    [XmlElement(ElementName = "taskFinishingTime")]
    public int TaskFinishingTime
    {
        set { _taskFinishingTime = value; }
        get { return _taskFinishingTime; }
    }
    [XmlElement(ElementName = "workerPrice")]
    public int WorkerPrice
    {
        set { _workerPrice = value; }
        get { return _workerPrice; }
    }
    [XmlElement(ElementName = "productDestroyTime")]
    public int ProductDestroyTime
    {
        set { _productDestroyTime = value; }
        get { return _productDestroyTime; }
    }
    [XmlElement(ElementName = "lastOnlineTime")]
    public string LastOnlineTime
    {
        set { _lastOnlineTime = value; }
        get { return _lastOnlineTime; }
    }
    [XmlElement(ElementName = "targetCoin")]
    public int TargetCoin
    {
        set { _targetCoin = value; }
        get { return _targetCoin; }
    }
    [XmlElement(ElementName = "wareHouse")]
    public WareHouse UserWareHouse
    {
        set { _userWareHouse = value; }
        get { return _userWareHouse; }
    }
    [XmlElement(ElementName = "farmland")]
    public Farmland Farmland
    {
        set { _farmland = value; }
        get { return _farmland; }
    }
    [XmlIgnore]
    public int NumIdleLands
    {
        get { return _numIdleLands; }
        set { _numIdleLands = value; }
    }

    #region CoinAction
    public bool IsEnoughCoint(int coin)
    {
        if (_coin - coin >= 0)
        {
            return true;
        }
        return false;
    }
    public void AddCoin(int coin)
    {
        _coin += coin;
    }
    public bool ReduceCoin(int coin)
    {
        if (IsEnoughCoint(coin))
        {
            _coin -= coin;
            return true;
        }
        return false;
    }
    #endregion

    #region EquipmentAction
    public bool UpdateEquipmentLevel()
    {
        int price = _equipment.Price;
        if (IsEnoughCoint(price))
        {
            _coin -= price;
            _equipment.Level++;
            return true;
        }
        return false;
    }
    #endregion

    #region WorkerAction
    public bool BuyWorker()
    {
        if (IsEnoughCoint(_workerPrice))
        {
            _coin -= _workerPrice;
            _numWorkers++;
            return true;
        }
        return false;
    }
    #endregion

    #region LandAction
    public bool BuyLand()
    {
        int price = _farmland.LandPrice;
        if (IsEnoughCoint(price))
        {
            _coin -= price;
            _farmland.IncreatingNumLand();
            return true;
        }
        return false;
    }
    #endregion

    #region Product
    public bool SellProduct(WareHouse.Bin bin)
    {
        if (bin.IsEnoughHarvestedProduct())
        {
            _coin += bin.ProductOfBin.SellingPrice;
            bin.NumProductHarvested--;
            return true;
        }
        return false;
    }
    public bool PurcharseProduct(WareHouse.Bin bin)
    {
        int productPrice = bin.ProductOfBin.PurchasePrice;
        if (IsEnoughCoint(productPrice))
        {
            _coin -= productPrice;
            bin.NumProductSeed += bin.ProductOfBin.SellingNumber;
            return true;
        }
        return false;
    }
    #endregion

    #region LastOnlineTime
    public void UpdateCurrentTime()
    {
        _lastOnlineTime = DateTime.Now.ToString();
    }
    public float TimeUserOffline()
    {
        DateTime currentDate = DateTime.Now;
        DateTime lastOnlineTime = DateTime.Parse(_lastOnlineTime);

        long elapsedTicks = currentDate.Ticks - lastOnlineTime.Ticks;
        TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
        return (float)elapsedSpan.TotalSeconds;
    }
    #endregion
    public bool IsWinTheGame()
    {
        if (_coin >= _targetCoin)
        {
            return true;
        }
        return false;
    }
}
