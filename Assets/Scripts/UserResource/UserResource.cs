using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;

[XmlRoot(ElementName = "userResource")]
public class UserResource 
{
    private int _coin;
    private Equipment _equipment;
    private int _numWorkers;
    private int _land;
    private WareHouse _userWareHouse;
    private string _lastOnlineTime;
    private int _targetCoin;

    [XmlElement(ElementName = "coin")]
    public int Coin{
        set{_coin = value;}
        get{return _coin; }
    }
    [XmlElement(ElementName = "equipment")]
    public Equipment Equipment{
        set{_equipment = value;}
        get{return _equipment; }
    }
    [XmlElement(ElementName = "numWorkers")]
    public int NumWorkers{
        set{_numWorkers = value;}
        get{return _numWorkers; }
    }
    [XmlElement(ElementName = "numLands")]
    public int NumLands{
        set{_land = value;}
        get{return _land; }
    }
    [XmlElement(ElementName = "wareHouse")]
    public WareHouse UserWareHouse{
        set{_userWareHouse = value;}
        get{return _userWareHouse; }
    }
    [XmlElement(ElementName = "lastOnlineTime")]
    public string LastOnlineTime{
        set{_lastOnlineTime = value;}
        get{return _lastOnlineTime; }
    }
    [XmlElement(ElementName = "targetCoin")]
    public int TargetCoin{
        set{_targetCoin = value;}
        get{return _targetCoin; }
    }

    #region CoinAction
    public bool IsEnoughCoint(int coin){
        if(_coin - coin > 0){
            return true;
        }
        return false;
    }
    public void AddCoin(int coin){
        _coin += coin;
    }
    public bool ReduceCoin(int coin){
        if(IsEnoughCoint(coin)){
            _coin -= coin;
            return true;
        }
        return false;
    }
    #endregion

    #region EquipmentAction
    public bool UpdateEquipmentLevel(){
        int price = _equipment.Price;
        if(IsEnoughCoint(price)){
            _coin -= price;
            _equipment.Level++;
            return true;
        }
        return false;
    }
    #endregion

    #region WorkerAction
    public bool BuyWorker(int price){
        if(IsEnoughCoint(price)){
            _coin -= price;
            _numWorkers++;
            return true;
        }
        return false;
    }
    #endregion

    #region LandAction
    public bool BuyLand(int price){
        if(IsEnoughCoint(price)){
            _coin -= price;
            _land++;
            return true;
        }
        return false;
    }
    #endregion
   
}
