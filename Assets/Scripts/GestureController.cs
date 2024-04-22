using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureController : MonoBehaviour
{
    Vector2 startTouchPos;
    Vector2 endTouchPos;
    float diffX;
    float diffY;
    void Update()
    {
        // Touch Start Position.
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }
        // Touch End Position.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos= Input.GetTouch(0).position;
            // Identify the Type of Gesture.
            TouchType();
        }
    }

    void TouchType()
    {
        diffX=endTouchPos.x-startTouchPos.x;
        diffY=endTouchPos.y-startTouchPos.y;
        if (diffX < diffY)
        {
            if(diffY > 0)
            {
                 // Up Gesture
            }
            else
            {
                // Down Gesture
            }
        }
        else
        {
            Debug.Log(diffX + "-----" + diffY);
            if (diffX > 0)
            {
                // Right Gesture
            }
            else
            {
                // Left Gesture
            }
        }
    }


}
