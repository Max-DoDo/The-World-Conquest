using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas canvas;

    float mouseWheelSpeed;

    private float interpolate;

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

    void Start()
    {

        Vector2 screenSize = canvas.GetComponent<RectTransform>().sizeDelta;

        Camera.main.orthographicSize = screenSize.x/10;

        //Make Camera at the center of canvas
        Camera.main.transform.position = canvas.transform.position;

        mouseWheelSpeed = screenSize.x;
        maxZoomSize = screenSize.x/5;
        minZoomSize = screenSize.x/20;
    }

    // Update is called once per frame
    void Update()
    {
        zoomCamera();
    }


    private void zoomCamera(){

        float offset = 0;

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            offset += mouseWheelSpeed;

        }else if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            offset -= mouseWheelSpeed;
        }

        // 限制offset的范围
        offset = Math.Abs(offset * Time.deltaTime) * 2;
        Debug.Log(offset);
        

        if (offset > 0 && Camera.main.orthographicSize + offset < maxZoomSize){
            Camera.main.orthographicSize += offset;
        }
        else if (offset < 0 && Camera.main.orthographicSize - offset > minZoomSize){
            Camera.main.orthographicSize -= offset;
        }

    }
}
