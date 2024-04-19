
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

    private Country SelectCountry1;

    private Country SelectCountry2;

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

        test();
    }

    private void test(){
        Debug.Log("=============TEST====================");
        ;
        CountryManager.isNearBy(GameObject.Find("China").GetComponent<Country>(),GameObject.Find("India").GetComponent<Country>());

        Debug.Log("=============END TEST=================");
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

        currentPlayer = players[0];
    }

    private void newRound(){
        gameMode = Constant.GAMEMODE_SETTROOP;
        foreach (Player player in players){
            player.addTroops(4);
        }

        updateUI();
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
            newRound();
            Debug.Log("===== Game Run =====");
            
        }

    }

    public void setTroopCallBack(Player player, Country country){

        if(CountryManager.checkCountryOwner(player, country)){
            GameObject.Find("UI").GetComponent<UIManager>().scrollBarAwake(player.troops);
            SelectCountry1 = country;
        }else{
            GameObject.Find("UI").GetComponent<UIManager>().scrollBarSleep();
        }
    }

    public void setTroopScrollBarConfirmButtonCallBack(double value){
        
        int intValue = Convert.ToInt32(value);
        Debug.Log("scrollBar Value: " + intValue);
        
        SelectCountry1.addTroops(intValue);
        currentPlayer.zbbTroops(intValue);
        updateUI();
        
    }

    public void switchCardCallBack(){

    }

    public void attackCallBack(Country ownCountry, Country enemyCountry){
        GameObject.Find("UI").GetComponent<UIManager>().scrollBarAwake(ownCountry.getTroops() - 1);
        SelectCountry1 = ownCountry;
        SelectCountry2 = enemyCountry;

    }

    public void attackScrollBarConfirmButtonCallBack(double value){

        Dice d = GameObject.Find("Dices").GetComponent<Dice>();
        int oriAttCount = Convert.ToInt32(value);
        int att = oriAttCount;
        int def = SelectCountry2.getTroops();

        int cA = 0;
        int cD = 0;

        while(true){

            //try to get 3 vs 2
            if(att >= 3){
                cA = 3;
                att -= 3;
            }else{
                cA = att;
                att = 0;
            }

            if(def >= 2){
                cD = 2;
                def -= 2;
            }else{
                cD = def;
                def = 0;
            }

            // roll dices
            int[] aPoint = d.roll(cA);
            int[] dPoint = d.roll(cD);
            int len = 0;


            if(aPoint.Length > dPoint.Length){
                len = dPoint.Length;
            }else{
                len = aPoint.Length;
            }

            while(len != 0){
                int index = len - 1;
                if(aPoint[index] > dPoint[index]){
                    cD -= 1;
                    SelectCountry2.zbbTroops(1);
                }else{
                    cA -= 1;
                    SelectCountry1.zbbTroops(1);
                }
                len--;
            }

            att += cA;
            def += cD;

            if(att == 0){
                break;
            }

            if(def == 0){
                SelectCountry2.setOwner(currentPlayer);
                
            }
        }

    }

    public void defenseCallBack(){

    }

    public void endPhaseCallBack(){

    }

    public void roundSetTroopCallBack(){
        gameMode = Constant.GAMEMODE_ATTACK;
        Debug.Log("ATTACK ROUND");
        
    }

    public void roundAttackCallBack(){
        gameMode = Constant.GAMEMODE_MOVEMENT;
        Debug.Log("MOVEMENT ROUND");

    }

    public void roundMovementCallBack(){
        gameMode = Constant.GAMEMODE_SETTROOP;
        Debug.Log("SETTROOPS ROUND");
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
        // Debug.Log("CurrentPlayer: " + currentPlayer.number);
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
