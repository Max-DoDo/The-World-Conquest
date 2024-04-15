using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// 
/// </summary>
/// <author>
/// 
/// </author>
public class Country : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public bool isEnable;

    /// <summary>
    /// 
    /// </summary>
    public bool isSelected;

    /// <summary>
    /// 
    /// </summary>
    public Color color;

    /// <summary>
    /// 
    /// </summary>
    public Player currentPlayer;

    /// <summary>
    /// 
    /// </summary>
    public int army;

    /// <summary>
    /// 
    /// </summary>
    public static Dictionary<string, List<string>> mapData = new Dictionary<string, List<string>>()
    {
        //Asian
        { "Kamchatka", new List<string>{"Yakutsk", "Irkutsk", "Mongolia", "Japan", "Alaska"}},
        { "Yakutsk", new List<string>{"Kamchatka", "Irkutsk", "Siberia"}},
        { "Irkutsk", new List<string>{"Kamchatka", "Yakutsk", "Siberia", "Mongolia"}},
        { "Siberia", new List<string>{"Yakutsk", "Irkutsk", "Ural", "Mongolia", "China"}},
        { "Ural", new List<string>{"Siberia", "Russia", "Afghanistan", "China"}},
        { "Mongolia", new List<string>{"Irkutsk", "Siberia", "Kamchatka", "China", "Japan"}},
        { "Japan", new List<string>{"Mongolia", "Kamchatka"}},
        { "China", new List<string>{"Mongolia", "Afghanistan", "SoutheastAsia", "India", "Siberia"}},
        { "Afghanistan", new List<string>{"Russia", "Ural", "China", "India", "MiddleEast"}},
        { "MiddleEast", new List<string>{"Russia", "SouthernEurope", "Egypt", "Afghanistan", "India"}},
        { "India", new List<string>{"SoutheastAsia", "Afghanistan", "MiddleEast", "China"}},
        { "SoutheastAsia", new List<string>{"Indonesia", "China", "India"}},

        //Australia
        { "Indonesia", new List<string>{"SoutheastAsia", "WesternAustralia"}},
        { "NewGuinea", new List<string>{"Indonesia", "EasternAustralia"}},
        { "WesternAustralia", new List<string>{"Indonesia", "EasternAustralia"}},
        { "EasternAustralia", new List<string>{"NewGuinea", "WesternAustralia"}},

        //Africa
        { "NorthAfrica", new List<string>{"Egypt", "WesternEuropen", "EastAfrica", "CentralAfrica", "Brazil"}},
        { "Egypt", new List<string>{"MiddleEast", "SouthternEurope", "NorthAfrica", "EastAfrica"}},
        { "EastAfrica", new List<string>{"Egypt", "NorthAfrica", "CentralAfrica", "SouthAfrica", "Madagascar"}},
        { "CentralAfrica", new List<string>{"NorthAfrica", "EastAfrica", "SouthAfrica"}},
        { "SouthAfrica", new List<string>{"CentralAfrica", "EastAfrica", "Madagascar"}},
        { "Madagascar", new List<string>{"SouthAfrica", "EastAfrica"}},

        //Europe
        { "Russia", new List<string>{"Ural", "Afghanistan", "MiddleEast", "Scandinavia", "NorthernEurope", "SouthernEurope"}},
        { "Scandinavia", new List<string>{"Russia", "Iceland", "GreatBritain", "NothernEurope"}},
        { "Iceland", new List<string>{"Greenland", "Scandinavia", "GreatBritain"}},
        { "GreatBritain", new List<string>{"Iceland", "Scandinavia", "NorthernEurope", "WesternEurope"}},
        { "NorthernEurope", new List<string>{"Scandinavia", "GreatBritain", "SouthernEurope", "WesternEurope", "Russia"}},
        { "SouthernEurope", new List<string>{"Russia", "NorthernEurope", "WesternEurope", "MiddleEast", "Egypt", "NorthAfrica"}},
        { "WesternEurope", new List<string>{"NorthernEurope", "SouthernEurope", "GreatBritain", "NorthAfrica"}},

        //NorthAmerica
        { "Greenland", new List<string>{"NorthwestTerritory", "Ontario", "EasternCanada", "Iceland"}},
        { "NorthwestTerritory", new List<string>{"Alaska", "Alberta", "Ontario", "Greenland"}},
        { "Alaska", new List<string>{"NorthwestTerritory", "Alberta", "Kamchatka"}},
        { "Alberta", new List<string>{"Alaska", "NorthwestTerritory", "Ontario", "WesternUnitedStates"}},
        { "Ontario", new List<string>{"Alberta", "WesternUnitedStates", "EasternUnitedStates", "EasternCanada", "Greenland", "NorthwestTerritory"}},
        { "EasternCanada", new List<string>{"Ontario", "EasternUnitedStates", "Greenland"}},
        { "WesternUnitedStates", new List<string>{"Alberta", "Ontario", "EasternUnitedStates", "CentralAmerica"}},
        { "EasternUnitedStates", new List<string>{"CentralAmerica", "Ontario", "EasternCanada", "WesternUnitedStates"}},
        { "CentralAmerica", new List<string>{"WesternUnitedStates", "EasternUnitedStates", "Venezuela"}},

        //SouthAmerica
        { "Venezuela", new List<string>{"CentralAmerica", "Brazil", "Peru"}},
        { "Brazil", new List<string>{"Venezuela", "Peru", "Argentina"}},
        { "Peru", new List<string>{"Venezuela", "Brazil", "Argentina"}},
        { "Argentina", new List<string>{"Peru", "Brazil"}}
    };

    /// <summary>
    /// 
    /// </summary>
    /// <param name= "">  </param>
    /// <returns>
    /// 
    /// </returns>
    void Start()
    {
        isEnable = true;
        color = Color.white;
        army = 0;

        init();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name= "">  </param>
    /// <returns>
    /// 
    /// </returns>
    private void init()
    {
        this.GetComponent<SpriteRenderer>().color = color;
    }

    public void select()
    {
        if (!isEnable || isSelected)
        {
            return;
        }

    }

    public static explicit operator Country(GameObject v)
    {
        throw new NotImplementedException();
    }
}
