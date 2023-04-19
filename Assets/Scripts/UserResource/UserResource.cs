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

    // private int _tomatoFruit;
    // public int TomatoFruit{
    //     get{return _tomatoFruit; }
    // }
    // private int _tomatoSeed;
    // public int TomatoSeed{
    //     get{return _tomatoSeed; }
    // }
    // private int _blueberryFruit;
    // public int BlueberryFruit{
    //     get{return _blueberryFruit; }
    // }
    // private int _blueberrySeed;
    // public int BlueberrySeed{
    //     get{return _blueberrySeed; }
    // }
    // private int _cowMilk;
    // public int CowMilk{
    //     get{return _cowMilk;}
    // }
    // private int _cow;
    // public int Cow{
    //     get{return _cow;}
    // }
    // private int _strawberryFruit;
    // public int StrawberryFruit{
    //     get{return _strawberryFruit; }
    // }
    // private int _strawberrySeed;
    // public int StrawberrySeed{
    //     get{return _strawberrySeed; }
    // }
    
    public void LoadData() {
        // this = DataController.LocalLoadXML<UserResource>("UserResource.xml");

        // _equipment = new Equipment();
        // _userWareHouse = new WareHouse();
        
    }

    #region Coin
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

    #region Equipment
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

    #region Worker
    public bool BuyWorker(int price){
        if(IsEnoughCoint(price)){
            _coin -= price;
            _numWorkers++;
            return true;
        }
        return false;
    }
    #endregion

    #region Land
    public bool BuyLand(int price){
        if(IsEnoughCoint(price)){
            _coin -= price;
            _land++;
            return true;
        }
        return false;
    }
    #endregion

    #region Land
    
    #endregion
    // #region Tomato
    // // public bool BuyTomatoSeed(){
    // //     if(IsEnoughCoint(price)){
    // //         _coin -= price;
    // //         _land++;
    // //         return true;
    // //     }
    // //     return false;
    // // }
    // public void AddTomatoFruit(int number){
    //     _tomatoFruit += number;
    // }
    // public void AddTomatoSeed(int number){
    //     _tomatoSeed += number;
    // }
    // #endregion

    // #region Blueberry
    // public void AddBlueberryFruit(int number){
    //     _blueberryFruit += number;
    // }
    // public void AddBlueberrySeed(int number){
    //     _blueberrySeed += number;
    // }
    // #endregion Blueberry

    // #region Cow
    // public void AddCow(int number){
    //     _cow += number;
    // }
    // public void AddCowMilk(int number){
    //     _cowMilk += number;
    // }
    // #endregion

    // #region Strawberry
    // public void AddStrawberryFruit(int number){
    //     _strawberryFruit += number;
    // }
    // public void AddStrawberrySeed(int number){
    //     _strawberrySeed += number;
    // }
    // #endregion
}
