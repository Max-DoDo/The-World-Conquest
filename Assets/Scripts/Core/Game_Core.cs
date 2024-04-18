
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;

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

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init(){
        countrys = GameObject.FindObjectsOfType<Country>();
        gameMode = Constant.GameMode_SetTroop;
        resetCurrentPlayer();
        foreach (Player player in players)
        {
            player.isEnable = true;
            player.CanSelect = false;
        }

        setTroop();
        
    }

    private void setTroop(){
        nextPlayer();
    }

    public void setTroopCallBack(){
        //check if anybody already used all init troops

        ArrayList jumpoff = new ArrayList();
        foreach (Player player in players)
        {
            if(player.initTroops <= 0){
                jumpoff.Add(player);
            }
        }

        if(jumpoff.Count < players.Length){
            nextPlayer(jumpoff);
        }else{
            resetCurrentPlayer();
            //gamerun
            Debug.Log("Game Run");
            
        }

    }

    private void AISetTroop(Player aiPlayer)
    { 

    }

    private void nextPlayer(ArrayList jumpOffPlayers = null){

        if(players.Length <= 0){
            return;
        }

        currentPlayer.CanSelect = false;

        int currentIndex = Array.IndexOf(players, currentPlayer);
        int nextIndex = (currentIndex + 1) % players.Length;

        while(true){
            if(jumpOffPlayers != null && jumpOffPlayers.Contains(players[nextIndex])){
                nextIndex = (nextIndex + 1) % players.Length;
            }else{
                currentPlayer = players[nextIndex];
                break;
            }
        }

        currentPlayer = players[nextIndex];

        currentPlayer.CanSelect = true;
        Debug.Log("CurrentPlayer" + currentPlayer.playerNumber);
        
    }

    private void resetCurrentPlayer(){

        if(players.Length <= 0){
            return;
        }
        currentPlayer = players[0];
    }




}
