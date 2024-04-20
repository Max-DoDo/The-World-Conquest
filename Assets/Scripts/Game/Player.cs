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

    private Country selectCountry;

    private bool isSelected;

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

        if(gamemode == Constant.GAMEMODE_ATTACK){
            attack(country);
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
        GameObject.Find("Logic_Core").GetComponent<Game_Core>().setTroopCallBack(this,country);
    }

    private void attack(Country country){

        GameObject.Find("UI").GetComponent<UIManager>().scrollBarSleep();
        if(isSelected){
            isSelected = false;
            if(!CountryManager.checkCountryOwner(this,country) && CountryManager.isNearBy(country,selectCountry)){
                Debug.Log("Attack: " + selectCountry + " " + country);
                GameObject.Find("Logic_Core").GetComponent<Game_Core>().attackCallBack(selectCountry,country);
            }else{
                Debug.Log("Not a vild enemy country! Owner: " + !CountryManager.checkCountryOwner(this,country) + "NearBy: " + CountryManager.isNearBy(country,selectCountry));
            }
        }else{
            if(CountryManager.checkCountryOwner(this,country) && country.getTroops() > 1){
                Debug.Log("Own Country selected");
                isSelected = true;
                selectCountry = country;
            }else{
                Debug.Log("Not own country or this country has no troops");
                
            }
        }
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

    public void addTroops(int troops){
        this.troops += troops;
    }

    public void zbbTroops(int troops){
        this.troops -= troops;
    }

}
