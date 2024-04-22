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
            if (DataManager.Instance.isPlayerInMovement == false)
            {
                TouchType();
            }
            
        }
    }

    void TouchType()
    {
        diffX=Mathf.Abs(startTouchPos.x-endTouchPos.x);
        diffY=Mathf.Abs(startTouchPos.y-endTouchPos.y);

        if (diffY > diffX)
        {
            if (endTouchPos.y > startTouchPos.y)
            {
                // Up Gesture
                DataManager.Instance.currentJunction.MovePlayerToNext("up");
            }
            else if (endTouchPos.y < startTouchPos.y)
            {
                // Down Gesture
                Debug.Log("Down gestr");
                DataManager.Instance.currentJunction.MovePlayerToNext("down");
            }
        }
        else if (diffX > diffY)
        {

            if (endTouchPos.x < startTouchPos.x)
            {
                // Right Gesture
                Debug.Log("left");
                DataManager.Instance.currentJunction.MovePlayerToNext("left");
            }
            else if (endTouchPos.x > startTouchPos.x)
            {
                Debug.Log("left");
                // Left Gesture
                DataManager.Instance.currentJunction.MovePlayerToNext("right");
            }
        }
    }


}
