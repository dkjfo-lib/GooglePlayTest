using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictGrid : MonoBehaviour
{
    public int gridSize = 5;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        var districtPrefab = GameHolder.PrefabsManager.prefabs.GetObject<Lot>("District");
        for (int x = -gridSize; x < gridSize + 1; x++)
        {
            for (int y = -gridSize; y < gridSize + 1; y++)
            {
                var style = new DistrictStyle
                {
                    districtType = DistrictType.city,
                    terrainType = TerrainType.flat,
                };

                var newDistrict = Instantiate(districtPrefab);
                newDistrict.gridPosition = new Vector2Int(x, y);
                newDistrict.transform.position = new Vector3(x, 0, y);
                newDistrict.style = style;
                newDistrict.gameObject.name = "tile " + x + ":" + y;
                newDistrict.transform.parent = transform;
            }
        }
    }
}
