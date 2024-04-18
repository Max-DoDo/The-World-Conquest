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

    private int army;

    public int continent;


    void Start()
    {
        isEnable = true;
        color = Color.white;
        army = 0;

        init();
    }

    private void init()
    {
        this.GetComponent<SpriteRenderer>().color = color;
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
        this.army = 1;
        Debug.Log("set owner:" + player + "Color" + this.GetComponent<SpriteRenderer>().color);
    }

    public void setOwner(Player player,int army){
        this.owner = player;
        this.color = player.color;
        this.GetComponent<SpriteRenderer>().color = color;
        this.army = army;
    }



}
