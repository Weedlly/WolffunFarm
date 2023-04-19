using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserResource 
{
    private int _coin;
    public int Coin{
        get{return _coin; }
    }
    private int _equipmenLevel;
    public int EquipmenLevel{
        get{return _equipmenLevel; }
    }
    private int _worker;
    public int Worker{
        get{return _worker; }
    }
    private int _land;
    public int Land{
        get{return _land; }
    }
    private int _tomatoFruit;
    public int TomatoFruit{
        get{return _tomatoFruit; }
    }
    private int _tomatoSeed;
    public int TomatoSeed{
        get{return _tomatoSeed; }
    }
    private int _blueberryFruit;
    public int BlueberryFruit{
        get{return _blueberryFruit; }
    }
    private int _blueberrySeed;
    public int BlueberrySeed{
        get{return _blueberrySeed; }
    }
    private int _cowMilk;
    public int CowMilk{
        get{return _cowMilk;}
    }
    private int _cow;
    public int Cow{
        get{return _cow;}
    }
    private int _strawberryFruit;
    public int StrawberryFruit{
        get{return _strawberryFruit; }
    }
    private int _strawberrySeed;
    public int StrawberrySeed{
        get{return _strawberrySeed; }
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
    public bool UpdateEquipmentLevel(int price){
        if(IsEnoughCoint(price)){
            _coin -= price;
            _equipmenLevel++;
            return true;
        }
        return false;
    }
    #endregion

    #region Worker
    public bool BuyWorker(int price){
        if(IsEnoughCoint(price)){
            _coin -= price;
            _worker++;
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

    #region Tomato
    public void AddTomatoFruit(int number){
        _tomatoFruit += number;
    }
    public void AddTomatoSeed(int number){
        _tomatoSeed += number;
    }
    #endregion

    #region Blueberry
    public void AddBlueberryFruit(int number){
        _blueberryFruit += number;
    }
    public void AddBlueberrySeed(int number){
        _blueberrySeed += number;
    }
    #endregion Blueberry

    #region Cow
    public void AddCow(int number){
        _cow += number;
    }
    public void AddCowMilk(int number){
        _cowMilk += number;
    }
    #endregion

    #region Strawberry
    public void AddStrawberryFruit(int number){
        _strawberryFruit += number;
    }
    public void AddStrawberrySeed(int number){
        _strawberrySeed += number;
    }
    #endregion
}
