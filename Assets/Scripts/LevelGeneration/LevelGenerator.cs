using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{

    Grid grid; //Holder for the grid once generated
    public Vector2Int levelSize; //This is the size of the level

    //public TileBase floor;
    public TileBase wall; //The Default Outer Wall

    public float obstaclePadding;

    public LevelTheme levelTheme; //Level Theme Scriptable object where the data to generate the level is stored.

    Tilemap newMap;


    //What will this script do?
    //1. Make a Grid component at runtime for the level
    //2. Generate a level based on the inputed data
    // Ex. The tilesets are stored in some outside data (like a scriptableObject), which is then assigned by a LevelManager once the level is chosen
    // So if the player choses the "desert" level, the manager uses THAT tileset for the generator and then calls that data in
    // Start is called before the first frame update
    
    //This is the function that calls all the required functions to generate the map. This will take in the input data and pass it through to what needs it
    public void GenerateLevel()
    {
        GenerateGrid();
        PlaceInTiles();
        PlaceObstacles();
    }

    void GenerateGrid()
    {
        //Create a grid game object, naming it Grid
        var grid = new GameObject("Grid").AddComponent<Grid>();
        this.grid = grid;
        grid.transform.parent = transform;

        //Create an empty tilemap object that is a child of the grid
        var tilemap = new GameObject("Map").AddComponent<Tilemap>();
        tilemap.AddComponent<TilemapRenderer>();
        tilemap.transform.SetParent(grid.gameObject.transform);
        newMap = tilemap;

        TilemapCollider2D tilemapCollider = tilemap.AddComponent<TilemapCollider2D>();
        tilemapCollider.usedByComposite = true;
        Rigidbody2D tilemapRB = tilemap.AddComponent<Rigidbody2D>();
        tilemapRB.isKinematic = true;
        tilemap.AddComponent<CompositeCollider2D>();

    }
    void PlaceInTiles()
    {
        //Generate an array of positions based on the size of the level
        Vector3Int[] positions = new Vector3Int[levelSize.x * levelSize.y];
        //Make an array of tiles based on the amount of possible positions
        TileBase[] tileArray = new TileBase[positions.Length];

        for(int i = 0; i < positions.Length; i++)
        {
            //Fill in the position in the array
            positions[i] = new Vector3Int(i % levelSize.x, i / levelSize.y, 0);
            Debug.Log(positions[i]);
            //The tile to be placed in the array
            //The wall tiles are placed when the X or Y position value is 0 OR the levelSize value
            //If the remainder of the X position is 0 (which happens when X is either 0 or 1 less than the size of the grid in that direction), place a wall. Else, place a floor tile
            tileArray[i] = positions[i].x % (levelSize.x-1) == 0 || positions[i].y % (levelSize.y-1) == 0 ? wall : levelTheme.baseFloorTile;

            //tileArray[i] = floor;
            
        }
        newMap.SetTiles(positions, tileArray);

    }
    void PlaceObstacles()
    {
        Transform obstacleHolder = new GameObject("Obstacles").transform;
        obstacleHolder.parent = gameObject.transform;

        float obstacleDensity = levelTheme.obstacleDensity / 10 * ((levelSize.x + levelSize.y) / 2);
        int obstacleCount = (int)Random.Range(obstacleDensity - levelTheme.obstacleDensityVariance, obstacleDensity + levelTheme.obstacleDensityVariance);
        Debug.Log(obstacleCount);
        for (int i = 0; i < obstacleCount; i++)
        {
            int chosenPrefab = Random.Range(0, levelTheme.obstacles.Length);
            Vector2 placePosition = new Vector2(Random.Range(obstaclePadding, levelSize.x-obstaclePadding), Random.Range(obstaclePadding, levelSize.y-obstaclePadding) );
            GameObject thisObject = Instantiate(levelTheme.obstacles[chosenPrefab], placePosition, levelTheme.obstacles[chosenPrefab].transform.rotation);
            thisObject.transform.parent = obstacleHolder;

        }
    }

}
