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

    public Player(){
        numberCount += 1;
    }

    private void init(){
        this.number = numberCount;
        troops = 20;


    }

    public void MouseEventCallBack(Country country){
        int gamemode = GameObject.Find("Logic_Core").GetComponent<Game_Core>().gameMode;

        if(gamemode == Constant.GAMEMODE_INITCOUNTRY){
            initSelectCountry(country);
            return;
        }

        if(gamemode == Constant.GAMEMODE_SETTROOP){
            setTroops(country);
        }
        
    }

    private void initSelectCountry(Country country){
        if(!country.isOwned() && troops >= 5){
            country.setOwner(this);
            country.addTroops(5);
            troops -= 5;
        }else{
            // Debug.Log("This Country already has a owner");
            GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("This Country already has a owner");
            return;
        }
        GameObject.Find("Logic_Core").GetComponent<Game_Core>().initSetTroopCallBack();
    }

    private void setTroops(Country country){
        


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
        return "Player " + number + "";
    }
}
