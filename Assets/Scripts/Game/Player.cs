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

        if(gamemode == Constant.GAMEMODE_MOVEMENT){
            movement(country);
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
                GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("Not a vild enemy country! Owner: " + !CountryManager.checkCountryOwner(this,country) + "NearBy: " + CountryManager.isNearBy(country,selectCountry));
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

    private void movement(Country country){

        GameObject.Find("UI").GetComponent<UIManager>().scrollBarSleep();
        if(isSelected){
            isSelected = false;
            if(CountryManager.checkCountryOwner(this,country) && CountryManager.isPathway(this,country,selectCountry)){
                Debug.Log("Movement: " + selectCountry + " " + country);
                GameObject.Find("Logic_Core").GetComponent<Game_Core>().attackCallBack(selectCountry,country);
            }else{
                GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("Not a vild enemy country! Owner: " + !CountryManager.checkCountryOwner(this,country) + "NearBy: " + CountryManager.isNearBy(country,selectCountry));
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


//TEST
public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestPlayer();
    }

    void TestPlayer()
    {
        Player player1 = new Player();
        Player player2 = new Player();

        // Testing the initialization of players
        Debug.Log("Player 1 Number: " + player1.GetNumber()); // Player 1 Number: 1
        Debug.Log("Player 2 Number: " + player2.GetNumber()); // Player 2 Number: 2

        // Testing the initialization of troops
        Debug.Log("Player 1 Troops: " + player1.troops); // Player 1 Troops: 20
        Debug.Log("Player 2 Troops: " + player2.troops); // Player 2 Troops: 20

        // Testing the MouseEventCallBack method
        Country country = new GameObject().AddComponent<Country>();
        Debug.Log("Testing MouseEventCallBack:");
        Debug.Log("Player 1: ");
        player1.MouseEventCallBack(country);
        Debug.Log("Player 2: ");
        player2.MouseEventCallBack(country);

        // Testing the addTroops method
        Debug.Log("Testing addTroops:");
        player1.addTroops(10);
        Debug.Log("Player 1 Troops after adding: " + player1.troops); // Player 1 Troops after adding: 30

        // Testing the zbbTroops method
        Debug.Log("Testing zbbTroops:");
        player2.zbbTroops(5);
        Debug.Log("Player 2 Troops after subtracting: " + player2.troops); // Player 2 Troops after subtracting: 15
    }
}