using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserResourceView : MonoBehaviour
{
    ///<sumary>
    ///  Update the UI elements that display the user's resources in a game. 
    ///</sumary>
    [SerializeField] private TMP_Text _coinValueText;
    [SerializeField] private TMP_Text _equitmentLevelValueText;
    [SerializeField] private TMP_Text _workerValueText;
    [SerializeField] private TMP_Text _landValueText;
    [SerializeField] private List<TMP_Text> _productNameText;
    [SerializeField] private List<TMP_Text> _productValuesText;

    public void UpdateUserResource(UserResource userResource)
    {
        _coinValueText.text = userResource.Coin.ToString();
        _equitmentLevelValueText.text = userResource.Equipment.Level.ToString();
        _workerValueText.text = (userResource.NumWorkers - userResource.NumIdleWorkers).ToString() + "/" + userResource.NumIdleWorkers.ToString();
        _landValueText.text = (userResource.Farmland.NumLands - userResource.NumIdleLands).ToString() + "/" + userResource.NumIdleLands.ToString();

        List<WareHouse.Bin> bins = userResource.UserWareHouse.ProductBins;
        if (bins.Count == _productValuesText.Count)
        {
            for (int i = 0; i < bins.Count; i++)
            {
                _productValuesText[i].text = bins[i].NumProductHarvested.ToString();
            }
        }
    }


}
