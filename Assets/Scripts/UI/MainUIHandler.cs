using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class MainUIHandler : MonoBehaviour
{
    //This Class Handle all the UI related function in the main Scene.
    public static MainUIHandler Instance;
    public Transform topHud;
    public Transform LevelUI;
    public Transform LevelUIParent;
    public GameObject LevelUIPrefab;
    public TextMeshProUGUI levelText;
    public GameObject LevelPrefabParent;

    [Header("Path Indicator")]
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;

    void Awake()
    {
        Instance=this;
    }

    void Start()
    {
        // Intial mission selection screen loading.
        LevelUIDataProcess();
    }
    
    public void UIAnimation(string uiName,bool status=false)
    {
        // UI Open and Close Animation Function.
        switch(uiName)
        {
            case "tophud":
                    ScaleUI(topHud,status);
                break;
            case "level":
                    ScaleUI(LevelUI,status);
                    if(status)
                        LevelUIDataProcess();
                break;

        }
    }

    void ScaleUI(Transform ui,bool isClose=false)
    {
        if(isClose)
        {
            ui.DOScale(Vector3.one,2f);
        }
        else
        {
            ui.DOScale(Vector3.zero,2f);
        }
    }

    public void LevelUIDataProcess()
    {
        if(LevelUIParent.childCount >0)
        {
            foreach(Transform child in LevelUIParent)
            {
                Destroy(child.gameObject);
            }
        }

        if(DataManager.Instance.gameData.missions.Count >0)
        {
            var missions = DataManager.Instance.gameData.missions;
            foreach(var data in missions)
            {
                GameObject go =Instantiate(LevelUIPrefab,LevelUIParent);
                go.GetComponent<LevelSelectorController>().LevelDataSetter(data.missionid,data.missionName,data.missionType);
            }
        }
    }

    public void DisableAllPath()
    {
        PathAnimation("up");
        PathAnimation("down");
        PathAnimation("left");
        PathAnimation("right");
    }
    // Enable and Disable the Path direction availability for the current Junction.
    public void PathAnimation(string direction,bool status=false)
    {
        if(status)
        {
            switch(direction)
            {
                case "up":
                    EnablePathAnimation(up);
                    break;
                case "down":
                    EnablePathAnimation(down);
                    break;
                case "left":
                    EnablePathAnimation(left);
                    break;
                case "right":
                    EnablePathAnimation(right);
                    break;
            }
        }
        else
        {
            switch(direction)
            {
                case "up":
                    DisablePathAnimation(up);
                    break;
                case "down":
                    DisablePathAnimation(down);
                    break;
                case "left":
                    DisablePathAnimation(left);
                    break;
                case "right":
                    DisablePathAnimation(right);
                    break;
            }
        }
    }

    void EnablePathAnimation(Transform t)
    {
        t.DOScale(Vector2.one,1f).SetLoops(-1,LoopType.Yoyo);
    }

    void DisablePathAnimation(Transform t)
    {
        t.DOKill();
        t.localScale=Vector2.zero;
    }
}
