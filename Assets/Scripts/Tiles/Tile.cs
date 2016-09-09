using UnityEngine;
using System.Collections;

public abstract class Tile : MonoBehaviour{

    public int x, y;

    public Building building;
    public Unit unit;

    public abstract ArrayList getMovementTypes();

    public abstract int movesTaken(ArrayList types);

    public abstract int visibilityTaken(ArrayList types);

}
