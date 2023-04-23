using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameWinningTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void GameWinningTestSimplePasses()
    {
        // Arrange
        UserResource userResource = new UserResource
        {
            Coin = 51,
            TargetCoin = 50
        };
        // Act
        bool win = userResource.IsWinTheGame();

        // Assert
        Assert.IsTrue(win);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator GameWinningTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
