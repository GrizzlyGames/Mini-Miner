using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller_Script : MonoBehaviour
{

    public static Game_Controller_Script instance;

    public bool bScan;

    public int score = 0;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Board_Manager_Script.instance.GenerateBoard();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);

            if (hit.transform.GetComponent<TileResource_Script>())
            {
                if (bScan)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            if (hit.collider.gameObject == Board_Manager_Script.instance.tile[x,y])
                            {
                                Board_Manager_Script.instance.ScanResource(x, y);
                            }
                        }
                    }
                }
                else
                {
                    score += hit.transform.GetComponent<TileResource_Script>().tileValue;
                    Debug.Log("Score: " + score);
                    hit.transform.GetComponent<TileResource_Script>().ReduceTileValue();
                }
            }
        }
    }
}