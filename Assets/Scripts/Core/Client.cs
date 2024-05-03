using Unity.VisualScripting;
using UnityEngine;

public class Client: MonoBehaviour
{   
    public Player player;


    void Start(){
        
    }

    public void setPlayer(Player player){
        this.player = player;
        updateInformationPanel();
    }

    private void updateInformationPanel(){
        
    }

}
