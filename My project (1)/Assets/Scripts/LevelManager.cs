using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    //A prefab for creating a single tile
    [SerializeField]
    private GameObject[] tilePrefabs;

    public Dictionary<Point, TileScript> Tiles {get; set;}

    //calculates the tile width and returns the value as a float
    public float TileSize
    {
        //
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Activates the create level function
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Creates the level
    private void CreateLevel() 
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < mapY; y++) //y position
        {
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapX; x++) //x position
            {
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);
            }
        }

        maxTile = Tiles[new Point(mapX-1, mapY-1)].transform.position;
    }

    private void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);

        //Creates a new tile and then makes a reference to that tile in the newTile variable
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

        //Uses the newtile variable and the tile width to place a the next tile right next to the last
        newTile.Setup(new Point(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0));

        Tiles.Add(new Point(x,y), newTile);
    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;

        string data = bindData.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');
    }
}











// UR CODE IS GAY 
// IAN SHUT THE HELL UP AND MAKE MORE COOL ANIMATIONS
// FINE BITCH