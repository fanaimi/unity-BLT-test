using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BLTtest;

public class PlayModeTestScript
{
    // A Test behaves as an ordinary method
    //[Test]
    /*public void PlayModeTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }*/

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MoveNorth()
    {

        var gameObject = new Object();
        //var controller = gameObject.AddComponent<CylinderController>();

        // Use the Assert class to test conditions.

        Assert.AreEqual(true, true);

        // Use yield to skip a frame.
        yield return null;

        // Assert.AreEqual(true, true);

    }
}
