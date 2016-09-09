public class Archer : Unit
{
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
