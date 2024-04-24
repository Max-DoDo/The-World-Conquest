using UnityEngine;
using NUnit.Framework;

public class ConstantTest
{
    [Test]
    public void TestContinents()
    {
        Assert.AreEqual(1, Constant.CONTINENT_ASIA, "CONTINENT_ASIA is incorrect!");
        Assert.AreEqual(2, Constant.CONTINENT_AFRICA, "CONTINENT_AFRICA is incorrect!");
        Assert.AreEqual(3, Constant.CONTINENT_EUROPE, "CONTINENT_EUROPE is incorrect!");
        Assert.AreEqual(4, Constant.CONTINENT_NORTH_AMERICA, "CONTINENT_NORTH_AMERICA is incorrect!");
        Assert.AreEqual(5, Constant.CONTINENT_SOUTH_AMERICA, "CONTINENT_SOUTH_AMERICA is incorrect!");
        Assert.AreEqual(6, Constant.CONTINENT_AUSTRALIA, "CONTINENT_AUSTRALIA is incorrect!");
    }

    [Test]
    public void TestPlayerColors()
    {
        Assert.AreEqual(new Color32(238, 63, 77, 255), Constant.PLAYER1_COLOR, "PLAYER1_COLOR is incorrect!");
        Assert.AreEqual(new Color32(21, 85, 154, 255), Constant.PLAYER2_COLOR, "PLAYER2_COLOR is incorrect!");
        Assert.AreEqual(new Color32(27, 167, 132, 255), Constant.PLAYER3_COLOR, "PLAYER3_COLOR is incorrect!");
        Assert.AreEqual(new Color32(180, 169, 146, 255), Constant.PLAYER6_COLOR, "PLAYER6_COLOR is incorrect!");
        Assert.AreEqual(new Color32(249, 125, 28, 255), Constant.PLAYER7_COLOR, "PLAYER7_COLOR is incorrect!");
        Assert.AreEqual(new Color32(129, 60, 133, 255), Constant.PLAYER8_COLOR, "PLAYER8_COLOR is incorrect!");
    }

    [Test]
    public void TestPlayerModes()
    {
        Assert.AreEqual(0, Constant.PLAYER_MODE_CLIENT, "PLAYER_MODE_CLIENT is incorrect!");
        Assert.AreEqual(1, Constant.PLAYER_MODE_HOTSET, "PLAYER_MODE_HOTSET is incorrect!");
        Assert.AreEqual(2, Constant.PLAYER_MODE_INTERNET, "PLAYER_MODE_INTERNET is incorrect!");
        Assert.AreEqual(-1, Constant.PLAYER_MODE_AI, "PLAYER_MODE_AI is incorrect!");
    }
}
