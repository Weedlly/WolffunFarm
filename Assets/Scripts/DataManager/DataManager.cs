
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataManager: MonoBehaviour
{
    void Awake(){
        DataLive dataLive = DataLive.Instance;
        
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Data saved");
        DataLive.Instance.UserResource.UpdateCurrentTime();
        DataLive.Instance.SaveData();
    }
}
