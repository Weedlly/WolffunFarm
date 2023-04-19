using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserResourceController : MonoBehaviour
{
    public UserResource _userResource;
    public UserResourceView _userResourceView;

    void Start()
    {
      _userResource = DataController.LocalLoadXML<UserResource>("UserResource.xml");
      _userResourceView = GetComponent<UserResourceView>();
    }
    void Update()
    {
      _userResourceView.UpdateUserResource(_userResource);
    }
}
