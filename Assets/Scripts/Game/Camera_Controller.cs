using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


/// <summary>
///     This script is design for control the movement and zoom action of the main camera in the game scene.
///     
/// </summary>
/// <author>
///     Max Wang
/// </author>
public class Camera_Controller : MonoBehaviour
{
    /// <summary>
    ///     The camera scroll speed increment. This is NOT the only value affecting the scrolling speed.
    ///     This value should not be less than 0, as it may result in unexpected consequences. 
    ///     When this value equals 0, the camera will be unable to move.
    /// </summary>
    private float moveSpeed;

    /// <summary>
    ///     The initial size of the camera's viewport.
    ///     note that this value should not exceed the <c>maxZoomSize</c> or smaller than <c>minZoomSize</c>.
    ///     Meanwhile, setting the value too large will cause Unity to throw an exception.
    ///     Negative values will result in the map being flipped.
    /// </summary>
    private float init_ZoomSize;

    /// <summary>
    ///     A interpolate used to modify the distance the camera moves each time. 
    ///     This value will be init at the<c>MoveCamera()</c> method.
    ///     This value takes into account frame rate factors, current zoom rate factors, movement speed factors, and a constant.
    ///     Using this value to interpolate the map movement distance will result in more stable movement distance under different circumstances.
    /// </summary>
    // private float interpolate;

    /// <summary>
    ///     The 2D vector contain the mininum value of camera position in X and Y.
    ///     note that this value is not the final determinant; 
    ///     it will be interpolated to maintain nearly the same scaling ratio under different scaling sizes.
    /// </summary>
    private Vector2 MinXY;

    /// <summary>
    ///     The 2D vector contain the maxinum value of camera position in X and Y.
    ///     note that this value is not the final determinant; 
    ///     it will be interpolated to maintain nearly the same scaling ratio under different scaling sizes.
    /// </summary>
    private Vector2 MaxXY;

    /// <summary>
    ///     This value control the constant value in the equation for calculate the camera zoom rate.
    ///     Note that this value being negative will reverse the direction of the mouse scroll wheel.
    /// </summary>
    private float mouseWheelSpeed;

    /// <summary>
    ///     The offset value in the camera zoom method. In order to smooth the zoom-in and zoom-out action.
    ///     This is the offset between the actual camera zoom size and the distance scrolled by the mouse scroll wheel.
    ///     In each frame, the game can scroll a maximum distance of this value.
    ///     The remaining amount is stored in this value as pre-input for the mouse.
    ///     
    ///     Note that in order to mitigate the issue of excessive offset due to the extensive mouse scrolling by
    ///     the IDIOT user, the offset should have a maximum and minimum value.
    ///     
    ///     Any map scrolling should be completed within two seconds after the user input ends.
    /// </summary>
    private float offset;

    /// <summary>
    /// The maximum zoom size for the camera.
    /// This value have to bigger than<c>minZoomSize</c>
    /// </summary>
    private float maxZoomSize;

    /// <summary>
    /// The minimum zoom size for the camera.
    /// This value have to bigger than<c>maxZoomSize</c>
    /// </summary>
    private float minZoomSize;


    public Canvas canvas;

    /// <summary>
    ///     The method call by Unity when launch. In this method, every field defined above will be init.
    ///     Meanwhile, Reset the camera size and location in a given value.
    /// </summary>
    /// <returns>
    ///  null
    /// </returns>
    private void Start()
    {

        Vector2 screenSize = canvas.GetComponent<RectTransform>().sizeDelta;
        
        moveSpeed = screenSize.x/3;
        init_ZoomSize = screenSize.x/10;
        mouseWheelSpeed = screenSize.x/100;
        // interpolate = 0.0f;
        offset = 0.0f;
        maxZoomSize = screenSize.x/5;
        minZoomSize = screenSize.x/20;

        // canvas = GetComponent<Canvas>();

        // Application.targetFrameRate = 60;
        Camera.main.orthographicSize = init_ZoomSize;
        Camera.main.transform.position = canvas.transform.position;

    }

    /// <summary>
    ///     Called each frame.
    ///     Each frame this function will going to detect the user input.
    /// </summary>
    private void Update()
    {
        ZoomCamera();
        // MoveCamera();
        // Debug.Log(Camera.main.transform.position);
        
    }

    private void MoveCamera()
    {
        // if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){
        //     return;
        // }

        // interpolate = Camera.main.orthographicSize / init_ZoomSize * Time.deltaTime * moveSpeed;
        // float horizontalInput = Input.GetAxis("Horizontal") * interpolate;
        // float verticalInput = Input.GetAxis("Vertical") * interpolate;

        // Vector2 moveAmount = new(horizontalInput, verticalInput);
        // Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + moveAmount;

        // float width = canvas.GetComponent<RectTransform>().sizeDelta.x;
        // float height = canvas.GetComponent<RectTransform>().sizeDelta.y;
        // float ScreenResolutionRate = width/height;
        // float size = Camera.main.orthographicSize;

        // MinXY = new Vector2(size * ScreenResolutionRate + (width * 0.1f),size);
        // MaxXY = new Vector2(width - size * ScreenResolutionRate - (width * 0.1f),height - size);

        // if(MinXY.x > MaxXY.x){
        //     MaxXY.x = MinXY.x = (MaxXY.x+MinXY.x)/2; 
        // }

        // newPosition.x = Mathf.Clamp(newPosition.x, MinXY.x, MaxXY.x);
        // newPosition.y = Mathf.Clamp(newPosition.y, MinXY.y, MaxXY.y);
        
        // transform.position = newPosition;

    }

    private void ZoomCamera()
    {
        // float c = mouseWheelSpeed;
        // float temp = ;
        // Debug.Log(temp);
        
        //get input from mouse wheel
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            offset += mouseWheelSpeed;

        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            offset -= mouseWheelSpeed;
        }

        if (offset >  mouseWheelSpeed * 3)
        {
            offset =  mouseWheelSpeed * 3;
        }
        else if (offset < -mouseWheelSpeed * 3)
        {
            offset = -mouseWheelSpeed * 3;
        }

        float halfsecond =  1 / Time.deltaTime / 30;
        float movementValue = mouseWheelSpeed / halfsecond;

        if (Camera.main.orthographicSize + movementValue < maxZoomSize && offset > movementValue)
        {
            Camera.main.orthographicSize += movementValue;
            offset -= movementValue;
        }else if (Camera.main.orthographicSize - movementValue > minZoomSize && offset < -movementValue)
        {
            Camera.main.orthographicSize -= movementValue;
            offset += movementValue;
        }else{
            offset = 0;
        }

    }
}
