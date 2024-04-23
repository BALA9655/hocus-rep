using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorController : MonoBehaviour
{
    Button select;
    [Header("Data Container")]
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
        int levelState=0;
        foreach(var level in DataManager.Instance.LevelMap)
        {
            levelState++;
            if(levelState == missionId)
            {
                Debug.Log("Object");
                if(MainUIHandler.Instance.LevelPrefabParent.transform.childCount >0)
                {
                    foreach(Transform t in MainUIHandler.Instance.LevelPrefabParent.transform)
                    {
                        Destroy(t.gameObject);
                    }
                }
                Instantiate(level.transform,MainUIHandler.Instance.LevelPrefabParent.transform);
            }
        }

    }

}
