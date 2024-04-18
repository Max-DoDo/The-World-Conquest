using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private static int playerNumberCount = 0;

    public int playerNumber;

    public int initTroops;

    public int troops;

    public bool isAI;

    public bool isEnable;

    public bool CanSelect;

    public Player(Client client){
        playerNumberCount += 1;
        isAI = false;

        init();
    }

    public Player(){
        playerNumberCount += 1;
        isAI = true;
    }

    private void init(){
        this.playerNumber = playerNumberCount;
        initTroops = 20;
        troops = 0;


    }

    public void selectCountry(Country country){
        Debug.Log("select" + country);
        
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

    // internal List<Country> GetControlledCountries()
    // {
    //     throw new NotImplementedException();
    // }
}
