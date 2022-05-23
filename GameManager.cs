using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;
    public Text goldDispley;
    private Building buildingToPlace;
    public GameObject grid;
    public CustomCursor cursor;
    public Tile[] tiles;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    { 

        goldDispley.text = gold.ToString();
        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            foreach (Tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, cam.ScreenToWorldPoint(Input.mousePosition));
                if (dist < nearestDistance)
                {
                    nearestDistance = dist;
                    nearestTile = tile;
                }
            }
            if (nearestTile.isOccupied == false && nearestDistance < 1)
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);
                buildingToPlace = null;
                nearestTile.isOccupied = true;
                grid.SetActive(false);
                cursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    } 
    public void BuyBuilding(Building building)
    {
        if (gold >= building.cost)
        {
            cursor.gameObject.SetActive(true);
            cursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;
            gold -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }
}
