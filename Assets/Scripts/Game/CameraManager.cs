using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the camera's zooming functionality.
/// </summary>
public class CameraManager : MonoBehaviour
{
    /// <summary>
    /// The canvas used for reference in determining the camera's initial size.
    /// </summary>
    public Canvas canvas;

    /// <summary>
    /// The speed at which the camera zooms in and out in response to mouse input.
    /// </summary>
    private float mouseWheelSpeed;

    /// <summary>
    /// The maximum zoom size allowed for the camera.
    /// This value must be greater than <c>minZoomSize</c>.
    /// </summary>
    private float maxZoomSize;

    /// <summary>
    /// The minimum zoom size allowed for the camera.
    /// This value must be less than <c>maxZoomSize</c>.
    /// </summary>
    private float minZoomSize;

    /// <summary>
    /// Sets the initial camera position and zoom level based on the size of the canvas.
    /// </summary>
    void Start()
    {
        // Determine the size of the canvas
        Vector2 screenSize = canvas.GetComponent<RectTransform>().sizeDelta;

        // Set the initial zoom level of the camera based on the canvas size
        Camera.main.orthographicSize = screenSize.x / 10;

        // Position the camera at the center of the canvas
        Camera.main.transform.position = canvas.transform.position;

        // Set the mouse wheel speed based on the canvas size
        mouseWheelSpeed = screenSize.x;

        // Set the maximum and minimum zoom sizes based on the canvas size
        maxZoomSize = screenSize.x / 5;
        minZoomSize = screenSize.x / 20;
    }

    /// <summary>
    /// Updates the camera's zoom level based on mouse input.
    /// </summary>
    void Update()
    {
        ZoomCamera();
    }

    /// <summary>
    /// Zooms the camera in or out based on mouse scroll input.
    /// </summary>
    private void ZoomCamera()
    {
        float offset = 0;

        // Check for mouse scroll input
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            offset += mouseWheelSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            offset -= mouseWheelSpeed;
        }

        // Limit the offset range
        offset = Mathf.Abs(offset * Time.deltaTime) * 2;

        // Adjust the camera's zoom level within the specified range
        if (offset > 0 && Camera.main.orthographicSize + offset < maxZoomSize)
        {
            Camera.main.orthographicSize += offset;
        }
        else if (offset < 0 && Camera.main.orthographicSize - offset > minZoomSize)
        {
            Camera.main.orthographicSize -= offset;
        }
    }
}
