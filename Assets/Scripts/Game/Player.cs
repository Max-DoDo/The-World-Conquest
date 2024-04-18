using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private static int numberCount = 0;

    public int number;

    public int troops;

    public int mode;

    public bool isEnable;

    public bool CanSelect;

    public Color color;

    public Player(Client client){
        numberCount += 1;

        init();
    }

    public Player(){
        numberCount += 1;
    }

    private void init(){
        this.number = numberCount;
        troops = 20;


    }

    public void selectCountry(Country country){
        if(!country.isOwned() && troops >= 5){
            country.setOwner(this);
            country.addTroops(5);
            troops -= 5;
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

    // internal List<Country> GetControlledCountries()
    // {
    //     throw new NotImplementedException();
    // }

    public override string ToString(){
        return "[Player " + number + "]";
    }
}
