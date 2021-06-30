using UnityEngine;
using UnityEngine.Tilemaps;

public class Farming : MonoBehaviour
{
    public Tile FarmingTile;
    public Tilemap FarmTileMap;
    public SeedScriptableObject seed;

    public void SetDigTile(Vector2 playerPosition)
    {
        Vector3Int gridPosition = FarmTileMap.WorldToCell(playerPosition);
        FarmTileMap.SetTile(gridPosition, FarmingTile);
    }

    public void SetSeedTile(Vector2 playerPosition)
    {
        Vector3Int gridPosition = FarmTileMap.WorldToCell(playerPosition);
        var tile = FarmTileMap.GetTile(gridPosition);

        if (tile == FarmingTile)
        {
            Debug.Log("씨를 뿌리자");
            var newPlant = Instantiate(seed.SeedPrefab);
            var gp = newPlant.GetComponent<GrowPlant>();
            gp.GrowTime = seed.GrowTime;
            gp.Seed.Name = seed.Name;
            gp.Seed.SeedIcon = seed.SeedIcon;
            gp.Seed.HarvestIcon = seed.HarvectIcon;
            gp.Seed.HarvestRate = seed.HarvestRate;

            newPlant.transform.position = new Vector2(gridPosition.x + 0.5f, gridPosition.y + 0.5f);
            //newFire.StartBurning(tilePosition, data, this);
        }
        else
        {
            Debug.Log("밭을 갈아야해!!");
        }
    }
}