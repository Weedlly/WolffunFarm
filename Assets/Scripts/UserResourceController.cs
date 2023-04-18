using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserResourceController : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinValueText;
    [SerializeField] private TMP_Text _equitmentLevelValueText;
    [SerializeField] private TMP_Text _workerValueText;
    [SerializeField] private TMP_Text _landValueText;
    [SerializeField] private TMP_Text _tomatoValueText;
    [SerializeField] private TMP_Text _blueberryValueText;
    [SerializeField] private TMP_Text _milkValueText;
    [SerializeField] private TMP_Text _strawberryValueText;
    public static int Coin{
        get{return Coin; }
    }
    public static int EquipmenLevel{
        get{return EquipmenLevel; }
    }
    public static int Worker{
        get{return Worker; }
    }
    public static int Land{
        get{return Land; }
    }
    public static int Tomato{
        set{
            Tomato = value;
        }
        get{return Tomato; }
    }
    public static int Blueberry{
        get{return Blueberry; }
    }
    public static int Milk{
        get{return Milk;}
    }
    public static int Strawberry{
        get{return Strawberry; }
    }

    bool IsEnoughCoint(int coin){
        if(Coin - coin > 0){
            return true;
        }
        return false;
    }
    
    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
