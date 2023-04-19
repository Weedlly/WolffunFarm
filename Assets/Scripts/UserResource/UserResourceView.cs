using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserResourceView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinValueText;
    [SerializeField] private TMP_Text _equitmentLevelValueText;
    [SerializeField] private TMP_Text _workerValueText;
    [SerializeField] private TMP_Text _landValueText;
    [SerializeField] private TMP_Text _tomatoValueText;
    [SerializeField] private TMP_Text _blueberryValueText;
    [SerializeField] private TMP_Text _milkValueText;
    [SerializeField] private TMP_Text _strawberryValueText;

    public void UpdateUserResource(UserResource userResource){
        _coinValueText.text = userResource.Coin.ToString();
        _equitmentLevelValueText.text = userResource.EquipmenLevel.ToString();
        _workerValueText.text = userResource.Worker.ToString();
        _landValueText.text = userResource.Land.ToString();
        _tomatoValueText.text = userResource.TomatoFruit.ToString();
        _blueberryValueText.text = userResource.BlueberryFruit.ToString();
        _milkValueText.text = userResource.CowMilk.ToString();
        _strawberryValueText.text = userResource.StrawberryFruit.ToString();

    }
}
