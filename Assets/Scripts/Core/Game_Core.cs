
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game_Core : MonoBehaviour
{

    /**
     * <p> inited in Unity
     *  
     */
    public Player[] players;

    public Player currentPlayer;

    public int gameMode;

    private Country[] countrys;

    private List<Player> localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init(){
        countrys = GameObject.FindObjectsOfType<Country>();
        gameMode = Constant.GAMEMODE_INITCOUNTRY;

        initPlayers();
        resetCurrentPlayer();
    }

    private void initPlayers(){
        int index = 0;
        foreach (Player player in players){
            if(player.mode == Constant.PLAYER_MODE_CLIENT && player.mode == Constant.PLAYER_MODE_HOTSET){
                localPlayer.Add(player);
            }
            player.isEnable = true;
            player.CanSelect = false;
            player.SetNumber(index + 1);
            player.color = Constant.PLAYER_COLORS[index];
            index++;
        }
    }

    private void run(){
        gameMode = Constant.GAMEMODE_SETTROOP;
    }

    public void initSetTroopCallBack(){
        //check if anybody already used all init troops
        ArrayList jumpoff = new ArrayList();
        foreach (Player player in players)
        {
            if(player.troops <= 0){
                jumpoff.Add(player);
            }
        }

        if(jumpoff.Count < players.Length){
                NextPlayer(jumpoff);
        }else{
            resetCurrentPlayer();
            //gamerun
            run();
            Debug.Log("===== Game Run =====");
            
        }

    }

    public void setTroopCallBack(){

    }

    public void switchCardCallBack(){

    }

    public void attackCallBack(){

    }

    public void defenseCallBack(){

    }

    public void endPhaseCallBack(){

    }


    

    private void NextPlayer(ArrayList jumpOffPlayers = null)
    {
        if (players.Length == 0)
        {
            return;
        }

        currentPlayer.CanSelect = false;

        int currentIndex = Array.IndexOf(players, currentPlayer);
        int nextIndex = (currentIndex + 1) % players.Length;

        while (jumpOffPlayers != null && jumpOffPlayers.Contains(players[nextIndex]))
        {
            nextIndex = (nextIndex + 1) % players.Length;
        }

        updateUI();
        currentPlayer = players[nextIndex];
        updateUI();
        currentPlayer.CanSelect = true;
        Debug.Log("CurrentPlayer: " + currentPlayer.number);
    }

    private void resetCurrentPlayer(){
        
        if(players.Length <= 0){
            return;
        }

        if(currentPlayer != null){
            currentPlayer.CanSelect = false;
        }

        updateUI();
        currentPlayer = players[0];
        updateUI();
        currentPlayer.CanSelect = true;
    }

    private void updateUI(){
        
        if(currentPlayer == null){
            return;
        }

        if(currentPlayer.mode == Constant.PLAYER_MODE_CLIENT || currentPlayer.mode == Constant.PLAYER_MODE_HOTSET){
            GameObject.Find("UI").GetComponent<UIManager>().setTroopsText(currentPlayer.troops);

        }
        GameObject.Find("UI").GetComponent<UIManager>().setCurrentPlayerText(currentPlayer);
    }




}
