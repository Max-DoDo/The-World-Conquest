
using UnityEngine;

public class Client: MonoBehaviour
{   
    public Player player;

    public void setPlayer(Player player){
        this.player = player;
        updateInformationPanel();
    }

    private void updateInformationPanel(){
        
    }

}
