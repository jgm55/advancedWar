using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject selected;
    LevelManager levelManager;
    private MoveDisplayController moveDisplayController;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            throw new Exception("OMG! LEVEL MANAGER CANNOT BE FOUND!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSelected(GameObject selected)
    {
        Debug.Log(selected);
        this.selected = selected;
        Unit unit = selected.GetComponent<Unit>();
        if (unit != null)
        {
            Debug.Log("unit selcted");

        }
    }

    public List<Tile> getMovementSquares(Unit unit, Tile startTile)
    {
        List<Tile> movementSquares = new List<Tile>();
        HashSet<Tile> checkedTiles = new HashSet<Tile>();
        List<Tile> tilesToCheck = getSurroundingTiles(startTile.x, startTile.y);
        int moves = unit.movementDistance;
        while(tilesToCheck.Count > 0)
        {
            Tile tile = tilesToCheck[0];
            tilesToCheck.Remove(tile);
            if (checkedTiles.Contains(tile))
            {
                continue;
            }
            checkedTiles.Add(tile);
            int movesRemaining = moves;
            movesRemaining -= tile.movesTaken(unit.getMoveTypes());
            if(movesRemaining > 0)
            {
                movementSquares.Add(tile);
                tilesToCheck.AddRange(getSurroundingTiles(tile.x, tile.y));
            }
        }

        return movementSquares;
    }

    internal void setUnitSelected()
    {
        throw new NotImplementedException();
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
        float damage = calculateTypeDamage(attacker, defender, Constants.DAMAGE_MULTIPLIER_ATTACK);
        defender.health -= damage;
        if (!defender.isDead())
        {
            attacker.health -= calculateTypeDamage(defender, attacker, Constants.DAMAGE_MULTIPLIER_DEFENSE);
        }
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

    //Calculates the damage unit Attacker does to Unit defender
    private static float calculateTypeDamage(Unit attacker, Unit defender, float damageMultiplier)
    {
        float calculatedDamage = attacker.damage;
        if (attacker.damageType == DamageType.BLADE)
        {
            if (defender.damageType == DamageType.BLUNT)
            {
                calculatedDamage = attacker.damage * (1 + damageMultiplier);
            }
            else if (defender.damageType == DamageType.STAB)
            {
                calculatedDamage = attacker.damage * (1 - damageMultiplier);
            }
        }
        else if (attacker.damageType == DamageType.BLUNT)
        {
            if (defender.damageType == DamageType.STAB)
            {
                calculatedDamage = attacker.damage * (1 + damageMultiplier);
            }
            else if (defender.damageType == DamageType.BLADE)
            {
                calculatedDamage = attacker.damage * (1 - damageMultiplier);
            }
        }
        else if (attacker.damageType == DamageType.STAB)
        {
            if (defender.damageType == DamageType.BLADE)
            {
                calculatedDamage = attacker.damage * (1 + damageMultiplier);
            }
            else if (defender.damageType == DamageType.BLUNT)
            {
                calculatedDamage = attacker.damage * (1 - damageMultiplier);
            }
        }
        return calculatedDamage;
    }

    private List<Tile> getSurroundingTiles(int x, int y)
    {
        List<Tile> tiles = new List<Tile>();

        if (x - 1 >= 0)
        {
            tiles.Add(levelManager.level[x - 1, y].GetComponent<Tile>());
        }
        if (x + 1 < levelManager.LEVEL_SIZE_X)
        {
            tiles.Add(levelManager.level[x + 1, y].GetComponent<Tile>());
        }
        if (y - 1 >= 0)
        {
            tiles.Add(levelManager.level[x, y - 1].GetComponent<Tile>());
        }
        if (y + 1 < levelManager.LEVEL_SIZE_Y)
        {
            tiles.Add(levelManager.level[x, y + 1].GetComponent<Tile>());
        }

        return tiles;
    }
}
