using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject shopUI;
    public Text goldText;
    public Text buyText;
    public Text sellText;

    public GameObject itemPrefab;
    public Transform itemParent;
    public List<GameObject> sellItems;

    private int buyPrice = 0;
    private int sellPrice = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
        InitializeSellItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        goldText.text = GameManager.Instance.money.ToString();
        buyText.text = buyPrice.ToString();
        sellText.text = sellPrice.ToString();
    }

    public void OnSelectBuyItemClick(int _price)
    {
        buyPrice += _price;
        UpdateUI();
    }

    public void OnSelectSellItemClick(int _price)
    {
        sellPrice += _price;
        UpdateUI();
    }

    public void OnBuyButtonClick()
    {
        GameManager.Instance.money -= buyPrice;
        buyPrice = 0;
        UpdateUI();
    }

    public void OnSellButtonClick()
    {
        GameManager.Instance.money += sellPrice;
        sellPrice = 0;
        UpdateUI();
    }

    public void InitializeSellItems()
    {
        sellItems.Clear();
        foreach (var seed in GameManager.Instance.seeds)
        {
            var item = Instantiate(itemPrefab, itemParent);
            item.GetComponent<Image>().sprite = seed.HarvestIcon;
            item.GetComponent<Price>().price = seed.HarvestPrice;
        }
    }
}
