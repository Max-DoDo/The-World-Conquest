using UnityEngine;

/// <summary>
/// 
/// </summary>
/// <author>
/// 
/// </author>
public class Country : MonoBehaviour
{

    public bool isEnable;

    public bool isSelected;

    public Color color;

    private Player owner;

    private int troops;

    public int continent;


    void Start()
    {
        init();
    }

    private void init()
    {
        isEnable = true;
        color = Color.white;
        troops = 0;
        // this.GetComponent<SpriteRenderer>().color = color;
    }

    public Player getOwner(){
        return owner;
    }

    public bool isOwned(){
        if(owner == null){
            return false;
        }
        return true;
    }

    public void setOwner(Player player){
        
        this.owner = player;
        this.color = player.color;
        this.GetComponent<SpriteRenderer>().color = color;
        this.troops = 1;
        Debug.Log("set owner:" + player + "Color" + this.GetComponent<SpriteRenderer>().color);
    }

    public void setOwner(Player player,int army){
        this.owner = player;
        this.color = player.color;
        this.GetComponent<SpriteRenderer>().color = color;
        this.troops = army;
    }

    public int getTroops(){
        return troops;
    }

    public void setTroops(int troops){
        this.troops = troops;
    }

    public void addTroops(int troops){
        this.troops += troops;
    }



}
