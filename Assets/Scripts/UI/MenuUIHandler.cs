using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIHandler : MonoBehaviour
{
    public void SaveGameData()
    {
        DataManager.Instance.SaveGameData();
    }
}
