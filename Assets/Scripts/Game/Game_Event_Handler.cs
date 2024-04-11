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
        // Debug.DrawRay(ray.origin,ray.direction,Color.blue);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);



        if(hit.collider == null){
            GameObject hitObject = hit.collider.gameObject;
            // hitObject.GetComponent<SpriteRenderer>().color = Color.red;
            // hitObject.GetComponent<Country>().isEnable = true;
            GameObject core = GameObject.Find("Logic_Core");
            Client gamecore = core.GetComponent<Client>();
            gamecore.SelectCountry(hitObject.GetComponent<Country>());

            
        }
    }


}