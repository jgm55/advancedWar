using System;
using System.Collections;
using UnityEngine;

public class Mountain : Tile
{
    public override ArrayList getMovementTypes()
    {
        return new ArrayList { MovementType.AIR, MovementType.CLIMB };
    }

    public override int movesTaken(ArrayList types)
    {
        if (types.Contains(MovementType.CLIMB))
        {
            return 3;
        }
        if (types.Contains(MovementType.AIR))
        {
            return 1;
        }
        return 100;
    }

    public override int visibilityTaken(ArrayList types)
    {
        if (types.Contains(VisibilityType.HIGH))
        {
            return 1;
        }
        if (types.Contains(VisibilityType.MED))
        {
            return 2;
        }
        return 100;
    }
}
