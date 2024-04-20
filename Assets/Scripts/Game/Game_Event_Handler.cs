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

    public LayerMask layerMaskMousePointer;

    // public LayerMask layerMaskDrag;

    public Canvas canvas;

    private bool isDrag;

    private Vector2 mousePositionfix;

    private Vector2 minXY;

    private Vector2 maxXY;

    public void OnPointerClick()
    {   

        if (isDrag){
            return;
        }

        mousePositionfix = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray= new(mousePositionfix,Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,Mathf.Infinity,layerMaskMousePointer);

        if(hit.collider.gameObject.CompareTag("Country"))
        {
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

    public void beginDrag(){
        isDrag = true;
        mousePositionfix = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void onDrag(){

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = mousePosition - mousePositionfix;
        transform.position += (Vector3)offset;

        mousePositionfix = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    public void endDrag(){
        isDrag = false;
    }

    void Update(){

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){
            return;
            
        }
        
        float size = Camera.main.orthographicSize;

        float width = canvas.GetComponent<RectTransform>().sizeDelta.x;
        float height = canvas.GetComponent<RectTransform>().sizeDelta.y;
        float ScreenResolutionRate = width / height;

        minXY = new Vector2(size * ScreenResolutionRate + (width * 0.1f),size);
        maxXY = new Vector2(width - size * ScreenResolutionRate - (width * 0.1f),height - size);

        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * 750 * -1;
        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * 750 * -1;
        Vector2 moveAmount = new(horizontalInput, verticalInput);
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + moveAmount;

        if(minXY.x > maxXY.x){
            maxXY.x = minXY.x = (maxXY.x+minXY.x)/2; 
        }

        newPosition.x = Mathf.Clamp(newPosition.x, minXY.x, maxXY.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minXY.y, maxXY.y);
        
        transform.position = newPosition;

    }


}