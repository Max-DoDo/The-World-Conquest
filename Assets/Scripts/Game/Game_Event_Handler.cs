using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
<<<<<<< HEAD
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

=======
/// Handles events thrown by game objects.
/// </summary>
/// <author>
/// Max Wang
/// </author>
public class Game_Event_Handler : MonoBehaviour
{
    /// <summary>
    /// The layer mask for detecting mouse pointer interactions.
    /// </summary>
    public LayerMask layerMaskMousePointer;

    /// <summary>
    /// The canvas used for reference in determining movement boundaries.
    /// </summary>
    public Canvas canvas;

    private bool isDrag;

    private Vector2 mousePositionfix;

    private Vector2 minXY;

    private Vector2 maxXY;

    /// <summary>
    /// Handles the pointer click event.
    /// </summary>
    public void OnPointerClick()
    {   
        if (isDrag){
            return;
        }

        // Get the mouse position
        mousePositionfix = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Cast a ray from the mouse position
        Ray2D ray = new Ray2D(mousePositionfix, Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMaskMousePointer);

        // Check if the ray hit a game object with the "Country" tag
        if(hit.collider.gameObject.CompareTag("Country"))
        {
            // Get the country object that was hit
            GameObject hitObject = hit.collider.gameObject;
            GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag("Player");
            List<Player> players = new List<Player>();
            Country selectedCountry = hitObject.GetComponent<Country>();

            // Update UI elements with information about the selected country
            GameObject.Find("UI").GetComponent<UIManager>().setCountryText(selectedCountry);
            GameObject.Find("UI").GetComponent<UIManager>().setCountryArmyText(selectedCountry);
            
            // Get a list of players
>>>>>>> develop
            foreach (GameObject gameObject in gameObjectsWithTag){
                players.Add(gameObject.GetComponent<Player>());
            }

<<<<<<< HEAD
            foreach (Player player in players){
                if(player.CanSelect){
                    player.selectCountry(hitObject.GetComponent<Country>());
                    break;
                }
            }


            

        }
    }


}
=======
            // Call the mouse event callback function for the player that can select
            foreach (Player player in players){
                if(player.CanSelect){
                    player.MouseEventCallBack(selectedCountry);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Begins dragging the game object.
    /// </summary>
    public void beginDrag(){
        isDrag = true;
        mousePositionfix = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    /// <summary>
    /// Handles dragging of the game object.
    /// </summary>
    public void onDrag(){

        // Calculate the mouse position offset
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = mousePosition - mousePositionfix;
        Vector2 newPosition = transform.position + (Vector3)offset;
        
        // Calculate movement boundaries based on canvas size and camera orthographic size
        float size = Camera.main.orthographicSize;
        float width = canvas.GetComponent<RectTransform>().sizeDelta.x;
        float height = canvas.GetComponent<RectTransform>().sizeDelta.y;
        float ScreenResolutionRate = width / height;

        minXY = new Vector2(size * ScreenResolutionRate + (width * 0.1f), size);
        maxXY = new Vector2(width - size * ScreenResolutionRate - (width * 0.1f), height - size);
        
        // Clamp the new position within the boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minXY.x, maxXY.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minXY.y, maxXY.y);
        
        // Set the new position
        transform.position = newPosition;

        mousePositionfix = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    /// <summary>
    /// Ends dragging of the game object.
    /// </summary>
    public void endDrag(){
        isDrag = false;
    }

    void Update(){

        // Check for horizontal and vertical input
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){
            return;
        }
        
        // Calculate movement boundaries based on canvas size and camera orthographic size
        float size = Camera.main.orthographicSize;
        float width = canvas.GetComponent<RectTransform>().sizeDelta.x;
        float height = canvas.GetComponent<RectTransform>().sizeDelta.y;
        float ScreenResolutionRate = width / height;

        minXY = new Vector2(size * ScreenResolutionRate + (width * 0.1f), size);
        maxXY = new Vector2(width - size * ScreenResolutionRate - (width * 0.1f), height - size);

        // Calculate the movement amount based on input and time
        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * 750 * -1;
        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * 750 * -1;
        Vector2 moveAmount = new Vector2(horizontalInput, verticalInput);
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + moveAmount;

        // Adjust boundaries if minimum x and maximum x are the same
        if(minXY.x > maxXY.x){
            maxXY.x = minXY.x = (maxXY.x + minXY.x) / 2; 
        }

        // Clamp the new position within the boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minXY.x, maxXY.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minXY.y, maxXY.y);
        
        // Set the new position
        transform.position = newPosition;
    }
}
>>>>>>> develop
