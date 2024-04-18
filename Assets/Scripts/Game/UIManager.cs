using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void setCurrentPlayer(Player player){
        String str = "Current Player: " + player.ToString();
        GameObject currentPlayerText = GameObject.Find("CurrentPlayerText");
        currentPlayerText.GetComponent<TextMeshProUGUI>().SetText(str);
    }
}
