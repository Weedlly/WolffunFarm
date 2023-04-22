using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HireWorkerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void HireWorkerTestSimplePasses()
    {
        UserResource userResource = DataLive.Instance.UserResource;
        // flow 1: Enough coin to buy
        // des coin, inc number worker
        userResource.Coin = 20;
        userResource.WorkerPrice = 20;
        Assets.AreEqual(true,userResource.BuyWorker());

        // flow 2: not enough coint
        //  do nothing

        

        
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
