using UnityEngine;
using System.Collections;
using System;

public class Unit : MonoBehaviour {
    //blade > Blunt > stab > blade
    enum DamageType {RANGED, BLADE, BLUNT, STAB };
    static float damageMultiplier = .33f;

    float health;
    string unitName;
    int damage;
    DamageType damageType;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
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
