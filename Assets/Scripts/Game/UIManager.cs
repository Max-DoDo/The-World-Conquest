using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void setCurrentPlayerText(Player player){
        string str = "Current Player: " + player.ToString();
        currentPlayerText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    public void setTroopsText(int troops){
        string str = "Troops: " + troops;
        troopsText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    public void setCountryText(Country country){
        string str = "Country: " + country.name;
        countryText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    public void setCountryArmyText(Country country){
        string str = "Army: " + country.getTroops();
        countryArmyText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    public void setCountryArmyText(int troops){
        string str = "Army: " + troops;
        countryText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    public void setPopUpText(string str){
        popUpText.GetComponent<TextMeshProUGUI>().SetText(str);
        popUpText.SetActive(true);
        Invoke("setPopUpTextBack",2);
        
    }

    public void scrollBarCallBack(){
        float value = TroopSelectScrollBar.GetComponent<Scrollbar>().value;
        troopsSelectNumberText.GetComponent<TextMeshProUGUI>().SetText(Convert.ToString(Math.Round(scrollBarMaxValue * value,0)));
        
    }

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

    public void scrollBarAwake(int maxValue){
        TroopSelectScrollBar.SetActive(true);
        scrollBarMaxValue = maxValue;
    }

    public void scrollBarSleep(){
        troopsSelectNumberText.GetComponent<TextMeshProUGUI>().SetText("0");
        TroopSelectScrollBar.GetComponent<Scrollbar>().value = 0;
        TroopSelectScrollBar.SetActive(false);
    }

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

    public void cardButtonCallBack(){
        
    }

    private void setPopUpTextBack(){
        popUpText.SetActive(false);

    }
}
