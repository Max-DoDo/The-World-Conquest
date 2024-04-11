using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private static int playerNumberCount = 0;

    private int playerNumber;

    private int troops;

    private bool isAI;

    private Client client;
    
    public Player(Client client){
        this.playerNumber = playerNumberCount;
        playerNumberCount += 1;
        isAI = false;
    }

    public Player(/*AI*/){
        this.playerNumber = playerNumberCount;
        playerNumberCount += 1;
        isAI = true;
    }

    public Country selectCountry(){
        
    }



    public int GetPlayerNumber(){
        return playerNumber;
    }

    public void SetPlayerNumber(int PlayerNumber){
        this.playerNumber = PlayerNumber;
    }

    public bool IsAI(){
        return isAI;
    }

    public void RevAI(){
        isAI = !isAI;
    }

}
