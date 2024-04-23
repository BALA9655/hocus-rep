using DG.Tweening;
using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JunctionController : MonoBehaviour
{
    public bool isStartPoint;
    public bool isEndPoint;

    [Header("Turn Available")]
    public bool isLeft;
    public bool isRight;
    public bool isUp;
    public bool isDown;

    [Header("Destination Point Ref")]
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform upPoint;
    public Transform bottomPoint;

    private void Start()
    {
        if (isStartPoint)
        {
            DataManager.Instance.currentJunction = this;
            MainUIHandler.Instance.DisableAllPath();
            EnablePath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            DataManager.Instance.currentJunction = this;
            if(isEndPoint)
            {
                DataManager.Instance.isPlayerInMovement = false;
                MainUIHandler.Instance.DisableAllPath();
                DOTween.KillAll();
                SceneManager.LoadScene(1);
            }
            else
            {
                EnablePath();
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            MainUIHandler.Instance.DisableAllPath();
        }
    }

    public void MovePlayerToNext(string direction)
    {
        bool move = false;
        Vector3 movePos=Vector3.zero;
        Debug.Log(direction);
        switch(direction)
        {
            case "up":
                if (isUp)
                {
                    move = true;
                    movePos = upPoint.position;
                }
                break;
            case "down":
                if (isDown)
                {
                    move = true;
                    movePos = bottomPoint.position;
                }
                break;
            case "left":
                if (isLeft)
                {
                    move = true;
                    movePos = leftPoint.position;
                }
                break;
            case "right":
                if (isRight)
                {
                    move = true;
                    movePos = rightPoint.position;
                }
                break;
            default:
                move = false;
                movePos = Vector3.zero;

                break;
        }
        Debug.Log(move+"Switch"+ movePos);
        if (move)
        {
            Debug.Log("Switch:- "+movePos);
            DataManager.Instance.isPlayerInMovement = true;
            PlayerController.Instance.transform.DOMove(movePos, 2f).OnComplete(() =>
            {
                DataManager.Instance.isPlayerInMovement = false;
            });
        }
    }

    void EnablePath()
    {
        if(isUp)
        {
            MainUIHandler.Instance.PathAnimation("up",true);
        }
        if(isDown)
        {
            MainUIHandler.Instance.PathAnimation("down",true);
        }
        if(isLeft)
        {
            MainUIHandler.Instance.PathAnimation("left",true);
        }
        if(isRight)
        {
            MainUIHandler.Instance.PathAnimation("right",true);
        }
    }


}
