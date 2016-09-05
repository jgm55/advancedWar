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

    public Sprite[] grass;
    public Sprite[] mountain;
    public Sprite[] water;

    public GameObject grassObj;
    public GameObject mountainObj;
    public GameObject waterObj;

    private GameObject[][] level;

    private Vector3 currentPos;
    private System.Random random;

    private static float TILE_SIZE_X;
    private static float TILE_SIZE_Y;

    private int LEVEL_SIZE_X = 10;
    private int LEVEL_SIZE_Y = 10;
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

        currentPos = new Vector3(0, 0, 0);
        random = new System.Random();
        level = new GameObject[LEVEL_SIZE_X][];
        initMap(FILE_PATH + levelName.Replace(".txt", "") + ".txt");
    }

    // Update is called once per frame
    void Update() {

    }

    public void initMap(string fileName)
    {
        try
        {
            string line;
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            using (reader)
            {
                do
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        level[x] = new GameObject[LEVEL_SIZE_Y];
                        foreach (char c in line)
                        {                            
                            initTile(c);
                            currentPos = new Vector3(currentPos.x + TILE_SIZE_X, currentPos.y);

                        }
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
            level[x][y] = Instantiate(grassObj, currentPos, Quaternion.identity, this.gameObject.transform) as GameObject;
            level[x][y].GetComponent<SpriteRenderer>().sprite = grass[random.Next(0, grass.Length - 1)];
        }
        else if (c == 'w')
        {
            level[x][y] = Instantiate(waterObj, currentPos, Quaternion.identity, this.gameObject.transform) as GameObject;
            level[x][y].GetComponent<SpriteRenderer>().sprite = water[random.Next(0, water.Length - 1)];
        }
        else
        {
            throw new Exception("Error initializing tile with char: " + c);
        }
        level[x][y].GetComponent<Transform>().position = currentPos;
    }
}
