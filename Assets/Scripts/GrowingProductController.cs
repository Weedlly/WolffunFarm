using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GrowingProductController : MonoBehaviour
{
    static public Product _productGrowing;

    public void SetProductGrowing(Product product){
        _productGrowing = product;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
