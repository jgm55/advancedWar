using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private GameObject selected;
    

    // Update is called once per frame
    void Update()
    {

    }

    /**
     * Functions that modify the game state.
     * */
    public bool MoveUnit(Unit unit, Tile tile)
    {
        return true;
    }

    public bool FightUnit(Unit attacker, Unit defender)
    {
        return true;
    }

    public bool BuildBuilding(Building building, Tile tile)
    {
        List<Tile> surroundingTiles = getSurroundingTiles(tile.x, tile.y);
        foreach (Tile surroundingTile in surroundingTiles) {
            if (building.needTypes().Contains(surroundingTile.GetType()) || building.needTypes().Contains(TileType.ANY))
            {
                tile.building = building;
                return true;
            }
        }
        return false;
    }

    private List<Tile> getSurroundingTiles(int x, int y)
    {
        List<Tile> tiles = new List<Tile>();


        return tiles;
    }
}
