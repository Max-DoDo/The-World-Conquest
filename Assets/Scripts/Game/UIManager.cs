using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject popUpText;

    void Start(){
        popUpText.SetActive(false);
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

    private void setPopUpTextBack(){
        popUpText.SetActive(false);

    }
}
