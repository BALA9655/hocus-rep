using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public  int activeMission = 1;
    public bool isPlayerInMovement = false;
    public JunctionController currentJunction;
    public GameObject PlayerRef;
    public GameData gameData;

    public enum missionType { Easy,Medium,Hard,Impossible };
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    // GameData

    [System.Serializable]
    public class MissionData
    {
        public int missionid;
        public string missionName;
        public missionType missionType;
    }
    [System.Serializable]
    public class GameData
    {
        public List<MissionData> missions;
    }

    // This will Implemented for storing the player data.

    [System.Serializable]
    public class SaveData
    {
        public int currentmission;
    }
    public void SaveProgress()
    {
        // It will not work on WEBGL Build. For that we want to use the browser storage.
        SaveData data = new SaveData();
        data.currentmission=activeMission;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/PlayerProgress.json", json);
    }

    public void LoadProgress()
    {
        // It will not work on WEBGL Build. For the we want to use the browser storage.
        string path = Application.persistentDataPath + "/PlayerProgress.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            activeMission = data.currentmission;

        }
    }

    public void LoadGameData()
    {
        // It will not work on WEBGL Build. For the we want to use the browser storage.
        string path = Application.persistentDataPath + "/GameData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            gameData = data;

        }
        else
        {
            var jsonTextFile = Resources.Load<TextAsset>("GameData");
            GameData data = JsonUtility.FromJson<GameData>(jsonTextFile.ToString());
            gameData = data;
            File.WriteAllText(Application.persistentDataPath + "/PlayerProgress.json", jsonTextFile.ToString());
        }
    }
}
