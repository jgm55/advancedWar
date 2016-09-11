using UnityEngine;
using System.IO;
using System;
using System.Text;
/**
 * Initializes a level based on the file sheet.
 * 
 * */
public class LevelManager : MonoBehaviour {
    public string levelName;

    public GameObject grassObj;
    public GameObject treeObj;
    public GameObject mountainObj;
    public GameObject waterObj;

    public GameObject[,] level;


    private Vector3 currentPos;
    private System.Random random;

    private static float TILE_SIZE_X;
    private static float TILE_SIZE_Y;
    public int LEVEL_SIZE_X;
    public int LEVEL_SIZE_Y; 
    private int x = 0;
    private int y = 0;

    private static string FILE_PATH;

    // Use this for initialization
    void Start() {
        FILE_PATH = Application.dataPath + "/Levels/";
        //Arbitrarily chosen to calculate size of tiles.
        //Assumes all tiles are same size
        TILE_SIZE_X = grassObj.GetComponent<Renderer>().bounds.size.x;
        TILE_SIZE_Y = grassObj.GetComponent<Renderer>().bounds.size.y;
        LEVEL_SIZE_X = 13;
        LEVEL_SIZE_Y = 11;
        currentPos = new Vector3(0, 0, 0);
        random = new System.Random();
        initMap(FILE_PATH + levelName.Replace(".txt", "") + ".txt");
    }

    public void initMap(string fileName)
    {
        try
        {
            //TODO Read in header
            level = new GameObject[LEVEL_SIZE_X, LEVEL_SIZE_Y];
            string line;
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            using (reader)
            {
                do
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        if (line.StartsWith("#"))
                        {
                            //Skip comments
                            continue;
                        }

                        foreach (char c in line)
                        {                            
                            initTile(c);
                            currentPos = new Vector3(currentPos.x + TILE_SIZE_X, currentPos.y);
                            x++;

                        }
                        x = 0;
                        y++;
                        currentPos = new Vector3(0, currentPos.y + TILE_SIZE_Y);
                    }
                }
                while (line != null);
            }
        } catch (IOException e)
        {
            Debug.Log(e.Message);
            return;
        }
    }

    private void initTile(char c)
    {
        if (c == 'g')
        {            
            level[x, y] = Instantiate(grassObj, currentPos, Quaternion.identity, this.gameObject.transform) as GameObject;
        }
        else if (c == 'w')
        {
            level[x, y] = Instantiate(waterObj, currentPos, Quaternion.identity, this.gameObject.transform) as GameObject;
        }
        else if (c == 't')
        {
            level[x, y] = Instantiate(treeObj, currentPos, Quaternion.identity, this.gameObject.transform) as GameObject;
        }
        else if (c == 'm')
        {
            level[x, y] = Instantiate(mountainObj, currentPos, Quaternion.identity, this.gameObject.transform) as GameObject;
        }
        else
        {
            throw new Exception("Error initializing tile with char: " + c + ". Did you forget to add it to the LevelManager?");
        }
        level[x, y].GetComponent<Transform>().position = currentPos;
        level[x, y].GetComponent<Tile>().x = x;
        level[x, y].GetComponent<Tile>().y = y;
    }
}
