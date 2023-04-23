using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataLive : Singleton<DataLive>
{
    ///<sumary>
    /// Manage the user resource data using singleton and handle loading and saving of the data.
    ///</sumary>
    const string USER_RESOURCE_FILE_NAME = "UserResource.xml";
    private UserResource _userResource;
    public UserResource UserResource
    {
        set
        {
            _userResource = value;
        }
        get
        {
            if (_userResource == null)
            {
                LoadData();
            }
            return _userResource;
        }
    }
    void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/" + USER_RESOURCE_FILE_NAME))
        {
            _userResource = DataController.LocalLoadXML<UserResource>(USER_RESOURCE_FILE_NAME);
            Debug.Log("Old user");
        }
        else
        {
            CreateNewUserResourceFile();
            Debug.Log("New user");
        }
    }
    public void SaveData()
    {
        DataController.LocalWriteXML<UserResource>(USER_RESOURCE_FILE_NAME, _userResource);
    }

    void CreateNewUserResourceFile()
    {
        _userResource = DataController.LoadFromResourceXML<UserResource>("Data/UserResource");
        DataController.LocalWriteXML<UserResource>(USER_RESOURCE_FILE_NAME, _userResource);
    }
}
