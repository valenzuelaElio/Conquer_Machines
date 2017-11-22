using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblyLine : MonoBehaviour, ITemplate {

    private Button MyButton;
    public DataAssemblyLine MyAssemblyLine;

    public Node CoreNode;
    public Node[] UpgradeNodes;

    int serie = 0;
    public int robot_base_LifePoints = 100;
    public int robot_base_Attack = 10;
    public int robot_base_Speed = 100;
    public int robot_base_EnergyCost = 10;

    private float StartTime;
    private float TimeStamp;
    public float timeToGenerate = 1;

    void Start()
    {
        this.MyButton = GetComponent<Button>();
        this.MyButton.onClick.AddListener(Selected);

        this.initializeNodes();
        this.StartTime = Time.time;

    }

    private void initializeNodes()
    {
        this.MyAssemblyLine.LoadAssemblyLine(Game.GameInstance.GameData);

        this.CoreNode.MyNode = this.MyAssemblyLine.coreNode;

        this.UpgradeNodes[0].MyNode = this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_1];
        this.UpgradeNodes[1].MyNode = this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_2];
        this.UpgradeNodes[2].MyNode = this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_3];

        this.SelectType();
        this.   CalculateUpgrades();
    }

    public int Cant()
    {
        return 0;
    }
    public string Description()
    {
        return "";
    }
    public string Id()
    {
        return MyAssemblyLine.assembly_Line_Id;
    }

    public void ShowData()
    {
        
    }

    private void Selected()
    {
        Game.GameInstance.currentSelectedAssemblyLine = this.MyAssemblyLine;
    }

    private void GenerateRobots()
    {
        if (this.MyAssemblyLine == null)
        {
            return;
        }
        else
        {
            if (this.MyAssemblyLine.coreNode == null)
            {
                return;
            }
            GenerateRobotUnique();
        }
    }

    private void Update()
    {
        GenerateRobots();
    }

    private void CalculateUpgrades()
    {




    }

    private void SelectType()
    {

    }

    private void GenerateRobotUnique()
    {
        TimeStamp = Time.time - StartTime;
        if (TimeStamp > timeToGenerate)
        {
            if (Game.GameInstance.PlayerInstance.RobotInventory.ContainsKey(MyAssemblyLine.robot_id))
            {
                //Se a♫ade al inventario del jugador;
                Game.GameInstance.PlayerInstance.RobotInventory[MyAssemblyLine.robot_id]++;
                Debug.Log("Tengo " + Game.GameInstance.PlayerInstance.RobotInventory[MyAssemblyLine.robot_id] + " Robots de " + MyAssemblyLine.robot_id);
            }
            else
            {
                //Se crea desde cero;
                DataRobot newRobot = new DataRobot();
                newRobot.robot_id = MyAssemblyLine.robot_id + "-" + serie;
                newRobot.robot_name = "Prototype-00" + serie;
                newRobot.Robotstats[this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_1].UpgradeType] = this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_1].upgradeToApply;
                newRobot.Robotstats[this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_2].UpgradeType] = this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_2].upgradeToApply;
                newRobot.Robotstats[this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_3].UpgradeType] = this.MyAssemblyLine.Upgrade_Nodes[this.MyAssemblyLine.upgrade_Node_3].upgradeToApply;
                serie++;
                Game.GameInstance.PlayerInstance.RobotInventory.Add(newRobot.robot_id, 1);
                Debug.Log("Tengo " + Game.GameInstance.PlayerInstance.RobotInventory[MyAssemblyLine.robot_id] + " Robots de " + MyAssemblyLine.robot_id);
            }
            StartTime = Time.time;
        }
    }


}
