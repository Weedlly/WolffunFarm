using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SellingProductTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void SellingProductTestSimplePasses()
    {
        // Arrange

        Product product = new Product()
        {
            SellingPrice = 100
        };
        WareHouse.Bin bin = new WareHouse.Bin
        {
            ProductOfBin = product,
            NumProductHarvested = 1
        };

        int expectedCoin = DataLive.Instance.UserResource.Coin + product.SellingPrice;
        int expectedNumProductHarvested = bin.NumProductHarvested - 1;

        // Act
        bool actualResult = DataLive.Instance.UserResource.SellProduct(bin);

        // Assert
        Assert.IsTrue(actualResult);
        Assert.AreEqual(expectedCoin, DataLive.Instance.UserResource.Coin);
        Assert.AreEqual(expectedNumProductHarvested, bin.NumProductHarvested);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SellingProductWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
