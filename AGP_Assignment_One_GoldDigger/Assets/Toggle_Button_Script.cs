using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Toggle_Button_Script : MonoBehaviour {

    public Text tileText;

    public Sprite scanImage;
    public Sprite digImage;

    public Text subTileText;

    public void ToggleScan()
    {
        if (Game_Controller_Script.instance.bScan == true)
        {
            Game_Controller_Script.instance.bScan = false;
            GetComponent<Image>().sprite = digImage;
            tileText.text = "Digging";
            subTileText.text = Game_Controller_Script.instance.digs.ToString();
        }
        else if (Game_Controller_Script.instance.bScan == false)
        {
            Game_Controller_Script.instance.bScan = true;
            GetComponent<Image>().sprite = scanImage;
            tileText.text = "Scanning";
            subTileText.text = Game_Controller_Script.instance.scans.ToString();
        }
    }
}
