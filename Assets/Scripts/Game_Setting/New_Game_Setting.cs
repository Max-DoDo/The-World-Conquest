using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the settings for a new game.
/// </summary>
public class New_Game_Setting : MonoBehaviour
{
    private int gamePlayerNumber;

    private int gameAINumber;

    private int gameMode;

    /// <summary>
    /// Sets the parameters for the new game.
    /// </summary>
    /// <param name="playerNumber">Number of human players.</param>
    /// <param name="aiNumber">Number of AI players.</param>
    /// <param name="mode">Game mode.</param>
    public void SetGameParameters(int playerNumber, int aiNumber, int mode)
    {
        gamePlayerNumber = playerNumber;
        gameAINumber = aiNumber;
        gameMode = mode;
    }

    /// <summary>
    /// Gets the number of human players for the game.
    /// </summary>
    /// <returns>The number of human players.</returns>
    public int GetGamePlayerNumber()
    {
        return gamePlayerNumber;
    }

    /// <summary>
    /// Gets the number of AI players for the game.
    /// </summary>
    /// <returns>The number of AI players.</returns>
    public int GetGameAINumber()
    {
        return gameAINumber;
    }

    /// <summary>
    /// Gets the game mode.
    /// </summary>
    /// <returns>The game mode.</returns>
    public int GetGameMode()
    {
        return gameMode;
    }

    void Start()
    {
        SetGameParameters(gamePlayerNumber, gameAINumber, gameMode); 
    }
}
