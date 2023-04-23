using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UpdatingEquitmentTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void UpdatingEquitmentTestSimplePasses()
    {
        // Arrange
        var userResource = new UserResource { Coin = 50, Equipment = new Equipment { Level = 1, Price = 100 } };

        // Act
        bool result = userResource.UpdateEquipmentLevel();

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(1, userResource.Equipment.Level);
        Assert.AreEqual(50, userResource.Coin);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator UpdatingEquitmentTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
