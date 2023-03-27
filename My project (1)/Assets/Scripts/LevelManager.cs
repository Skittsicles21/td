using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //A prefab for creating a single tile
    [SerializeField]
    private GameObject tile;

    //calculates the tile width and returns the value as a float
    public float TileSize
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
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

        for (int y = 0; y < 5; y++) //y position
        {
            for (int x = 0; x < 5; x++) //x position
            {
                PlaceTile(x, y);
            }
        }
    }

    private void PlaceTile(int x, int y)
    {
        //Creates a new tile and then makes a reference to that tile in the newTile variable
        GameObject newTile = Instantiate(tile);

        //Uses the newtile variable and the tile width to place a the next tile right next to the last
        newTile.transform.position = new Vector3(TileSize * x, TileSize * y, 0);
    }
}













// UR CODE IS GAY 