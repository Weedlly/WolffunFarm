using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinGameController : MonoBehaviour
{
    ///<sumary>
    ///  Checking whether the user has won the game
    ///  , and if so, to display the win message and stop the game
    ///</sumary>
    public TMP_Text _title;
    void Update()
    {
        if (DataLive.Instance.UserResource.IsWinTheGame())
        {
            _title.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
