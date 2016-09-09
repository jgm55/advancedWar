using UnityEngine;
using System.Collections;
using System;

public class Tree : Tile
{
    public override ArrayList getMovementTypes()
    {
        return new ArrayList{ MovementType.FOOT, MovementType.AIR };
    }

    public override int movesTaken(ArrayList types)
    {
        if(types.Contains(MovementType.AIR))
        {
            return 1;
        }

        if (types.Contains(MovementType.FOOT))
        {
            return 2;
        }
        return 0;
    }

    public override int visibilityTaken(ArrayList types)
    {
        throw new NotImplementedException();
    }
}
