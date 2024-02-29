using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
///     This script is used to test the Launch_Screen.
/// </summary>
/// <author>
///     wtto
/// </author>
/// <date>
///     2024-02-28
/// </date>
public class Launch_ScreenTests
{
    private Launch_Screen launchScreen;

    [SetUp]
    public void SetUp()
    {
        //Initialize the test environment
        launchScreen = new GameObject().AddComponent<Launch_Screen>();
    }
    [Test]
    public void LaunchScreenEvent_LoadsCorrectScene()
    {
        string expectedSceneName = "Main_Menu";
        launchScreen.LaunchScreenEvent();
        Assert.AreEqual(expectedSceneName, SceneManager.GetActiveScene().name);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(launchScreen.gameObject);
    }
} 