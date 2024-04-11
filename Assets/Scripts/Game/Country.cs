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
    /// <param name= "">  </param>
    /// <returns>
    /// 
    /// </returns>
    void Start(){
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
    private void init(){
        this.GetComponent<SpriteRenderer>().color = color;
    }

    public void select(){
        
    }

    public static explicit operator Country(GameObject v)
    {
        throw new NotImplementedException();
    }
}
