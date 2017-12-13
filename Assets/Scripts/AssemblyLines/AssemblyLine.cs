using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AssemblyLine : MonoBehaviour{

    private DateTime firstTime;
    private DateTime LastTime;

    private Image MyImage;
    private Color originalColor;
    public DataAssemblyLine MyAssemblyLine;
    public GameObject[] Nodes;//Gameobjects con componente Node;

    void Start()
    {
        this.MyImage = GetComponent<Image>();
        this.originalColor = this.MyImage.color;

        for (int i = 0; i < 4; i++)
        {
            this.Nodes[i].GetComponent<Node>().lineIndex = i;
        }


        this.Nodes[0].GetComponent<Node>().isCore = true;

        this.initializeNodes();

        Game.GameInstance.AddLineaDeEnsamblaje(this);

        if (File.Exists(Application.persistentDataPath + "/" + this.MyAssemblyLine.assembly_Line_Id + ".gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + this.MyAssemblyLine.assembly_Line_Id + ".gd", FileMode.Open);
            LastTime = (DateTime)bf.Deserialize(file);
            file.Close();

        }

        if (this.MyAssemblyLine.core_id.Length > 1)
        {
            //Time:
            this.firstTime = System.DateTime.Now;
            TimeSpan time = firstTime - LastTime;
            float totalSeconds = time.Seconds + (time.Minutes * 60) + (time.Hours * 3600) + (time.Days * 86400);

            Core core = (Core)this.Nodes[0].GetComponent<Node>().MyNode;
            int generatedTimes = (int)(totalSeconds / core.generationTime);

            DataRobot newRobot = new DataRobot();
            newRobot = DataManager.GetRobot(core.robot_id);

            if (Game.GameInstance.PlayerInstance.Player_Robots.ContainsKey(core.robot_id))
            {
                //Debug.Log("Actualizo");
                Game.GameInstance.PlayerInstance.Player_Robots[core.robot_id] = newRobot;
                Game.GameInstance.PlayerInstance.RobotQnty[core.robot_id] += generatedTimes;
            }
            else //Si el jugador no tenia a este robot
            {
                Game.GameInstance.PlayerInstance.Player_Robots.Add(core.robot_id, newRobot);
                //Se crea un nuevo espacio para el robot
                Game.GameInstance.PlayerInstance.RobotQnty.Add(core.robot_id, generatedTimes);
            }

            Debug.Log(core.robot_id + " = " + Game.GameInstance.PlayerInstance.RobotQnty[core.robot_id]);
        }
        



    }

    public void initializeNodes()
    {
        if (this.MyAssemblyLine.core_id != "")
        {
            this.Nodes[0].GetComponent<Node>().MyNode = DataManager.GetCoreNode(this.MyAssemblyLine.core_id, this.MyAssemblyLine.assembly_Line_Id);
        }
        if (this.MyAssemblyLine.upgrade_Node_1 != "")
        {
            this.Nodes[1].GetComponent<Node>().MyNode = DataManager.GetUpgradeNode(this.MyAssemblyLine.upgrade_Node_1, this.MyAssemblyLine.assembly_Line_Id);
        }
        if (this.MyAssemblyLine.upgrade_Node_2 != "")
        {
            this.Nodes[2].GetComponent<Node>().MyNode = DataManager.GetUpgradeNode(this.MyAssemblyLine.upgrade_Node_2, this.MyAssemblyLine.assembly_Line_Id);
        }
        if (this.MyAssemblyLine.upgrade_Node_3 != "")
        {
            this.Nodes[3].GetComponent<Node>().MyNode = DataManager.GetUpgradeNode(this.MyAssemblyLine.upgrade_Node_3, this.MyAssemblyLine.assembly_Line_Id);
        }

        //Comienzo a trabajar
        if (this.Nodes[0].GetComponent<Node>().MyNode != null)
        {
            //Debug.Log("Core inicializado");
            Core core = (Core)this.Nodes[0].GetComponent<Node>().MyNode;
            core.StartToGenerate();
        }

    }

    private void Update()
    {
        GenerateRobots();

        if (this == Game.GameInstance.currentSelectedAssemblyLine)
        {
            this.MyImage.color = Color.blue * 0.5f;
        }
        else
        {
            this.MyImage.color = this.originalColor;
        }
    }

    private void GenerateRobots()
    {
        if (this.Nodes[0].GetComponent<Node>().MyNode == null)
        {
            return;
        }

        if (this.Nodes[0].GetComponent<Node>().MyNode != null)
        {
            Core core = (Core)this.Nodes[0].GetComponent<Node>().MyNode;
            core.Generating(Time.time);

            if (core.Generate == true)
            {
                DataRobot newRobot = new DataRobot();
                newRobot = DataManager.GetRobot(core.robot_id);
                //Debug.Log("Core id" + core.robot_id);

                //Debug.Log("Lifepoints Before = " + newRobot.Robotstats["LifePoints"]);
                //Primer upgrade:
                if (this.Nodes[1].GetComponent<Node>().MyNode != null)
                {
                    Upgrade upgrade1 = (Upgrade)this.Nodes[1].GetComponent<Node>().MyNode;
                    upgrade1.ApplyUpgrade(newRobot);

                }
                //Segundo upgrade:
                if (this.Nodes[2].GetComponent<Node>().MyNode != null)
                {
                    Upgrade upgrade2 = (Upgrade)this.Nodes[2].GetComponent<Node>().MyNode;
                    upgrade2.ApplyUpgrade(newRobot);
                }
                //Tercer upgrade:
                if (this.Nodes[3].GetComponent<Node>().MyNode != null)
                {
                    Upgrade upgrade3 = (Upgrade)this.Nodes[3].GetComponent<Node>().MyNode;
                    upgrade3.ApplyUpgrade(newRobot);
                }
                //Debug.Log("Lifepoints After = " + newRobot.Robotstats["LifePoints"]);

                if (Game.GameInstance.PlayerInstance.Player_Robots.ContainsKey(core.robot_id))
                {
                    //Debug.Log("Actualizo");
                    Game.GameInstance.PlayerInstance.Player_Robots[core.robot_id] = newRobot;
                    Game.GameInstance.PlayerInstance.RobotQnty[core.robot_id]++;
                    //Debug.Log("Tengo " + Game.GameInstance.PlayerInstance.RobotQnty[core.robot_id] + " Robots de " + core.robot_id);
                }
                else //Si el jugador no tenia a este robot
                {
                    //Debug.Log("Creo uno nuevo");
                    Game.GameInstance.PlayerInstance.Player_Robots.Add(core.robot_id, newRobot);
                     //Se crea un nuevo espacio para el robot
                    Game.GameInstance.PlayerInstance.RobotQnty.Add(core.robot_id, 1);
                }
                
                //Se a♫ade al inventario del jugador;

            }
        }
    }

    public void SaveTime()
    {
        LastTime = DateTime.Now;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + this.MyAssemblyLine.assembly_Line_Id + ".gd");
        bf.Serialize(file, LastTime);
        file.Close();
    }

    





}
