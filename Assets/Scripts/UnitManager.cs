using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour
{
    private List<Unit> units;

    void Update()
    {
        units = new List<Unit>(FindObjectsOfType<Unit>());
    }

}