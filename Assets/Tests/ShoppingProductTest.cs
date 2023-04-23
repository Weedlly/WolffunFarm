using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShoppingProductTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ShoppingProductSimplePasses()
    {
        // Arrange
        var bin = new WareHouse.Bin
        {
            NumProductSeed = 5,
            ProductOfBin = new Product
            {
                Name = "Cow",
                PurchasePrice = 10,
                SellingNumber = 1
            }
        };
        WareHouse wareHouse = new WareHouse
        {
            ProductBins = new List<WareHouse.Bin>()
        };
        wareHouse.ProductBins.Add(bin);

        UserResource userResource = new UserResource
        {
            UserWareHouse = wareHouse,
            Coin = 20
        };

        // Act
        var result = userResource.PurcharseProduct(bin);

        // Assert
        Assert.AreEqual(result, true);
        Assert.AreEqual(userResource.Coin, 10);
        Assert.AreEqual(bin.NumProductSeed, 6);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ShoppingProductWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
