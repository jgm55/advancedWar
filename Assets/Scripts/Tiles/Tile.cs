using UnityEngine;
using System.Collections;
using System;

public abstract class Tile : MonoBehaviour {
    public GameObject attackOverlay;
    public GameObject moveOverlay;
    private GameObject displayedOverlay;
    public int x, y;

    public Building building;
    public Unit unit;
    
    protected TileDisplayState state;

    public abstract ArrayList getMovementTypes();

    public abstract int movesTaken(ArrayList types);

    public abstract int visibilityTaken(ArrayList types);

    public void setState(TileDisplayState state)
    {
        this.state = state;
        Destroy(displayedOverlay);
        if (state == TileDisplayState.ATTACK)
        {
            displayedOverlay = Instantiate(attackOverlay, this.gameObject.transform) as GameObject;
        }
        if (state == TileDisplayState.MOVE)
        {
            displayedOverlay = Instantiate(moveOverlay, this.gameObject.transform) as GameObject;
        }
        if (state == TileDisplayState.NONE)
        {
            //No Op
        }
    }
}
