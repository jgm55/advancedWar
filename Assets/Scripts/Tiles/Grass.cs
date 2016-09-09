using System;
using System.Collections;
using UnityEngine;

public class Grass : Tile
{
    public override ArrayList getMovementTypes()
    {
        return new ArrayList { MovementType.AIR, MovementType.FOOT };
    }

    public override int movesTaken(ArrayList types)
    {
        if(types.Contains(MovementType.AIR) || types.Contains(MovementType.FOOT))
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
