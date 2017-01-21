using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TileResource_Script : MonoBehaviour {
    
    public int tileValue;

    public void ReduceTileValue()
    {
        if(tileValue >= 125)
        tileValue -= tileValue / 2;
        Debug.Log("Tile Value: " + tileValue);
        SetTileColor();
    }

    public void SetTileColor()
    {
        if (tileValue == 1000)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (tileValue == 500)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 165, 0, 255);
        }
        else if (tileValue == 250)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (tileValue == 125)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (tileValue == 63)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
