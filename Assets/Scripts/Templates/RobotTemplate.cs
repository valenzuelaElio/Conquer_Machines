using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotTemplate : MonoBehaviour, ITemplate {

    public Robot MyRobot { get; set; }
    public Text robotName;
    public Sprite Sprite { get; set; }

    public int Cant()
    {
        //TODO: Regresa la cantidad que posee el jugador
        return 0;
    }

    public string Description()
    {
        return MyRobot.Description;//Descripcion generica del robot;
    }

    public string Id()
    {
        return MyRobot.RobotID;
    }

    public void ShowData()
    {
        robotName.text = "" + MyRobot.RobotName;
    }

}
