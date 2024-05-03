using System;
<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void setCurrentPlayerText(Player player){
        string str = "Current Player: " + player.ToString();
        GameObject currentPlayerText = GameObject.Find("CurrentPlayerText");
        currentPlayerText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    public void setTroopsText(int troops){
        string str = "Troops: " + troops;
        GameObject currentPlayerText = GameObject.Find("TroopsText");
        currentPlayerText.GetComponent<TextMeshProUGUI>().SetText(str);
=======
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the user interface of the game.
/// </summary>
public class UIManager : MonoBehaviour
{

    public GameObject popUpText;

    public GameObject TroopSelectScrollBar; 

    public GameObject troopsSelectNumberText;

    public GameObject currentPlayerText;

    public GameObject troopsText;


    public GameObject countryText;

    public GameObject countryArmyText;

    private int scrollBarMaxValue;




    void Start(){
        popUpText.SetActive(false);
        TroopSelectScrollBar.SetActive(false);
        scrollBarMaxValue = 11;
    }

    /// <summary>
    /// Sets the text displaying the current player.
    /// </summary>
    /// <param name="player">The current player.</param>
    public void setCurrentPlayerText(Player player){
        string str = "Current Player: " + player.ToString();
        currentPlayerText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    /// <summary>
    /// Sets the text displaying the number of troops.
    /// </summary>
    /// <param name="troops">The number of troops.</param>
    public void setTroopsText(int troops){
        string str = "Troops: " + troops;
        troopsText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    /// <summary>
    /// Sets the text displaying the name of the country.
    /// </summary>
    /// <param name="country">The country.</param>
    public void setCountryText(Country country){
        string str = "Country: " + country.name;
        countryText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    /// <summary>
    /// Sets the text displaying the number of troops in the country.
    /// </summary>
    /// <param name="country">The country.</param>
    public void setCountryArmyText(Country country){
        string str = "Army: " + country.getTroops();
        countryArmyText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    /// <summary>
    /// Sets the text displaying the number of troops.
    /// </summary>
    /// <param name="troops">The number of troops.</param>
    public void setCountryArmyText(int troops){
        string str = "Army: " + troops;
        countryText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    /// <summary>
    /// Sets the text of the pop-up message.
    /// </summary>
    /// <param name="str">The message string.</param>
    public void setPopUpText(string str){
        popUpText.GetComponent<TextMeshProUGUI>().SetText(str);
        popUpText.SetActive(true);
        Invoke("setPopUpTextBack",2);
        
    }

    /// <summary>
    /// Handles the callback when the scrollbar is scrolled.
    /// </summary>
    public void scrollBarCallBack(){
        float value = TroopSelectScrollBar.GetComponent<Scrollbar>().value;
        troopsSelectNumberText.GetComponent<TextMeshProUGUI>().SetText(Convert.ToString(Math.Round(scrollBarMaxValue * value,0)));
        
    }

    /// <summary>
    /// Handles the callback when the scrollbar confirm button is clicked.
    /// </summary>
    public void ScrollBarConfirmButtonCallBack(){
        if(!TroopSelectScrollBar.gameObject.activeSelf){
            return;
        }

        Game_Core gc = GameObject.Find("Logic_Core").GetComponent<Game_Core>();
        int gamemode = gc.gameMode;
        double scrollbarValue = Math.Round(scrollBarMaxValue * TroopSelectScrollBar.GetComponent<Scrollbar>().value,0);

        if(gamemode == Constant.GAMEMODE_SETTROOP){
            gc.setTroopScrollBarConfirmButtonCallBack(scrollbarValue);
        }

        if(gamemode == Constant.GAMEMODE_ATTACK){
            gc.attackScrollBarConfirmButtonCallBack(scrollbarValue);
        }

        if(gamemode == Constant.GAMEMODE_MOVEMENT){
            gc.movementScrollBarConfirmButtonCallBack(scrollbarValue);
        }
        scrollBarSleep();

    }

    /// <summary>
    /// Activates the scrollbar and sets its maximum value.
    /// </summary>
    /// <param name="maxValue">The maximum value of the scrollbar.</param>
    public void scrollBarAwake(int maxValue){
        TroopSelectScrollBar.SetActive(true);
        scrollBarMaxValue = maxValue;
    }

    /// <summary>
    /// Deactivates the scrollbar.
    /// </summary>
    public void scrollBarSleep(){
        troopsSelectNumberText.GetComponent<TextMeshProUGUI>().SetText("0");
        TroopSelectScrollBar.GetComponent<Scrollbar>().value = 0;
        TroopSelectScrollBar.SetActive(false);
    }

    /// <summary>
    /// Handles the callback when the end round button is clicked.
    /// </summary>
    public void endRoundCallBack(){
        Game_Core gc = GameObject.Find("Logic_Core").GetComponent<Game_Core>();
        int currentGameMode = gc.gameMode;

        if(currentGameMode == Constant.GAMEMODE_SETTROOP){
            gc.roundSetTroopCallBack();
            return;
        }

        if(currentGameMode == Constant.GAMEMODE_ATTACK){
            gc.roundAttackCallBack();
            return;
        }

        if(currentGameMode == Constant.GAMEMODE_MOVEMENT){
            gc.roundMovementCallBack();
            return;
        }

    }

    /// <summary>
    /// Handles the callback when the card button is clicked.
    /// </summary>
    public void cardButtonCallBack(){
        
    }

    /// <summary>
    /// Sets the pop-up text back to inactive after a delay.
    /// </summary>
    private void setPopUpTextBack(){
        popUpText.SetActive(false);

>>>>>>> develop
    }
}
