using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Core : MonoBehaviour
{
    /// <summary>
    /// List of players participating in the game.
    /// </summary>
    public List<Player> players;

    /// <summary>
    /// The current player whose turn it is.
    /// </summary>
    public Player currentPlayer;

    /// <summary>
    /// The current game mode.
    /// </summary>
    public int gameMode;

    /// <summary>
    /// Array containing all the countries in the game.
    /// </summary>
    private Country[] countries;

    /// <summary>
    /// List of local players.
    /// </summary>
    private List<Player> localPlayer;

    /// <summary>
    /// The first selected country.
    /// </summary>
    private Country selectCountry1;

    /// <summary>
    /// The second selected country.
    /// </summary>
    private Country selectCountry2;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    /// <summary>
    /// Initializes the game.
    /// </summary>
    private void init(){
        countries = GameObject.FindObjectsOfType<Country>();
        gameMode = Constant.GAMEMODE_INITCOUNTRY;

        initPlayers();
        resetCurrentPlayer();
        test();
    }

    /// <summary>
    /// Runs a test.
    /// </summary>
    private void test(){
        Debug.Log("=============TEST====================");
        // CountryManager.isNearBy(GameObject.Find("China").GetComponent<Country>(),GameObject.Find("India").GetComponent<Country>());
        Debug.Log("=============END TEST=================");
    }

    /// <summary>
    /// Initializes the players.
    /// </summary>
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

    /// <summary>
    /// Starts the game.
    /// </summary>
    private void gameStart(){

        nextRound();
        // gameMode = Constant.GAMEMODE_SETTROOP;
        // foreach (Player player in players){
        //     player.addTroops(4);
        // }
        updateUI();
    }

    /// <summary>
    /// Callback function for initializing troop placement.
    /// </summary>
    public void initSetTroopCallBack(){

        //check if anybody already used all init troops
        ArrayList jumpoff = new ArrayList();
        foreach (Player player in players)
        {
            if(player.troops <= 0){
                jumpoff.Add(player);
            }
        }

        if(jumpoff.Count < players.Count){
                nextPlayer(jumpoff);
        }else{
            resetCurrentPlayer();
            //gamerun
            gameStart();
            Debug.Log("===== Game Run =====");
            
        }

    }

    /// <summary>
    /// Callback function for setting troops.
    /// </summary>
    /// <param name="player">The player setting the troops.</param>
    /// <param name="country">The country where troops are being placed.</param>
    public void setTroopCallBack(Player player, Country country){

        if(CountryManager.checkCountryOwner(player, country)){
            GameObject.Find("UI").GetComponent<UIManager>().scrollBarAwake(player.troops);
            selectCountry1 = country;
        }else{
            GameObject.Find("UI").GetComponent<UIManager>().scrollBarSleep();
        }
    }

    /// <summary>
    /// Callback function for confirming troop selection.
    /// </summary>
    /// <param name="value">The number of troops selected.</param>
    public void setTroopScrollBarConfirmButtonCallBack(double value){
        
        int intValue = Convert.ToInt32(value);
        // Debug.Log("scrollBar Value: " + intValue);
        
        selectCountry1.addTroops(intValue);
        currentPlayer.zbbTroops(intValue);
        updateUI();
        
    }

    /// <summary>
    /// Callback function for switching cards.
    /// </summary>
    public void switchCardCallBack(){

    }

    /// <summary>
    /// Callback function for initiating an attack.
    /// </summary>
    /// <param name="ownCountry">The attacking country.</param>
    /// <param name="enemyCountry">The defending country.</param>
    public void attackCallBack(Country ownCountry, Country enemyCountry){
        GameObject.Find("UI").GetComponent<UIManager>().scrollBarAwake(ownCountry.getTroops() - 1);
        selectCountry1 = ownCountry;
        selectCountry2 = enemyCountry;

    }

    /// <summary>
    /// Callback function for confirming the attack.
    /// </summary>
    /// <param name="value">The number of troops used in the attack.</param>
    public void attackScrollBarConfirmButtonCallBack(double value){

        /**
        *   init dice object
        **/
        Dice d = GameObject.Find("Dices").GetComponent<Dice>();
        int att = Convert.ToInt32(value);
        selectCountry1.zbbTroops(att);
        int def = selectCountry2.getTroops();

        while(att > 0 && def > 0){

            int attackerDiceCount = Math.Min(att,3);
            int defDiceCount = Math.Min(def,2);

            int[] attackerDice = d.roll(attackerDiceCount);
            int[] defDice = d.roll(defDiceCount);

            Array.Sort(attackerDice);
            Array.Sort(defDice);

            Array.Reverse(attackerDice);
            Array.Reverse(defDice);

            // Debug.Log("Att Dice: " + string.Join(", ", attackerDice) + " Def Dice: " + string.Join(", ", defDice));

            int minCount = Math.Min(attackerDiceCount,defDiceCount);

            for(int i = 0; i < minCount; i++){
                if(defDice[i] >= attackerDice[i]){

                    att--;

                }else{
                    def--;
                    selectCountry2.zbbTroops(1);
                }
                
            }

            // Debug.Log("Attacker: " + att + " defener: " + def);

        }


        if(att == 0){
            // attack failure
            GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("Attack Failure! You troops remain: " + (selectCountry1.getTroops() - att) + " enemy troops remain: " + def);
            return;
        }

        if(def == 0){
            GameObject.Find("UI").GetComponent<UIManager>().setPopUpText("Attack success! You troops remain:" + att);
            selectCountry2.setOwner(currentPlayer);
            selectCountry2.addTroops(att);
        }
        isDefeated();
        updateUI();

    }

    /// <summary>
    /// Callback function for troop movement.
    /// </summary>
    /// <param name="startCountry">The country troops are moving from.</param>
    /// <param name="endCountry">The country troops are moving to.</param>
    public void movementCallBack(Country startCountry, Country endCountry){
        GameObject.Find("UI").GetComponent<UIManager>().scrollBarAwake(startCountry.getTroops() - 1);
        selectCountry1 = startCountry;
        selectCountry2 = endCountry;
    }

    /// <summary>
    /// Callback function for confirming troop movement.
    /// </summary>
    /// <param name="value">The number of troops being moved.</param>
    public void movementScrollBarConfirmButtonCallBack(double value){
        int troops = Convert.ToInt32(value);
        selectCountry1.zbbTroops(troops);
        selectCountry2.addTroops(troops);
        updateUI();
    }

    /// <summary>
    /// Callback function for the end of the troop placement round.
    /// </summary>
    public void roundSetTroopCallBack(){
        nextRound();
        Debug.Log("ATTACK ROUND");
        
    }

    /// <summary>
    /// Callback function for the end of the attack round.
    /// </summary>
    public void roundAttackCallBack(){
        nextRound();
        Debug.Log("MOVEMENT ROUND");
    }

    /// <summary>
    /// Callback function for the end of the troop movement round.
    /// </summary>
    public void roundMovementCallBack(){
        nextRound();
        Debug.Log("SETTROOPS ROUND");
    }

    // Determines the next round and switches game mode accordingly.
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

    // Calculates and assigns troop bonuses to players.
    private void obtainTroops(Player player){

        int entitledTroops = 40;
        player.addTroops(entitledTroops);
        updateUI();

    }

    // Checks if any player has been defeated.
    private void isDefeated(){

        List<Player> defeatedPlayer = new List<Player>();

        foreach (Player player in players){
            bool isOwnCountry = false;
            foreach (Country country in countries){
                if (country.getOwner() == player){
                    isOwnCountry = true;
                    break;
                }
            }

            if(!isOwnCountry){
                defeatedPlayer.Add(player);

                Debug.Log(player + "defeated!");
            }

        }

        foreach (Player player in defeatedPlayer)
        {
            players.Remove(player);
        }

        if(players.Count == 1){
            Debug.Log(players[0] + "Win!");
        }
    }

    // Moves to the next player's turn.
    private void nextPlayer(ArrayList jumpOffPlayers = null)
    {
        if (players.Count == 0){
            return;
        }

        currentPlayer.CanSelect = false;
        int currentIndex = players.IndexOf(currentPlayer);
        int nextIndex = GetNextPlayerIndex(currentIndex, jumpOffPlayers);

        updateUI();
        currentPlayer = players[nextIndex];
        updateUI();
        currentPlayer.CanSelect = true;
    }

    // Finds the index of the next player.
    private int GetNextPlayerIndex(int currentIndex, ArrayList jumpOffPlayers)
    {
        int nextIndex = (currentIndex + 1) % players.Count;

        while (jumpOffPlayers != null && jumpOffPlayers.Contains(players[nextIndex])){
            nextIndex = (nextIndex + 1) % players.Count;
        }

        return nextIndex;
    }

    // Resets the current player to the first player in the list.
    private void resetCurrentPlayer(){
        
        if(players.Count <= 0){
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

    // Updates the game UI.
    private void updateUI(){

        if(currentPlayer == null){
            return;
        }

        UIManager uiManager = GameObject.Find("UI").GetComponent<UIManager>();

        if(currentPlayer.mode == Constant.PLAYER_MODE_CLIENT || currentPlayer.mode == Constant.PLAYER_MODE_HOTSET){
            uiManager.setTroopsText(currentPlayer.troops);
        }
        uiManager.setCurrentPlayerText(currentPlayer);

        if(selectCountry2 != null){
            uiManager.setCountryText(selectCountry2);
            uiManager.setCountryArmyText(selectCountry2);
        }
    }
}
