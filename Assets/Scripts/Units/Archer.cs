using System;
using System.Collections;

public class Archer : Unit
{
    public override ArrayList getMoveTypes()
    {
        return new ArrayList { MovementType.FOOT, MovementType.CLIMB };
    }

    // Use this for initialization
    void Start()
    {
        damage = 5;
        health = 10;
        damageType = DamageType.RANGED;
        unitName = "joe";
        movementDistance = 5;
    }
}
