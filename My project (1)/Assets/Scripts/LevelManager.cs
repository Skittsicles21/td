using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //A prefab for creating a single tile
    [SerializeField]
    private GameObject[] tilePrefabs;

    //calculates the tile width and returns the value as a float
    public float TileSize
    {
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

        string[] mapData = new string[] 
        {
            "0000", "1111", "0000", "0000"
        };

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < mapY; y++) //y position
        {
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapX; x++) //x position
            {
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);
            }
        }
    }

    private void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);

        //Creates a new tile and then makes a reference to that tile in the newTile variable
        GameObject newTile = Instantiate(tilePrefabs[tileIndex]);

        //Uses the newtile variable and the tile width to place a the next tile right next to the last
        newTile.transform.position = new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0);
    }
}













// UR CODE IS GAY 
// IAN SHUT THE HELL UP AND MAKE MORE COOL ANIMATIONS
// FINE BITCH