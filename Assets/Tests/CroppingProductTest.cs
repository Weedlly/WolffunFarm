using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CroppingProductTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void CroppingProductTestSimplePasses()
    {
        // Arrange
        Product product = new Product()
        {
            Name = "Cow"
        };
        WareHouse.Bin bin = new WareHouse.Bin
        {
            ProductOfBin = product,
            NumProductHarvested = 1
        };
        UserResource userResource = new UserResource
        {
            UserWareHouse = new WareHouse
            {
                ProductBins = new List<WareHouse.Bin>()
            }
        };
        DataLive.Instance.UserResource = userResource;
        userResource.UserWareHouse.ProductBins.Add(bin);
        Land land = new Land
        {
            GrowingProductName = "Cow",
            GrowingProduct = product,
            NumberHarvested = 1,
        };

        // Act
        land.Cropping();

        // Assert
        Assert.AreEqual(land.NumberHarvested, 0);
        Assert.AreEqual(bin.NumProductHarvested, 2);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CroppingProductTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
