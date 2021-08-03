using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject inventoryCanvas;
    public GameObject inventory;
    public GameObject itemButtonPrefab;

    public List<GameObject> items;

    public Vector3 SpawnPosition;

    public List<Seed> seeds;

    public int money;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateInventory()
    {
        foreach(var _seed in seeds)
        {
            if (_seed.SeedRate > 0)
            {
                var _item = Instantiate(itemButtonPrefab, inventory.transform);
                _item.GetComponent<Image>().sprite = _seed.SeedIcon;
                _item.GetComponentInChildren<Text>(true).text = _seed.SeedRate.ToString();
                var x = items.Count % 10;
                var y = items.Count / 10;
                _item.GetComponent<RectTransform>().anchoredPosition = new Vector2(x * 100, y * -100);
                items.Add(_item);
            }

            if (_seed.HarvestRate > 0)
            {
                var _item = Instantiate(itemButtonPrefab, inventory.transform);
                _item.GetComponent<Image>().sprite = _seed.HarvestIcon;
                _item.GetComponentInChildren<Text>(true).text = _seed.HarvestRate.ToString();
                var x = items.Count % 10;
                var y = items.Count / 10;
                _item.GetComponent<RectTransform>().anchoredPosition = new Vector2(x * 100, y * -100);
                items.Add(_item);
            }
        }
    }

    private void ClearInventory()
    {
        items.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryCanvas.SetActive(true);
        }
    }

    public void AddHarvest(Seed seed)
    {
        foreach (var _seed in seeds)
        {
            if (_seed.Name == seed.Name)
            {
                _seed.HarvestRate += seed.HarvestRate;
                return;
            }
        }

        seeds.Add(seed);
    }

    public void AddSeed(Seed seed)
    {
        foreach (var _seed in seeds)
        {
            if (_seed.Name == seed.Name)
            {
                _seed.SeedRate += seed.SeedRate;
                return;
            }
        }

        seeds.Add(seed);
    }
}

[Serializable]
public class Seed
{
    public string Name;
    public int HarvestRate;
    public int HarvestPrice;
    public Sprite HarvestIcon;
    public int SeedRate;
    public Sprite SeedIcon;
}

