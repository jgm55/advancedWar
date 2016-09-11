using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;

namespace Assets.Scripts
{
    class InputHelper
    {
        //Returns null if no type
        public static GameObject getObjectInLayerAtPoint(MapLayer layer, Vector3 position)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);
            foreach (RaycastHit2D hit in hits)
            {
                if(MapLayer.ANY == layer)
                {
                    return hit.collider.gameObject;
                }
                else if (layer == MapLayer.TILE)
                {
                    if(hit.collider.gameObject.GetComponent<Tile>() != null)
                    {
                        return hit.collider.gameObject;
                    }
                }
                else if (layer == MapLayer.BUILDING)
                {
                    if(hit.collider.gameObject.GetComponent<Building>() != null)
                    {
                        return hit.collider.gameObject;
                    }
                }
                else if (layer == MapLayer.UNIT)
                {
                    if(hit.collider.gameObject.GetComponent<Unit>() != null)
                    {
                        return hit.collider.gameObject;
                    }
                }
            }

            return null;
        }
    }
}
