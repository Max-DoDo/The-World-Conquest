using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject popUpText;

    public GameObject TroopSelectScrollBar; 

    public GameObject TroopSelectNumberText;

    private int scrollBarMaxValue;




    void Start(){
        popUpText.SetActive(false);
        TroopSelectScrollBar.SetActive(false);
        scrollBarMaxValue = 11;
    }

    public void setCurrentPlayerText(Player player){
        string str = "Current Player: " + player.ToString();
        GameObject currentPlayerText = GameObject.Find("CurrentPlayerText");
        currentPlayerText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    public void setTroopsText(int troops){
        string str = "Troops: " + troops;
        GameObject troopText = GameObject.Find("TroopsText");
        troopText.GetComponent<TextMeshProUGUI>().SetText(str);
    }

    public void setPopUpText(string str){
        popUpText.GetComponent<TextMeshProUGUI>().SetText(str);
        popUpText.SetActive(true);
        Invoke("setPopUpTextBack",2);
        
    }

    public void scrollBarCallBack(){
        float value = TroopSelectScrollBar.GetComponent<Scrollbar>().value;
        TroopSelectNumberText.GetComponent<TextMeshProUGUI>().SetText(Convert.ToString(Math.Round(scrollBarMaxValue * value,0)));
        
    }

    public void ConfirmButtonCallBack(){
        if(!TroopSelectScrollBar.gameObject.activeSelf){
            return;
        }

        Game_Core gc = GameObject.Find("Logic_Core").GetComponent<Game_Core>();
        int gamemode = gc.gameMode;
        double scrollbarValue = Math.Round(scrollBarMaxValue * TroopSelectScrollBar.GetComponent<Scrollbar>().value,0);

        if(gamemode == Constant.GAMEMODE_SETTROOP){
            gc.setTroopScrollBarConfirmButtonCallBack(scrollbarValue);
            scrollBarSleep();
        }

        if(gamemode == Constant.GAMEMODE_ATTACK){
            gc.attackScrollBarConfirmButtonCallBack(scrollbarValue);
        }

    }

    public void scrollBarAwake(int maxValue){
        TroopSelectScrollBar.SetActive(true);
        scrollBarMaxValue = maxValue;
    }

    public void scrollBarSleep(){
        TroopSelectNumberText.GetComponent<TextMeshProUGUI>().SetText("0");
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

    private void setPopUpTextBack(){
        popUpText.SetActive(false);

    }
}
