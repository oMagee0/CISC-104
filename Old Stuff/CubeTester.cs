using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeTester
{
    // A Test behaves as an ordinary method
    [Test]
    public void CubeTesterSimplePasses()
    {
        
    }

    [Test]
    public void CubeConstructorTest()
    {
        Cube myCube = new Cube();

        Assert.AreEqual(0, myCube.GetLength());
        Assert.AreEqual(0, myCube.GetWidth());
        Assert.AreEqual(0, myCube.GetHeight());
    }

    [Test]
    public void EdgeLengthTest()
    {
        Cube myCube = new Cube();
        myCube.SetLength(2);
        myCube.SetWidth(2);
        myCube.SetHeight(2);

        Assert.AreEqual(24, myCube.GetEdgeLength());
    }

    [Test]
    public void VolumeTest()
    {
        Cube myCube = new Cube();

        myCube.SetLength(2);
        myCube.SetWidth(2);
        myCube.SetHeight(2);

        Assert.AreEqual(8, myCube.GetVolume());
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CubeTesterWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
