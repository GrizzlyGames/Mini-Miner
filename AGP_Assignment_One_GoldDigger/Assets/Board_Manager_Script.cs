using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_Manager_Script : MonoBehaviour
{
    public static Board_Manager_Script instance;

    void Awake()
    {
        instance = this;
    }

    public int gridWidth = 16;
    public int gridHeight = 16;
    public GameObject prefab;

    public GameObject[,] tile;

    public void GenerateBoard()
    {
        tile = new GameObject[gridHeight, gridWidth];

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                int index = x + y * gridWidth;
                GameObject go = GameObject.Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                tile[x, y] = go;
                go.transform.parent = GameObject.Find("Tile_Container").transform;
            }
        }
        GameObject.Find("Tile_Container").transform.position = new Vector3(-7.5f, -7.5f, 0);
        GenerateResources();
    }

    private void GenerateResources()
    {
        int rndNum = Random.Range(6, 9);

        int x;
        int y;
        
        for (int m = 0; m < rndNum; m++)
        {
            x = Random.Range(3, 14);
            y = Random.Range(3, 14);

            tile[x, y].GetComponent<TileResource_Script>().tileValue = 1000;        // pt val 1000

            tile[x + 1, y].GetComponent<TileResource_Script>().tileValue = 500;        // pt val 500
            tile[x - 1, y].GetComponent<TileResource_Script>().tileValue = 500;        // pt val 500
            tile[x, y + 1].GetComponent<TileResource_Script>().tileValue = 500;        // pt val 500
            tile[x, y - 1].GetComponent<TileResource_Script>().tileValue = 500;        // pt val 500
            tile[x + 1, y + 1].GetComponent<TileResource_Script>().tileValue = 500;        // pt val 500
            tile[x - 1, y + 1].GetComponent<TileResource_Script>().tileValue = 500;        // pt val 500
            tile[x + 1, y - 1].GetComponent<TileResource_Script>().tileValue = 500;        // pt val 500
            tile[x - 1, y - 1].GetComponent<TileResource_Script>().tileValue = 500;        // pt val 500

            tile[x + 2, y].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x + 2, y - 1].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x - 2, y].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x - 2, y - 1].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x, y + 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x + 1, y + 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x, y - 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x + 1, y - 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x - 1, y + 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x + 2, y + 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x + 2, y + 1].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x - 2, y + 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x - 2, y + 1].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x + 2, y - 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x + 1, y - 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x - 2, y - 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
            tile[x - 1, y - 2].GetComponent<TileResource_Script>().tileValue = 250;        // pt val 250
        }
    }

    public void ScanResource(int x, int y)
    {
        tile[x, y].GetComponent<TileResource_Script>().SetTileColor();
        tile[x + 1, y].GetComponent<TileResource_Script>().SetTileColor();
        tile[x - 1, y].GetComponent<TileResource_Script>().SetTileColor();
        tile[x, y + 1].GetComponent<TileResource_Script>().SetTileColor();
        tile[x, y - 1].GetComponent<TileResource_Script>().SetTileColor();
        tile[x + 1, y + 1].GetComponent<TileResource_Script>().SetTileColor();
        tile[x - 1, y + 1].GetComponent<TileResource_Script>().SetTileColor();
        tile[x + 1, y - 1].GetComponent<TileResource_Script>().SetTileColor();
        tile[x - 1, y - 1].GetComponent<TileResource_Script>().SetTileColor();
    }
}
