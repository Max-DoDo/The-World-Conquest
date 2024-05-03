using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a country in the game.
/// </summary>
public class Country : MonoBehaviour
{
    /// <summary>
    /// Indicates whether the country is enabled or not.
    /// </summary>
    public bool isEnable;

    /// <summary>
    /// Indicates whether the country is selected or not.
    /// </summary>
    public bool isSelected;

    /// <summary>
    /// The color of the country.
    /// </summary>
    public Color color;

    /// <summary>
    /// The player who currently owns the country.
    /// </summary>
    private Player owner;

    /// <summary>
    /// The number of troops stationed in the country.
    /// </summary>
    private int troops;

    /// <summary>
    /// List of neighboring countries.
    /// </summary>
    public List<Country> neighbor;

    /// <summary>
    /// List of countries that are not neighbors.
    /// </summary>
    public List<Country> unNeighbor;

    /// <summary>
    /// The continent to which the country belongs.
    /// </summary>
    public int continent;

    /// <summary>
    /// Initializes the country.
    /// </summary>
    void Start()
    {
        init();
    }

    /// <summary>
    /// Initializes the country with default values.
    /// </summary>
    private void init()
    {
        isEnable = true;
        color = Color.white;
        troops = 0;
        // this.GetComponent<SpriteRenderer>().color = color;
    }

    /// <summary>
    /// Gets the current owner of the country.
    /// </summary>
    /// <returns>The player who owns the country.</returns>
    public Player getOwner(){
        return owner;
    }

    /// <summary>
    /// Checks if the country is owned by any player.
    /// </summary>
    /// <returns>True if the country is owned by a player, false otherwise.</returns>
    public bool isOwned(){
        if(owner == null){
            return false;
        }
        return true;
    }

    /// <summary>
    /// Sets the owner of the country.
    /// </summary>
    /// <param name="player">The player who owns the country.</param>
    public void setOwner(Player player){
        
        this.owner = player;
        this.color = player.color;
        this.GetComponent<SpriteRenderer>().color = color;
        // this.troops = 1;
        // Debug.Log("set owner:" + player + "Color" + this.GetComponent<SpriteRenderer>().color);
    }

    /// <summary>
    /// Sets the owner of the country with a specified number of troops.
    /// </summary>
    /// <param name="player">The player who owns the country.</param>
    /// <param name="army">The number of troops stationed in the country.</param>
    public void setOwner(Player player,int army){
        this.owner = player;
        this.color = player.color;
        this.GetComponent<SpriteRenderer>().color = color;
        this.troops = army;
    }

    /// <summary>
    /// Gets the number of troops stationed in the country.
    /// </summary>
    /// <returns>The number of troops.</returns>
    public int getTroops(){
        return troops;
    }

    /// <summary>
    /// Sets the number of troops stationed in the country.
    /// </summary>
    /// <param name="troops">The number of troops.</param>
    public void setTroops(int troops){
        this.troops = troops;
    }

    /// <summary>
    /// Adds troops to the country.
    /// </summary>
    /// <param name="troops">The number of troops to add.</param>
    public void addTroops(int troops){
        this.troops += troops;
    }

    /// <summary>
    /// Removes troops from the country.
    /// </summary>
    /// <param name="troops">The number of troops to remove.</param>
    public void zbbTroops(int troops){
        this.troops -= troops;
    }

    /// <summary>
    /// Overrides the ToString() method to provide a string representation of the country.
    /// </summary>
    /// <returns>A string containing the country's name, owner, and number of troops.</returns>
    public override string ToString()
    {
        return this.name + " | Owner:" + owner +" Troops: " +this.troops;
    }
}
