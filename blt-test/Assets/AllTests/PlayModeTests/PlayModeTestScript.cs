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
    public IEnumerator TestMovements()
    {

        var  gameObject = new GameObject();
        var controller = gameObject.AddComponent<CylinderController>();
        
        Vector3 startingPos = controller.transform.position;

        Vector3 expectedPos = startingPos + new Vector3(
                    controller.m_horizontalInput * Time.deltaTime * controller.m_speed,
                    0f,
                   controller.m_verticalInput * Time.deltaTime * controller.m_speed
                );


        yield return new WaitForEndOfFrame();

        Vector3 endingPos = controller.transform.position;

        // Use the Assert class to test conditions.
        Assert.AreEqual(expectedPos, endingPos);

      

    }
}
