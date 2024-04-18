using System;
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
    }
}
