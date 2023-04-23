using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot(ElementName = "equipment")]
public class Equipment
{
    ///<sumary>
    ///  That defines the properties and methods related to a Equipment in a game
    ///</sumary>
    private int _level;
    private int _price;
    private float _buffPercent;

    [XmlElement(ElementName = "level")]
    public int Level
    {
        set { _level = value; }
        get { return _level; }
    }
    [XmlElement(ElementName = "updatePrice")]
    public int Price
    {
        set { _price = value; }
        get { return _price; }
    }
    [XmlElement(ElementName = "buffPercent")]
    public float BuffPercent
    {
        set { _buffPercent = value; }
        get { return _buffPercent; }
    }
    public float RemainTimeAfterBuff(float time)
    {
        return (time / (1 + ((_level * _buffPercent) / 100)));
    }
}
