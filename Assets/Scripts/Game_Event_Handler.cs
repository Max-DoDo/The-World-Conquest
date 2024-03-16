using UnityEngine;
using UnityEngine.EventSystems;

public class Game_Event_Handler : MonoBehaviour,IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePositionfix = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(mousePositionfix);
        Ray2D ray= new(mousePositionfix,Vector2.down);
        Debug.DrawRay(ray.origin,ray.direction,Color.blue);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);



        if(hit.collider != null){
            Debug.Log(hit.collider.gameObject);
            GameObject hitObject = hit.collider.gameObject;
            hitObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}