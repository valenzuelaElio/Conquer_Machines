using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNewOptions : MonoBehaviour {

    public static bool UpdateList;
    public static bool change;
    public static int option;


    private Image MyImage;
    private GenericListLoader MyGenericListLoader;

    void Start()
    {
        this.MyGenericListLoader = GetComponent<GenericListLoader>();
        this.MyImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (change == true)
        {
            if (UpdateList == true)
            {
                if (Game.GameInstance.currentSelectedRobot != null)
                {
                    this.MyGenericListLoader.elementListType = GenericListLoader.ElementListType.Robots;
                    this.MyGenericListLoader.UpdateList();
                }
                else if(Game.GameInstance.currentSelectedRawMaterial != null)
                {
                    this.MyGenericListLoader.elementListType = GenericListLoader.ElementListType.RawMaterial;
                    this.MyGenericListLoader.UpdateList();
                }
                UpdateList = false;
            }
            this.Show(true);
        }
        else
        {
            this.Show(false);
        }
    }

    private void Show(bool showMe)
    {
        this.MyImage.enabled = showMe;
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.SetActive(showMe);
    }

    public void ProcessOption()
    {
        if (option == 0)
        {
            Game.GameInstance.currentSelectedRobot = Game.GameInstance.tempRobot;
            Game.GameInstance.currentSelectedExtractor.MyExtractor.robot_id = Game.GameInstance.currentSelectedRobot.MyRobot.robot_id;

            Debug.Log("ID = " + Game.GameInstance.currentSelectedExtractor.MyExtractor.robot_id);
            change = false;

            Game.GameInstance.currentSelectedRobot = null;
            Game.GameInstance.tempRobot = null;
        } else if (option == 1)
        {
            Game.GameInstance.currentSelectedRawMaterial = Game.GameInstance.tempRawMaterial;
            Game.GameInstance.currentSelectedExtractor.MyExtractor.rawMaterial_Id = Game.GameInstance.currentSelectedRawMaterial.MyRawMaterial.RawMaterialID;

            change = false;

            Game.GameInstance.currentSelectedRawMaterial = null;
            Game.GameInstance.tempRawMaterial = null;

        }

        Game.GameInstance.currentSelectedExtractor.MyExtractor = null;


    }

    public void cancelOptions()
    {
        change = false;
        Game.GameInstance.currentSelectedRobot = null;
        Game.GameInstance.tempRobot = null;

    }

}
