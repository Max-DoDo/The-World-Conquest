using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Game_Setting : MonoBehaviour
{
    private int gamePlayerNumber;

    private int gameAINumber;

    private int gameMode;
    // Start is called before the first frame update

    public void SetGameParameters(int playerNumber, int aiNumber, int mode)
    {
        gamePlayerNumber = playerNumber;
        gameAINumber = aiNumber;
        gameMode = mode;
    }
    public int GetGamePlayerNumber()
    {
        return gamePlayerNumber;
    }
    public int GetGameAINumber()
    {
        return gameAINumber;
    }
    public int GetGameMode()
    {
        return gameMode;
    }

    void Start()
    {
        SetGameParameters( gamePlayerNumber,gameAINumber, gameMode); 
    }
}