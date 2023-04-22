using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


[XmlRoot(ElementName = "product")]
public class Product {
    [SerializeField] private string _name;
    [SerializeField] private float _growingTime;
    [SerializeField] private int _lifecycle;
    [SerializeField] private int _purchasePrice;
    [SerializeField] private int _sellingPrice;
    [SerializeField] private int _sellingNumber;

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
    [XmlElement(ElementName = "sellingPrice")]
    public int SellingPrice{
        set {_sellingPrice = value;}
        get{return _sellingPrice;}
    }
    [XmlElement(ElementName = "sellingNumber")]
    public int SellingNumber{
        set {_sellingNumber = value;}
        get{return _sellingNumber;}
    }
}
