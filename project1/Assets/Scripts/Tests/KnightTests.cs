using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class KnightTests
{

    [Test]
    public void GetHealthTest()
    {
        Knight player = new Knight("You");

        Assert.AreEqual(20, player.GetHealth());
    }

    [Test]
    public void TestUpdate()
    {
        Knight player = new Knight("You");

        player.UpdatePower();
    }

}
