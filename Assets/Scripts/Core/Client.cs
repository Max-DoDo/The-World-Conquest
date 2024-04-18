using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class Client : MonoBehaviour
{   
    public delegate void CountrySelectionHandler(object sender, CountrySelectedEventArgs args);

    private Player player;

    public void SelectCountry(Country country){
        
        Game_Core game_Core = GameObject.Find("Logic_Core").GetComponent<Game_Core>();
        if(game_Core.gameMode == Constant.GameMode_SetTroop){
            setTroop();
        }
    }

    private void setTroop(){

    }


}
