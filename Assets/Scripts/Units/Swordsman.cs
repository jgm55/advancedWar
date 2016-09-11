using System.Collections;

public class Swordsman : Unit
{
    // Use this for initialization
    void Start()
    {
        damage = 5;
        health = 10;
        damageType = DamageType.BLADE;
        unitName = "joe";
        movementDistance = 5;
    }

    public override ArrayList getMoveTypes()
    {
        return new ArrayList { MovementType.FOOT, MovementType.CLIMB, MovementType.SWIM };
    }
}
