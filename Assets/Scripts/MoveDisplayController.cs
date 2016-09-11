using UnityEngine;
using System.Collections.Generic;
using System;

public class MoveDisplayController : MonoBehaviour
{

    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public bool displayMovesFor(Unit unit, Tile startTile)
    {
        List<Tile> tiles = gameManager.getMovementSquares(unit, startTile);
        setMoveState(tiles, TileDisplayState.MOVE);

        return true;
    }

    public bool hideMovesFor(Unit unit, Tile startTile)
    {

        return true;
    }

    private void setMoveState(List<Tile> tiles, TileDisplayState moveState)
    {
        foreach (Tile tile in tiles)
        {
            tile.setState(moveState);
        }
    }
}