using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorController : MonoBehaviour
{
    Button select;
    public int missionId;
    public string missionName;
    public DataManager.missionType missionType;

    //Constructor for while Instatntiate.
    public void LevelDataSetter(int id,string name,DataManager.missionType type)
    {
        missionId=id;
        missionName=name;
        missionType=type;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text="Level "+ missionId.ToString();
        
    }
    void Start()
    {
        select = GetComponent<Button>();
    }
    
    public void StartPlay()
    {
        MainUIHandler.Instance.UIAnimation("level");
        MainUIHandler.Instance.UIAnimation("tophud",true);
        DataManager.Instance.activeMission=missionId;
        MainUIHandler.Instance.levelText.text="Level-"+ missionId.ToString()+" : "+missionName;
    }
    
}
