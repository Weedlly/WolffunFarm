using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


// [XmlRoot(ElementName = "product")]
public class Product {
    [SerializeField] private string _name;
    [SerializeField] private float _growingTime;
    [SerializeField] private int _lifecycle;
    [SerializeField] private int _purchasePrice;
    [SerializeField] private int _buyingPrice;

    [XmlElement(ElementName = "name")]
    public string Name{
        set {_name = value;}
        get{return _name;}
    }
    [XmlElement(ElementName = "growingTime")]
    public float GrowingTime{
        set {_growingTime = value;}
        get{return _growingTime;}
    }
    [XmlElement(ElementName = "lifecycle")]
    public int Lifecycle{
        set {_lifecycle = value;}
        get{return _lifecycle;}
    }
    [XmlElement(ElementName = "purchasePrice")]
    public int PurchasePrice{
        set {_purchasePrice = value;}
        get{return _purchasePrice;}
    }
    [XmlElement(ElementName = "buyingPrice")]
    public int BuyingPrice{
        set {_buyingPrice = value;}
        get{return _buyingPrice;}
    }
}
