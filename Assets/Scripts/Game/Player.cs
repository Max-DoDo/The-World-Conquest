using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private static int numberCount = 0;

    public int number;

    public int initTroops;

    public int troops;

    public bool isAI;

    public bool isEnable;

    public bool CanSelect;

    public Player(Client client){
        numberCount += 1;
        isAI = false;

        init();
    }

    public Player(){
        numberCount += 1;
        isAI = true;
    }

    private void init(){
        this.number = numberCount;
        initTroops = 20;
        troops = 0;


    }

    public void selectCountry(Country country){
        Debug.Log("select " + country);
        GameObject.Find("Logic_Core").GetComponent<Game_Core>().setTroopCallBack();
        
    }

    public int GetPlayerNumber(){
        return number;
    }

    public void SetPlayerNumber(int PlayerNumber){
        this.number = PlayerNumber;
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
