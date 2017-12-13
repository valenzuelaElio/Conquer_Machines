using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprite : MonoBehaviour {

    Image MyImage;
    public static bool NeedUpdate;

	void Start () {
        MyImage = GetComponent<Image>();
        NeedUpdate = true;
        GenericListController.selected = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (NeedUpdate == true)
        {
            if (GenericListController.selected == 0)
            {
                MyImage.sprite = Game.GameInstance.currentSelectedRobot.GetComponent<Image>().sprite;
            }
            else if (GenericListController.selected == 1)
            {
                MyImage.sprite = Game.GameInstance.currentSelectedNode.GetComponent<Image>().sprite;
            }
            else if (GenericListController.selected == 2)
            {
                MyImage.sprite = Game.GameInstance.currentSelectedRawMaterial.GetComponent<Image>().sprite;
            }
            NeedUpdate = false;
        }
	}
}
