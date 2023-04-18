using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour {
    [SerializeField] private string _name;
    public string Name{
        set {_name = value;}
        get{return _name;}
    }
    [SerializeField] private int _price;
    [SerializeField] private float _growingTime;
    public float GrowingTime{
        set {_growingTime = value;}
        get{return _growingTime;}
    }
    [SerializeField] private int _lifecycle;
    public int Lifecycle{
        set {_lifecycle = value;}
        get{return _lifecycle;}
    }
    [SerializeField] private int _sellingPrice;
    [SerializeField] private int _shopSellingPrice;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
