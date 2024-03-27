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
public class Counrty : MonoBehaviour
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

    private void init(){
        this.GetComponent<SpriteRenderer>().color = color;
    }

    public void select(){
        
    }

}
