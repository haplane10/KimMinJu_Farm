using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Price : MonoBehaviour
{
    public int price;
    public new string name;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectBuyButtonClick()
    {
        FindObjectOfType<ShopController>().OnSelectBuyItemClick(price, name, GetComponent<Image>().sprite);
    }

    public void OnSelectSellButtonClick()
    {
        FindObjectOfType<ShopController>().OnSelectSellItemClick(price, name);
    }
}
