using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LandView: MonoBehaviour
{
    ///<sumary>
   
    ///</sumary>
    [SerializeField] private TMP_Text _productTitle;
    [SerializeField] private TMP_Text _nextStatusTimeText;  
    [SerializeField] private TMP_Text _numberHarvestedText; 
    public Button _userActionBt;
    public void UpdateLandView(Land land)
    {
        if(land.GrowingProduct != null){

            _productTitle.text = land.GrowingProduct.Name;
            if(land.NextStatusTime < 0){
                _nextStatusTimeText.text =((int)land.NextStatusTime).ToString() +" "+ LandStatusType.WorkerDoing;
            }
            else{
                _nextStatusTimeText.text = ((int)land.NextStatusTime).ToString() + " " + land.LandStatus;
            }
            _numberHarvestedText.gameObject.SetActive(true);
            _numberHarvestedText.text = "X" + land.NumberHarvested.ToString();
        }else{
            _productTitle.text = "None";
            _numberHarvestedText.gameObject.SetActive(false);
            _nextStatusTimeText.text = LandStatusType.Idle.ToString();
        }
    }
}
