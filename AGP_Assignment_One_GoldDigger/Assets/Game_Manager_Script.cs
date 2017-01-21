using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Game_Manager_Script : MonoBehaviour
{
    public List<Button> tileList = new List<Button>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            for (int k = 0; k < 16; k++)
            {
                Debug.Log(GameObject.Find("Grid_Container").transform.GetChild(i).transform.GetChild(k).name);
                GameObject go = GameObject.Find("Grid_Container").transform.GetChild(i).transform.GetChild(k).gameObject;
                go.AddComponent<TileResource_Script>();
                tileList.Add(go.GetComponent<Button>());
            }
        }
    }

    void GenerateResourceLocations()
    {
        for (int r = 0; r < 8; r++)
        {
            int rnd = Random.Range(0, 256);
            for (int k = 0; k < tileList.Count; k++)
            {
                if (k == rnd)
                {
                    Button[] buts = tileList.ToArray();
                    buts[k].GetComponent<TileResource_Script>().tileValue = 2000;
                    buts[k].GetComponent<Button>().image.color = Color.red;

                    buts[k + 1].GetComponent<TileResource_Script>().tileValue = 1000;
                    buts[k + 1].GetComponent<Button>().image.color = Color.cyan;

                    buts[k - 1].GetComponent<TileResource_Script>().tileValue = 1000;
                    buts[k - 1].GetComponent<Button>().image.color = Color.cyan;

                    buts[k + 2].GetComponent<TileResource_Script>().tileValue = 500;
                    buts[k + 2].GetComponent<Button>().image.color = Color.yellow;

                    buts[k - 2].GetComponent<TileResource_Script>().tileValue = 500;
                    buts[k - 2].GetComponent<Button>().image.color = Color.yellow;
                }
            }
        }
    }
}