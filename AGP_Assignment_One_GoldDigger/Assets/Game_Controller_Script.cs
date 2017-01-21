using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_Controller_Script : MonoBehaviour
{

    public static Game_Controller_Script instance;

    public Text scoreText;
    public Text messageText;
    public Text scansNumText;

    public bool bScan;

    public int scans = 6;
    public int digs = 3;

    public int score = 0;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Board_Manager_Script.instance.GenerateBoard();
        messageText.text = "Begin by scanning for minerals.";
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
                if (bScan && scans > 0 && digs > 0)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            if (hit.collider.gameObject == Board_Manager_Script.instance.tile[x,y])
                            {
                                Board_Manager_Script.instance.ScanResource(x, y);
                                scans--;
                                scansNumText.text = scans.ToString();
                                if (scans <= 0)
                                {
                                    messageText.text = "No more scans left, click the scanning icon to switch to mining!";
                                }
                            }
                        }
                    }
                }
                else if (!bScan && digs > 0)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            if (hit.collider.gameObject == Board_Manager_Script.instance.tile[x, y])
                            {
                                Board_Manager_Script.instance.ReduceTileValue(x, y);
                                score += hit.transform.GetComponent<TileResource_Script>().tileValue;
                                Debug.Log("Score: " + score);
                                scoreText.text = "Score: " + score;
                                hit.transform.GetComponent<TileResource_Script>().ReduceTileValue();
                                digs--;
                                scansNumText.text = digs.ToString();
                                score += hit.transform.GetComponent<TileResource_Script>().tileValue;
                                if (digs <= 0)
                                {
                                    messageText.text = "No more digs left! GAME OVER";
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}