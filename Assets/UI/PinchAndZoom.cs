using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinchAndZoom : MonoBehaviour
{
    float MouseZoomSpeed = 0.001f;
    float TouchZoomSpeed = 0.001f;
    float ZoomMinBound = 0f;
    float ZoomMaxBound = 0.336f;
    CanvasScaler canv;

    // Use this for initialization
    void Start()
    {
        canv = GameObject.Find("Canvas").GetComponent<CanvasScaler>();
        canv.matchWidthOrHeight = PlayerPrefs.GetFloat("Zoom");
    }

    void Update()
    {
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {

                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance (tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance (tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom (deltaDistance, TouchZoomSpeed);
            }
        }
        else
        {

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll, MouseZoomSpeed);
        }



        if(canv.matchWidthOrHeight < ZoomMinBound) 
        {
            canv.matchWidthOrHeight = 0f;
        }
        else if(canv.matchWidthOrHeight > ZoomMaxBound ) 
        {
            canv.matchWidthOrHeight = 0.336f;
        }
    }

    void Zoom(float deltaMagnitudeDiff, float speed)
    {

        canv.matchWidthOrHeight += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
        canv.matchWidthOrHeight = Mathf.Clamp(canv.matchWidthOrHeight, ZoomMinBound, ZoomMaxBound);
        PlayerPrefs.SetFloat("Zoom", canv.matchWidthOrHeight);
    }
}