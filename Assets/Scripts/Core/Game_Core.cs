
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Game_Core : MonoBehaviour
{
    private Player[] players;

    private Player currentPlayer;

    private int gameMode;

    private Country[] countrys;


    

    
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init(){
        countrys = GameObject.FindObjectsOfType<Country>();
        gameMode = 0;
        
        //TODO initplayer by setting
        players = new Player[1];
        players[0] = new Player();
        
        setTroop();
        
    }

    void Update(){
    }

    private void setTroop(){
        gameMode += Constant.GameMode_SetTroop;
        bool isTroopRemain = true;

        while (isTroopRemain)
        {
            foreach(Player player in players){
                if(player.IsAI()){
                    //AI set
                }else{
                    player.selectCountry();
                }

            }


        }

    }

    private void loop(){

    }




}
