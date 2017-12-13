using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour, ITemplate {

    private Image MyImage;
    public DataRobot MyRobot { get; set; }
    private Button MyButton;

    private bool emptySlot;

    public Text robotName;
    public Sprite Sprite { get; set; }

    public int Cant()
    {
        //Regresa la cantidad que posee el jugador
        if (Game.GameInstance.PlayerInstance.RobotQnty.ContainsKey(MyRobot.robot_id))
        {
            return Game.GameInstance.PlayerInstance.RobotQnty[MyRobot.robot_id];
        }
        else
        {
            return 0;
        }
    }
    public string Description()
    {
        return MyRobot.robot_Description;//Descripcion generica del robot;
    }
    public string Id()
    {
        return this.MyRobot.robot_id;
    }

    public void ShowData()
    {
        //robotName.text = "" + MyRobot.robot_id;
    }

    public void Start()
    {
        this.MyImage = GetComponent<Image>();

        if (ScenesManager.LastLoadedScene == "CM_3_Extractions")
        {

        }
        else
        {
            this.MyImage.sprite = Resources.Load<Sprite>(this.MyRobot.path);
        }

        if (this.MyRobot == null)
        {
            Debug.Log("MyRobot is Empty");
            emptySlot = true;
        }

        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);
        //Debug.Log("Robot Initialized");

        if (robotName != null)
        {
            robotName.text = "" + MyRobot.robot_name;
        }
    }

    private void Selected()
    {
        if (ScenesManager.LastLoadedScene == "CM_2_RobotInventory")
        {
            Game.GameInstance.currentSelectedRobot = this;
            GenericListController.selected = 0;
            UpdateSprite.NeedUpdate = true;
        }

        if (ScenesManager.LastLoadedScene == "CM_3_Extractions")
        {
            if (emptySlot == true)
            {
                if (Game.GameInstance.currentSelectedRobot == null)
                {
                    Game.GameInstance.currentSelectedRobot = this;
                    Game.GameInstance.currentSelectedExtractor = gameObject.transform.parent.gameObject.GetComponent<Extractor>();
                    //Debug.Log("" + gameObject.transform.parent.gameObject.GetComponent<Extractor>().MyExtractor.Id);
                    AddNewOptions.change = true;
                    AddNewOptions.UpdateList = true;
                    return;
                }

            }

            if (Game.GameInstance.currentSelectedRobot != null)
            {
                Game.GameInstance.tempRobot = this;
                //Debug.Log(Game.GameInstance.tempRobot.MyRobot.robot_id);
                AddNewOptions.option = 0;
            }
        }

        if (ScenesManager.LastLoadedScene == Game.GameInstance.GameData.ScenesNames[6])
        {
            Debug.Log("Correcto");
            Game.GameInstance.currentSelectedRobot = this;
        }
    }

}
