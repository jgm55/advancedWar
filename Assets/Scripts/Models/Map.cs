using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    class Map
    {
        //Layer is units / buildings / tiles
        public Unit[][] units;
        public Building[][] buildings;
        public Tile[][] tiles;

        public Map(int size_x, int size_y)
        {
            units = new Unit[size_x][];
            //todo revisit this...for(int i)
        }

        public GameObject getThingAt(int x, int y)
        {
            if(units[x][y] != null)
            {
                return units[x][y].gameObject;
            } else if(buildings[x][y] != null)
            {
                return buildings[x][y].gameObject;
            }
            return tiles[x][y].gameObject;
        }
    }
}
