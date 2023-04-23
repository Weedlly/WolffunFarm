using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HiringWorkerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void HireWorkerTestSimplePasses()
    {
        // Arrange
        UserResource userResource = new UserResource
        {
            Coin = 100,
            WorkerPrice = 50
        };

        // Act
        bool result = userResource.BuyWorker();

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(userResource.Coin, 50); // check if coins deducted correctly
        Assert.AreEqual(userResource.NumWorkers, 1); // check if worker added correctly

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HireWorkerTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
