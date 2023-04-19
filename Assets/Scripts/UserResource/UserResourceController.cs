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
       UserResource = new UserResource();
       _userResourceView = GetComponent<UserResourceView>();
    }
    void Update()
    {
      _userResource = UserResource;
      _userResourceView.UpdateUserResource(_userResource);
    }
}
