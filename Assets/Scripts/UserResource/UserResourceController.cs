using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserResourceController : MonoBehaviour
{
    public UserResource _userResource;
    public static UserResource UserResource = new UserResource();
    public UserResourceView _userResourceView;

    void Start()
    {
      _userResource = DataController.LocalLoadXML<UserResource>("UserResource.xml");
      DataController.LocalWriteXML<UserResource>("UserResource.xml",_userResource);
      _userResourceView = GetComponent<UserResourceView>();
    }
    void Update()
    {
      _userResource = UserResource;
      _userResourceView.UpdateUserResource(_userResource);
    }
}
