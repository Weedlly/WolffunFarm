using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataLive : Singleton<DataLive>
{
    private UserResource _userResource;
    public UserResource UserResource{
        set{
            _userResource = value;
        }get{
            if(_userResource == null){
                LoadData();
            }
            return _userResource;
        }
    }
    void LoadData(){
        if (File.Exists(Application.persistentDataPath + "/" + "UserResource.xml")){
            _userResource = DataController.LocalLoadXML<UserResource>("UserResource.xml");
            Debug.Log("Old user");
        }
        else {
            CreateNewUserResourceFile();
            Debug.Log("New user");
        }
    }
    public void SaveData(){
        DataController.LocalWriteXML<UserResource>("UserResource.xml",_userResource);
    }

    void CreateNewUserResourceFile(){
        _userResource = DataController.LoadFromResourceXML<UserResource>("Data/UserResource");
        DataController.LocalWriteXML<UserResource>("UserResource.xml",_userResource);
    }
}
