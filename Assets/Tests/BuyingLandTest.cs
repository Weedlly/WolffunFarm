using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BuyingLandTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void BuyingLandTestSimplePasses()
    {
        // Arrange
        Farmland farmland = new Farmland
        {
            NumLands = 0,
            LandPrice = 500,
            Lands = new List<Land>()
        };
        UserResource userResource = new UserResource
        {
            Farmland = farmland,
            Coin = 500
        };

        // Act
        bool success = userResource.BuyLand();

        // Assert
        Assert.IsTrue(success);
        Assert.AreEqual(1, farmland.NumLands);
        Assert.AreEqual(0, userResource.Coin);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
