using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a player in the game.
/// </summary>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class.
    /// </summary>
    public Player(){
        numberCount += 1;
    }

    /// <summary>
    /// Initializes the player.
    /// </summary>
    private void init(){
        this.number = numberCount;
        troops = 20;
    }

    /// <summary>
    /// Handles mouse event callbacks for the player.
    /// </summary>
    /// <param name="country">The country object associated with the event.</param>
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

        if(gamemode == Constant.GAMEMODE_MOVEMENT){
            movement(country);
        }
        
    }

    /// <summary>
    /// Initializes the selected country during the initialization phase.
    /// </summary>
    /// <param name="country">The country object to be initialized.</param>
    private void initSelectCountry(Country country){
        if(!country.isOwned() && troops >= 5){
            country.setOwner(this);
            country.addTroops(5);
            troops -= 5;
        }else{
            GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("This Country already has a owner");
            return;
        }
        GameObject.Find("Logic_Core").GetComponent<Game_Core>().initSetTroopCallBack();
    }

    /// <summary>
    /// Sets troops for the selected country.
    /// </summary>
    /// <param name="country">The country object for troop deployment.</param>
    private void setTroops(Country country){
        GameObject.Find("Logic_Core").GetComponent<Game_Core>().setTroopCallBack(this,country);
    }

    /// <summary>
    /// Handles the attack action between countries.
    /// </summary>
    /// <param name="country">The country object to attack.</param>
    private void attack(Country country){
        GameObject.Find("UI").GetComponent<UIManager>().scrollBarSleep();
        if(isSelected){
            isSelected = false;
            if(!CountryManager.checkCountryOwner(this,country) && CountryManager.isNearBy(country,selectCountry)){
                Debug.Log("Attack: " + selectCountry + " " + country);
                GameObject.Find("Logic_Core").GetComponent<Game_Core>().attackCallBack(selectCountry,country);
            }else{
                GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("Not a valid enemy country! Owner: " + !CountryManager.checkCountryOwner(this,country) + "NearBy: " + CountryManager.isNearBy(country,selectCountry));
            }
        }else{
            if(CountryManager.checkCountryOwner(this,country) && country.getTroops() > 1){
                Debug.Log("Own Country selected");
                isSelected = true;
                selectCountry = country;
            }else{
                GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("Not own country or this country has no troops");
            }
        }
    }

    /// <summary>
    /// Handles the movement action between countries.
    /// </summary>
    /// <param name="country">The country object to move troops to.</param>
    private void movement(Country country){
        GameObject.Find("UI").GetComponent<UIManager>().scrollBarSleep();
        if(isSelected){
            isSelected = false;
            if(CountryManager.checkCountryOwner(this,country) && CountryManager.isPathway(this,country,selectCountry)){
                Debug.Log("Movement: " + selectCountry + " " + country);
                GameObject.Find("Logic_Core").GetComponent<Game_Core>().attackCallBack(selectCountry,country);
            }else{
                GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("Not a valid enemy country! Owner: " + !CountryManager.checkCountryOwner(this,country) + "NearBy: " + CountryManager.isNearBy(country,selectCountry));
            }
        }else{
            if(CountryManager.checkCountryOwner(this,country) && country.getTroops() > 1){
                Debug.Log("Own Country selected");
                isSelected = true;
                selectCountry = country;
            }else{
                GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("Not own country or this country has no troops");
            }
        }
    }

    /// <summary>
    /// Gets the player number.
    /// </summary>
    /// <returns>The player number.</returns>
    public int GetNumber(){
        return number;
    }

    /// <summary>
    /// Sets the player number.
    /// </summary>
    /// <param name="number">The player number.</param>
    public void SetNumber(int number){
        this.number = number;
    }

    /// <summary>
    /// Increases the troops count.
    /// </summary>
    /// <param name="troops">The number of troops to add.</param>
    public void addTroops(int troops){
        this.troops += troops;
    }

    /// <summary>
    /// Decreases the troops count.
    /// </summary>
    /// <param name="troops">The number of troops to remove.</param>
    public void zbbTroops(int troops){
        this.troops -= troops;
    }

    /// <summary>
    /// Represents the string representation of the player.
    /// </summary>
    /// <returns>The string representation of the player.</returns>
    public override string ToString(){
        return "Player " + number + "";
    }
}
