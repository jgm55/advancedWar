using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Unit : MonoBehaviour {
    public float health;
    public string unitName;
    public float damage;
    public DamageType damageType;
    public ArmorType armorType;
    public int movementDistance;
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
        if(selected)
        {
            
        }
	}

    public abstract ArrayList getMoveTypes();

    public bool isDead()
    {
        return health <= 0;
    }

    void OnMouseDown()
    {
        selected = true;
    }

    void OnMouseUp()
    {
        selected = false;
    }
}
