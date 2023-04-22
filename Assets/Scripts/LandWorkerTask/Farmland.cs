using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot(ElementName = "farmland")]
public class Farmland
{
    
    private int _landPrice;
    private int _numLands;
    private List<Land> _lands;
    [XmlArray(ElementName = "lands")]
    [XmlArrayItem(ElementName = "land")]
    public List<Land> Lands{
        set{
            _lands = value;
        }
        get{
            if(_lands == null){
                _lands = new List<Land>();
            }
            return _lands;
        }
    }
    [XmlElement(ElementName = "numLands")]
    public int NumLands{
        set{_numLands = value;}
        get{return _numLands; }
    }
    [XmlElement(ElementName = "landPrice")]
    public int LandPrice{
        set{_landPrice = value;}
        get{return _landPrice; }
    }
    public void AddLand(){
        _lands.Add(new Land());
        _numLands = _lands.Count;
    }
    public void IncreatingNumLand(){
        AddLand();
    }
    
}
