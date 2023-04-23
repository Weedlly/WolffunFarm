using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot(ElementName = "wareHouse")]
public class WareHouse
{
    ///<sumary>
    /// Used to manage the warehouse system in a game,
    /// particularly the storage of different types of products.
    ///</sumary>
    public class Bin
    {
        private Product _product;
        private int _numProductSeed;
        private int _numProductHarvested;

        [XmlElement(ElementName = "product")]
        public Product ProductOfBin
        {
            set { _product = value; }
            get { return _product; }
        }
        [XmlElement(ElementName = "numProductSeed")]
        public int NumProductSeed
        {
            set { _numProductSeed = value; }
            get { return _numProductSeed; }
        }
        [XmlElement(ElementName = "numProductHarvested")]
        public int NumProductHarvested
        {
            set { _numProductHarvested = value; }
            get { return _numProductHarvested; }
        }

        public bool IsEnoughHarvestedProduct()
        {
            if (_numProductHarvested > 0)
            {
                return true;
            }
            return false;
        }
        public void HarvestingProduct(int num)
        {
            _numProductHarvested += num;
        }

        public bool IsEnoughSeed()
        {
            if (_numProductSeed > 0)
            {
                return true;
            }
            return false;
        }
        public bool UsingASeed()
        {
            if (IsEnoughSeed())
            {
                _numProductSeed--;
                return true;
            }
            return false;
        }
    }

    private List<Bin> _productBins;

    [XmlElement(ElementName = "bin")]
    public List<Bin> ProductBins
    {
        set { _productBins = value; }
        get { return _productBins; }
    }
    public WareHouse.Bin FindBinOfProduct(Product product)
    {
        foreach (var bin in _productBins)
        {
            if (bin.ProductOfBin.Name == product.Name)
            {
                return bin;
            }
        }
        return null;
    }
    public Product FindProduct(string name)
    {
        foreach (var bin in _productBins)
        {
            if (bin.ProductOfBin.Name == name)
            {
                return bin.ProductOfBin;
            }
        }
        return null;
    }
}
