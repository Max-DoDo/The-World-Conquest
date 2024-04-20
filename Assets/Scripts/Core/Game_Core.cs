
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
        // CountryManager.isNearBy(GameObject.Find("China").GetComponent<Country>(),GameObject.Find("India").GetComponent<Country>());
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

    private void gameStart(){

        nextRound();
        // gameMode = Constant.GAMEMODE_SETTROOP;
        // foreach (Player player in players){
        //     player.addTroops(4);
        // }
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
                nextPlayer(jumpoff);
        }else{
            resetCurrentPlayer();
            //gamerun
            gameStart();
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

        /**
        *   init dice object
        **/
        Dice d = GameObject.Find("Dices").GetComponent<Dice>();
        int att = Convert.ToInt32(value);
        SelectCountry1.zbbTroops(att);
        int def = SelectCountry2.getTroops();

        while(att > 0 && def > 0){

            int attackerDiceCount = Math.Min(att,3);
            int defDiceCount = Math.Min(def,2);

            int[] attackerDice = d.roll(attackerDiceCount);
            int[] defDice = d.roll(defDiceCount);

            Array.Sort(attackerDice);
            Array.Sort(defDice);

            Array.Reverse(attackerDice);
            Array.Reverse(defDice);

            Debug.Log("Att Dice: " + string.Join(", ", attackerDice) + " Def Dice: " + string.Join(", ", defDice));

            int minCount = Math.Min(attackerDiceCount,defDiceCount);

            for(int i = 0; i < minCount; i++){
                if(defDice[i] >= attackerDice[i]){

                    att--;

                }else{
                    def--;
                    SelectCountry2.zbbTroops(1);
                }
                
            }

            Debug.Log("Attacker: " + att + " defener: " + def);

        }


        if(att == 0){
            // attack failure
            Debug.Log("Attack Failure! You troops remain: " + (SelectCountry1.getTroops() - att) + " enemy troops remain: " + def);
            return;
        }

        if(def == 0){
            Debug.Log("Attack success! You troops remain:" + att);
            SelectCountry2.setOwner(currentPlayer);
            SelectCountry2.addTroops(att);
        }


    }

    public void roundSetTroopCallBack(){
        nextRound();
        Debug.Log("ATTACK ROUND");
        
    }

    public void roundAttackCallBack(){
        nextRound();
        Debug.Log("MOVEMENT ROUND");
    }


    public void roundMovementCallBack(){
        nextRound();
        Debug.Log("SETTROOPS ROUND");
    }

    private void nextRound(){
        switch(gameMode){
            case Constant.GAMEMODE_SETTROOP:

                gameMode = Constant.GAMEMODE_ATTACK;
                break;

            case Constant.GAMEMODE_ATTACK:

                gameMode = Constant.GAMEMODE_MOVEMENT;
                break;

            case Constant.GAMEMODE_MOVEMENT:

                gameMode = Constant.GAMEMODE_SETTROOP;
                nextPlayer();
                obtainTroops(currentPlayer);
                break;
            
            case Constant.GAMEMODE_INITCOUNTRY:

                gameMode = Constant.GAMEMODE_SETTROOP;
                if(currentPlayer != null){
                    obtainTroops(currentPlayer);
                }
                break;
            
            default:
                Debug.LogError("Unknown game mode");
                break;
        }
    }

    private void obtainTroops(Player player){

        int entitledTroops = 4;
        player.addTroops(entitledTroops);
        updateUI();

    }
    

    private void nextPlayer(ArrayList jumpOffPlayers = null)
    {
        if (players.Length == 0){
            return;
        }

        currentPlayer.CanSelect = false;
        int currentIndex = Array.IndexOf(players, currentPlayer);
        int nextIndex = GetNextPlayerIndex(currentIndex, jumpOffPlayers);

        updateUI();
        currentPlayer = players[nextIndex];
        updateUI();
        currentPlayer.CanSelect = true;
    }

    private int GetNextPlayerIndex(int currentIndex, ArrayList jumpOffPlayers)
    {
        int nextIndex = (currentIndex + 1) % players.Length;

        while (jumpOffPlayers != null && jumpOffPlayers.Contains(players[nextIndex])){
            nextIndex = (nextIndex + 1) % players.Length;
        }

        return nextIndex;
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

        UIManager uiManager = GameObject.Find("UI").GetComponent<UIManager>();

        if(currentPlayer.mode == Constant.PLAYER_MODE_CLIENT || currentPlayer.mode == Constant.PLAYER_MODE_HOTSET){
            uiManager.setTroopsText(currentPlayer.troops);
        }
        uiManager.setCurrentPlayerText(currentPlayer);
    }




}
