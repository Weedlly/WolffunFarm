using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot(ElementName = "wareHouse")]
public class WareHouse 
{
    public class Bin{
        private Product _product;
        private int _numProductSeed;
        private int _numProductHarvested;

        [XmlElement(ElementName = "product")]
        public Product ProductOfBin{
            set {_product = value;}
            get{return _product;}
        }
        [XmlElement(ElementName = "numProductSeed")]
        public int NumProductSeed{
            set {_numProductSeed = value;}
            get{return _numProductSeed;}
        }
        [XmlElement(ElementName = "numProductHarvested")]
        public int NumProductHarvested{
            set {_numProductHarvested = value;}
            get{return _numProductHarvested;}
        }
        
    }
    
    private List<Bin> _productBins;

    [XmlElement(ElementName = "bin")]
    public List<Bin> ProductBins{
        set{_productBins = value;}
        get{return _productBins;}
    }
}
