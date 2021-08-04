using System;
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
    private string buyName, sellName;
    private Sprite buySprite;

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

    public void OnSelectBuyItemClick(int _price, string _name, Sprite _icon)
    {
        buyPrice += _price;
        buyName = _name;
        buySprite = _icon;
        UpdateUI();
    }

    public void OnSelectSellItemClick(int _price, string _name)
    {

        sellPrice += _price;
        sellName = _name;
        UpdateUI();
    }

    public void OnBuyButtonClick()
    {
        GameManager.Instance.money -= buyPrice;
        
        Seed newSeed = new Seed();
        newSeed.SeedRate = 1;
        newSeed.SeedIcon = buySprite;
        newSeed.Name = buyName;
        GameManager.Instance.AddSeed(newSeed);
        buyPrice = 0;
        UpdateUI();
        InitializeSellItems();
    }

    public void OnSellButtonClick()
    {
        GameManager.Instance.money += sellPrice;
        
        Seed sellHarvest = new Seed();
        sellHarvest.HarvestRate = -1;
        sellHarvest.Name = sellName;
        GameManager.Instance.AddHarvest(sellHarvest);
        sellPrice = 0;
        UpdateUI();
        InitializeSellItems();
    }

    public void InitializeSellItems()
    {
        ClearItems();
        
        int itemCount = 0;
        foreach (var seed in GameManager.Instance.seeds)
        {
            if (seed.HarvestRate > 0)
            {
                var item = Instantiate(itemPrefab, itemParent);
                item.GetComponent<Image>().sprite = seed.HarvestIcon;
                item.GetComponent<Price>().price = seed.HarvestPrice;
                item.GetComponent<Price>().name = seed.Name;
                var _pos = SellItemPos(itemCount);
                item.GetComponent<RectTransform>().anchoredPosition = _pos;
                sellItems.Add(item);
                itemCount++;
            }

            if (seed.SeedRate > 0)
            {
                var item = Instantiate(itemPrefab, itemParent);
                item.GetComponent<Image>().sprite = seed.SeedIcon;
                item.GetComponent<Price>().name = seed.Name;
                var _pos = SellItemPos(itemCount);
                item.GetComponent<RectTransform>().anchoredPosition = _pos;
                sellItems.Add(item);
                itemCount++;
            }
        }
    }

    private void ClearItems()
    {
        foreach (var item in sellItems)
        {
            Destroy(item);
        }
        sellItems.Clear();
    }

    Vector2 SellItemPos(int itemCount)
    {
        int x = itemCount % 4;
        int y = itemCount / 4;

        return new Vector2(x * 125, y * -130);
    }
}
