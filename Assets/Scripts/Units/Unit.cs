using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Unit : MonoBehaviour {
    //blade > Blunt > stab > blade
    public enum DamageType {RANGED, BLADE, BLUNT, STAB };
    static float damageMultiplier = .33f;

    protected float health;
    protected string unitName;
    protected float damage;
    protected DamageType damageType;
    protected int movementDistance;
    private bool selected = false;

    public Unit()
    {

    }

	// Update is called once per frame
	void Update () {
	    if(isDead())
        {
            //TODO: play death animation and sound
            Destroy(this.gameObject);
        }
	}

    // Other Unit deals damage to this Unit.
    protected void Fight(Unit other)
    {
        float calculatedDamage = calculateTypeDamage(other, this);
        health -= calculatedDamage;
        Retaliate(other);
    }

    //This Unit deals damage to other Unit.
    protected void Retaliate(Unit other)
    {
        if(!isDead())
        {
            other.health -= calculateTypeDamage(this, other);
        }
    }

    protected bool isDead()
    {
        return health <= 0;
    }

    public List<Vector2> getMovementSquares()
    {
        List<Vector2> movementSquares = new List<Vector2>();

        return movementSquares;
    }

    void OnMouseDown()
    {
        selected = true;
    }

    void OnMouseUp()
    {
        selected = false;
    }

    //Calculates the damage unit Attacker does to Unit defender
    private static float calculateTypeDamage(Unit attacker, Unit defender)
    {
        float calculatedDamage = attacker.damage;
        if (attacker.damageType == DamageType.BLADE)
        {
            if (defender.damageType == DamageType.BLUNT)
            {
                calculatedDamage = attacker.damage * (1 + damageMultiplier);
            }
            else if (defender.damageType == DamageType.STAB)
            {
                calculatedDamage = attacker.damage * (1 - damageMultiplier);
            }
        }
        else if (attacker.damageType == DamageType.BLUNT)
        {
            if (defender.damageType == DamageType.STAB)
            {
                calculatedDamage = attacker.damage * (1 + damageMultiplier);
            }
            else if (defender.damageType == DamageType.BLADE)
            {
                calculatedDamage = attacker.damage * (1 - damageMultiplier);
            }
        }
        else if (attacker.damageType == DamageType.STAB)
        {
            if (defender.damageType == DamageType.BLADE)
            {
                calculatedDamage = attacker.damage * (1 + damageMultiplier);
            }
            else if (defender.damageType == DamageType.BLUNT)
            {
                calculatedDamage = attacker.damage * (1 - damageMultiplier);
            }
        }
        return calculatedDamage;
    }
}
