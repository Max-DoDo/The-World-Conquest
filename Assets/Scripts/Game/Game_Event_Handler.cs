using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///     This class is design for the handle the event throw by the game object.
///     In this class.
/// </summary>
/// <author>
///     Max Wang
/// </author>
public class Game_Event_Handler : MonoBehaviour
{

    public void OnPointerClick()
    {
        Vector2 mousePositionfix = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray= new(mousePositionfix,Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);

        if(hit.collider != null){
            // 我头都薅掉了都没发现这里哪里出了问题
            
            //get the object be collded.
            GameObject hitObject = hit.collider.gameObject;
            GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag("Player");
            List<Player> players = new List<Player>();
            Country selectedCountry = hitObject.GetComponent<Country>();
            Debug.Log(selectedCountry);
            foreach (GameObject gameObject in gameObjectsWithTag){
                players.Add(gameObject.GetComponent<Player>());
            }

            foreach (Player player in players){
                if(player.CanSelect){
                    player.MouseEventCallBack(selectedCountry);
                    
                    break;
                }
            }


            

        }
    }


}