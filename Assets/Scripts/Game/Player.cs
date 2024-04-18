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

    public Color color;

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
        if(!country.isOwned()){
            country.setOwner(this);
        }else{
            Debug.Log("This Country already has a owner");
            // TODO show text in UI
            return;
        }
        GameObject.Find("Logic_Core").GetComponent<Game_Core>().setTroopCallBack(country);
        
    }

    public int GetNumber(){
        return number;
    }

    public void SetNumber(int number){
        this.number = number;
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

    public override string ToString(){
        return "[Player " + number + "]";
    }
}
