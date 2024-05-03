using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
=======
/// <summary>
/// Handles the settings for a new game.
/// </summary>
>>>>>>> develop
public class New_Game_Setting : MonoBehaviour
{
    private int gamePlayerNumber;

    private int gameAINumber;

    private int gameMode;
<<<<<<< HEAD
    // Start is called before the first frame update

=======

    /// <summary>
    /// Sets the parameters for the new game.
    /// </summary>
    /// <param name="playerNumber">Number of human players.</param>
    /// <param name="aiNumber">Number of AI players.</param>
    /// <param name="mode">Game mode.</param>
>>>>>>> develop
    public void SetGameParameters(int playerNumber, int aiNumber, int mode)
    {
        gamePlayerNumber = playerNumber;
        gameAINumber = aiNumber;
        gameMode = mode;
    }
<<<<<<< HEAD
=======

    /// <summary>
    /// Gets the number of human players for the game.
    /// </summary>
    /// <returns>The number of human players.</returns>
>>>>>>> develop
    public int GetGamePlayerNumber()
    {
        return gamePlayerNumber;
    }
<<<<<<< HEAD
=======

    /// <summary>
    /// Gets the number of AI players for the game.
    /// </summary>
    /// <returns>The number of AI players.</returns>
>>>>>>> develop
    public int GetGameAINumber()
    {
        return gameAINumber;
    }
<<<<<<< HEAD
=======

    /// <summary>
    /// Gets the game mode.
    /// </summary>
    /// <returns>The game mode.</returns>
>>>>>>> develop
    public int GetGameMode()
    {
        return gameMode;
    }

    void Start()
    {
<<<<<<< HEAD
        SetGameParameters( gamePlayerNumber,gameAINumber, gameMode); 
    }
}
=======
        SetGameParameters(gamePlayerNumber, gameAINumber, gameMode); 
    }
}
>>>>>>> develop
