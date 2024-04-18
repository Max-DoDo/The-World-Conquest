
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

    private List<Client> clients;

    private Player ClientPlayer;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init(){
        countrys = GameObject.FindObjectsOfType<Country>();
        gameMode = Constant.GAMEMODE_INITCOUNTRY;

        int index = 0;
        foreach (Player player in players)
        {
            if(player.mode == Constant.PLAYER_MODE_CLIENT){
                ClientPlayer = player;
            }
            player.isEnable = true;
            player.CanSelect = false;
            player.SetNumber(index + 1);
            player.color = Constant.PLAYER_COLORS[index];
            // Debug.Log("Player: " + player.GetPlayerNumber());
            // Debug.Log("Player Color: " + player.color);
            index++;
        }


        // Debug.Log(players.Length);
        // Debug.Log(Constant.PLAYER_COLORS.Length);
        

        resetCurrentPlayer();

        
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
            Debug.Log("Player length invalid");
            return;
        }

        currentPlayer.CanSelect = false;

        int currentIndex = Array.IndexOf(players, currentPlayer);
        int nextIndex = (currentIndex + 1) % players.Length;

        while (jumpOffPlayers != null && jumpOffPlayers.Contains(players[nextIndex]))
        {
            nextIndex = (nextIndex + 1) % players.Length;
        }

        currentPlayer = players[nextIndex];
        currentPlayer.CanSelect = true;
        updateUI();
        Debug.Log("CurrentPlayer: " + currentPlayer.number);
    }

    private void resetCurrentPlayer(){
        
        if(players.Length <= 0){
            Debug.Log("player length invaild");
            return;
        }

        if(currentPlayer != null){
            currentPlayer.CanSelect = false;
        }
        currentPlayer = players[0];
        currentPlayer.CanSelect = true;
    }

    private void updateUI(){
        GameObject.Find("UI").GetComponent<UIManager>().setCurrentPlayerText(currentPlayer);
        GameObject.Find("UI").GetComponent<UIManager>().setTroopsText(ClientPlayer.troops);
    }




}
