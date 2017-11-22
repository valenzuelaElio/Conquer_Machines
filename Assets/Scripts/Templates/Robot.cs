using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour, ITemplate {

    public DataRobot MyRobot { get; set; }
    private Button MyButton;

    public Text robotName;
    public Sprite Sprite { get; set; }

    public int Cant()
    {
        //TODO: Regresa la cantidad que posee el jugador
        return 0;
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
        robotName.text = "" + MyRobot.robot_id;
    }

    public void Start()
    {
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);
        Debug.Log("Robot Initialized");
    }

    private void Selected()
    {
        Debug.Log("Robot Apretado");
        Game.GameInstance.currentSelectedRobot = this.MyRobot;
    }

}
