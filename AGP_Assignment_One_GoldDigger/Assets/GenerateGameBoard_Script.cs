using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGameBoard_Script : MonoBehaviour
{

    public static GenerateGameBoard_Script instance;
    void Awake()
    {
        instance = this;
    }

    public int gridWidth = 16;
    public int gridHeight = 16;
    public GameObject prefab;

    protected GameObject[,] tile;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
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

    void GenerateResources()
    {
        int rndNum = Random.Range(6, 9);

        int x;
        int y;
        
        for (int m = 0; m < rndNum; m++)
        {

            x = Random.Range(3, 14);
            y = Random.Range(3, 14);

            tile[x, y].GetComponent<SpriteRenderer>().color = Color.red;            // orgin point

            tile[x + 1, y].GetComponent<SpriteRenderer>().color = Color.blue;      // 1 sq to the right
            tile[x - 1, y].GetComponent<SpriteRenderer>().color = Color.blue;      // 1 sq to the leght
            tile[x, y + 1].GetComponent<SpriteRenderer>().color = Color.blue;      // 1 sq up
            tile[x, y - 1].GetComponent<SpriteRenderer>().color = Color.blue;      // 1 sq down

            tile[x + 1, y + 1].GetComponent<SpriteRenderer>().color = Color.blue;      // 1 sq to the right && 1 sq up
            tile[x - 1, y + 1].GetComponent<SpriteRenderer>().color = Color.blue;      // 1 sq to the left && 1 sq up
            tile[x + 1, y - 1].GetComponent<SpriteRenderer>().color = Color.blue;      // 1 sq to the right && 1 sq down
            tile[x - 1, y - 1].GetComponent<SpriteRenderer>().color = Color.blue;      // 1 sq to the left && 1 sq down


            tile[x + 2, y].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq to the right
            tile[x + 2, y - 1].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq to the right && 1 sq down

            tile[x - 2, y].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq to the left
            tile[x - 2, y - 1].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq to the left && 1 sq down

            tile[x, y + 2].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq up
            tile[x + 1, y + 2].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq up && 1 sq right

            tile[x, y - 2].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq down
            tile[x + 1, y - 2].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq down && 1 sq right

            tile[x - 1, y + 2].GetComponent<SpriteRenderer>().color = Color.green;      // 1 sq to the left && 2 sq up

            tile[x + 2, y + 2].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq to the right && 2 sq up
            tile[x + 2, y + 1].GetComponent<SpriteRenderer>().color = Color.green;          // 2 sq to the right && 1 sq up

            tile[x - 2, y + 2].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq to the left && 2 sq up
            tile[x - 2, y + 1].GetComponent<SpriteRenderer>().color = Color.green;          // 2 sq to the left && 1 sq up

            tile[x + 2, y - 2].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq to the right && 2 sq down
            tile[x + 1, y - 2].GetComponent<SpriteRenderer>().color = Color.green;          // 1 sq to the right && 2 sq down

            tile[x - 2, y - 2].GetComponent<SpriteRenderer>().color = Color.green;      // 2 sq to the left && 2 sq down
            tile[x - 1, y - 2].GetComponent<SpriteRenderer>().color = Color.green;          // 1 sq to the left && 2 sq down
        }
    }
}
