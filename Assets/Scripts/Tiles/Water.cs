using System;
using System.Collections;
using UnityEngine;

public class Water : Tile
{
    public override ArrayList getMovementTypes()
    {
        return new ArrayList { MovementType.AIR, MovementType.SWIM };
    }

    public override int movesTaken(ArrayList types)
    {
        if(types.Contains(MovementType.AIR))
        {
            return 1;
        } else if(types.Contains(MovementType.SWIM))
        {
            return 1;
        }
        return 100;
    }

    public override int visibilityTaken(ArrayList types)
    {
        return 1;
    }
}
