using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


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
    private float adjustment_value;

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

        RectTransform rt = canvas.GetComponent<RectTransform>();
        Vector2 screenSize = new(Screen.currentResolution.width,Screen.currentResolution.height);
        
        moveSpeed = screenSize.x/5;
        init_ZoomSize = screenSize.x/10;
        mouseWheelSpeed = screenSize.x/20;
        adjustment_value = 0.0f;
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
        MoveCamera();
        // Debug.Log(Camera.main.transform.position);
        
    }

    private void MoveCamera()
    {

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){
            return;
        }

        // Get Movement speed and direction
        adjustment_value = Camera.main.orthographicSize / init_ZoomSize * Time.deltaTime * moveSpeed;
        float horizontalInput = Input.GetAxis("Horizontal") * adjustment_value;
        float verticalInput = Input.GetAxis("Vertical") * adjustment_value;

        Vector2 moveAmount = new(horizontalInput, verticalInput);
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + moveAmount;

        // Get a value between 0 and 1 for the zoom rate.
        float LerpValue = Mathf.InverseLerp(minZoomSize, maxZoomSize, Camera.main.orthographicSize);
        LerpValue = (float)Math.Round(LerpValue * 100f) / 100;
        LerpValue = Mathf.Clamp01(LerpValue);

        float width = Screen.currentResolution.width;
        float height = Screen.currentResolution.height;
        float ScreenResolutionRate = width/height;
        float size = Camera.main.orthographicSize;

        MinXY = new Vector2(size * ScreenResolutionRate + 200,size);
        MaxXY = new Vector2((width - size * ScreenResolutionRate) - 200,height - size);
        Debug.Log("Size: " + Camera.main.orthographicSize);
        Debug.Log("MinXY: " + MinXY);
        Debug.Log("MaxXY: " + MaxXY);

        // Vector2 newMinXY = MinXY * LerpValue;
        // Vector2 newMaxXY = MaxXY * LerpValue;

        newPosition.x = Mathf.Clamp(newPosition.x, MinXY.x, MaxXY.x);
        newPosition.y = Mathf.Clamp(newPosition.y, MinXY.y, MaxXY.y);

        
        transform.position = newPosition;

    }

//TODO 将屏幕分辨率修改为canvas的长和宽
    private void ZoomCamera()
    {

        //get input from mouse wheel
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            offset += 1000 * Time.deltaTime;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            offset -= 1000 * Time.deltaTime;
        }

        if (offset > 2.5)
        {
            offset = 2.5f;
        }
        else if (offset < -2.5)
        {
            offset = -2.5f;
        }

        float c = mouseWheelSpeed * Time.deltaTime * 30;

        if (offset > c)
        {
            if (Camera.main.orthographicSize + c <= maxZoomSize)
            {
                Camera.main.orthographicSize += c;
            }
            offset -= c;
        }
        else if (offset < (-c))
        {
            if (Camera.main.orthographicSize - c >= minZoomSize)
            {
                Camera.main.orthographicSize -= c;
            }
            offset += c;
        }
        else
        {
            offset = 0;
        }

    }
}
