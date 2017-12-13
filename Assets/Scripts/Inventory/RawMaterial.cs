using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawMaterial : MonoBehaviour, ITemplate {

    private Image MyImage;
    private Button MyButton;
    public DataRawMaterial MyRawMaterial;
    public Text name;

    bool emptySlot;

    public int Cant()
    {
        if (Game.GameInstance.PlayerInstance.RM_Inventory.ContainsKey(this.MyRawMaterial.RawMaterialID))
        {
            return Game.GameInstance.PlayerInstance.RM_Inventory[this.MyRawMaterial.RawMaterialID];
        }
        else
        {
            return 0;
        }
    }
    public string Description()
    {
        return this.MyRawMaterial.Description;
    }
    public string Id()
    {
        return this.MyRawMaterial.RawMaterialID;
    }
    public void ShowData()
    {

    }

    void Start () {
        this.MyImage = GetComponent<Image>();
        this.MyImage.sprite = Resources.Load<Sprite>("Sprites/Ferrita");

        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);

        if (name != null)
        {
            name.text = "" + this.MyRawMaterial.RawMaterialName;
        }

        if (this.MyRawMaterial == null)
        {
            Debug.Log("ID = " + this.MyRawMaterial.RawMaterialID);
            emptySlot = true;
        }
	}
	
    public void Selected()
    {

        if (ScenesManager.LastLoadedScene == "CM_3_Extractions")
        {
            if (emptySlot == true)
            {
                if (Game.GameInstance.currentSelectedRawMaterial == null)
                {
                    Game.GameInstance.currentSelectedRawMaterial = this;
                    Game.GameInstance.currentSelectedExtractor = gameObject.transform.parent.gameObject.GetComponent<Extractor>();
                    AddNewOptions.change = true;
                    AddNewOptions.UpdateList = true;
                    return;
                }

                if (Game.GameInstance.currentSelectedRawMaterial != null)
                {
                    Game.GameInstance.tempRawMaterial = this;
                    AddNewOptions.option = 1;
                    //Debug.Log(Game.GameInstance.tempRobot.MyRobot.robot_id);
                }
            }
        }

        if (ScenesManager.LastLoadedScene == "CM_2_RobotInventory")
        {
            Game.GameInstance.currentSelectedRawMaterial = this;
            GenericListController.selected = 2;
            UpdateSprite.NeedUpdate = true;
        }
    }
}
