using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public  int activeMission = 1;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

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
        File.WriteAllText(Application.persistentDataPath + "/playerprog.json", json);
    }

    public void LoadProgress()
    {
        // It will not work on WEBGL Build. For the we want to use the browser storage.
        string path = Application.persistentDataPath + "/playerprog.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            activeMission = data.currentmission;

        }
    }
}
