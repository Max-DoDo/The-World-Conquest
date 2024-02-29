using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///     This script is used to test the MainMenuButton.
/// </summary>
/// <author>
///     wtto
/// </author>
/// <date>
///     2024-02-28
/// </date>

public class MainMenuButtonTests
{
    [Test]
    public void NewGameButtonEvent_LoadsNewGameMenuScene()
    {
        // Arrange
        var mainMenuButton = new GameObject().AddComponent<Main_Menu_Button>();

        // Act
        mainMenuButton.New_Game_Button_Event();

        // Assert
        Assert.AreEqual("New_Game_Menu", SceneManager.GetActiveScene().name);
    }

    [Test]
    public void LoadGameButtonEvent_LoadsLoadGameMenuScene()
    {
        // Arrange
        var mainMenuButton = new GameObject().AddComponent<Main_Menu_Button>();

        // Act
        mainMenuButton.Load_Game_Button_Event();

        // Assert
        Assert.AreEqual("Load_Game_Menu", SceneManager.GetActiveScene().name);
    }

    [Test]
    public void SettingButtonEvent_LoadsSettingMenuScene()
    {
        // Arrange
        var mainMenuButton = new GameObject().AddComponent<Main_Menu_Button>();

        // Act
        mainMenuButton.Setting_Button_Event();

        // Assert
        Assert.AreEqual("Setting_Menu", SceneManager.GetActiveScene().name);
    }

    [Test]
    public void ExitButtonEvent_QuitsApplication()
    {
        // Arrange
        var mainMenuButton = new GameObject().AddComponent<Main_Menu_Button>();

        // Act
        mainMenuButton.Exit_Button_Event();

        // Assert
        Assert.IsTrue(Application.isEditor); // In the Unity Editor, Application.Quit() doesn't actually quit the application, so this will be true in the editor.
    }
}