using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataManager{

    public static Data DataMaster { get; set; }

    public static List<DataMision> AllMisions               = new List<DataMision>();
    public static List<DataExtractor> AllExtractors         = new List<DataExtractor>();
    public static List<DataRawMaterial> AllRawMaterials     = new List<DataRawMaterial>();
    public static List<DataAssemblyLine> AllAssemblyLines   = new List<DataAssemblyLine>();
    public static List<DataRobot> AllRobots                 = new List<DataRobot>();
    public static List<Core> AllCores                       = new List<Core>();
    public static List<Upgrade> AllUpgrades                 = new List<Upgrade>();
    public static List<DataNode> AllNodes                   = new List<DataNode>();

    private static string path;

    public static void CreateDataMapExample(string XMLpath)
    {
        /*
        path = XMLpath;
        
        System.Random random = new System.Random();
        DataMaster = new Data();

        //Core Nodes
        for (int i = 0; i < 3; i++)
        {
            Core Core_Node = new Core();

            Core_Node.node_id = "NC00" + i;
            Core_Node.assemblyLine_id = "L00" + i;
            Core_Node.rawMaterial1 = "RM00" + 0;
            Core_Node.rawMaterial2 = "RM00" + 1;
            Core_Node.rawMaterial3 = "RM00" + 2;
            Core_Node.cant1 = 10 * i;
            Core_Node.cant2 = 20 * i;
            Core_Node.cant3 = 30 * i;

            Core_Node.path = "CoreNodes-01";
            Core_Node.spriteIndex = i;

            Core_Node.generationTime = 5 + 5 * i;
            Core_Node.robot_id = "R00" + i;

            DataMaster.Nodes[i] = Core_Node;

        }
        //Upgrade Nodes
        for (int i = 4; i < 8; i++)
        {
            Upgrade Upg_Node = new Upgrade();

            Upg_Node.node_id = "NU00" + (i - 4);
            Upg_Node.assemblyLine_id = "L00" +  (i - 4);
            Upg_Node.rawMaterial1 = "RM00" + 0;
            Upg_Node.rawMaterial2 = "RM00" + 1;
            Upg_Node.rawMaterial3 = "RM00" + 2;
            Upg_Node.cant1 = 10 * i;
            Upg_Node.cant2 = 20 * i;
            Upg_Node.cant3 = 30 * i;

            Upg_Node.path = "UpgradeNodes";
            Upg_Node.spriteIndex = i - 4;
            //Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/" + path);s

            Upg_Node.UpgradeType = "LifePoints";
            Upg_Node.upgradeToApply = 100;

            DataMaster.Nodes[i] = Upg_Node;
        }
        //Assembly Lines
        for (int i = 0; i < 3; i++)
        {
            DataMaster.AssemblyLines[i] = new DataAssemblyLine();
            DataMaster.AssemblyLines[i].assembly_Line_Id = "L00" + i;
            DataMaster.AssemblyLines[i].core_id = "NC00" + i;
            DataMaster.AssemblyLines[i].upgrade_Node_1 = "NU00" + 0;
            DataMaster.AssemblyLines[i].upgrade_Node_2 = "NU00" + 1;
            DataMaster.AssemblyLines[i].upgrade_Node_3 = "NU00" + 2;
        }
        //Robots
        for (int i = 0; i < 10; i++)
        {
            DataRobot newRobot = new DataRobot();

            newRobot.robot_id = "R00" + i;
            newRobot.path = "Sprites/robo-logo-black";
            newRobot.robot_Description = "lorem ipsum : 80";
            newRobot.LifePoints = 50 * i + 50;
            newRobot.EnergyCost = 20 * i;
            newRobot.Attack = 10 * i;
            newRobot.Speed = 10 * i;
            newRobot.robot_name = "RHE-00" + i + "(Prototype)";
            newRobot.robot_level = random.Next(1, 3);
            newRobot.Duration = 10;

            DataMaster.Robots[i] = newRobot;
        }
        //Misions
        for (int i = 0; i < 3; i++)
        {
            DataMaster.Misions[i] = new DataMision();
            DataMaster.Misions[i].mision_Id = "M00" + i;
            DataMaster.Misions[i].Dificulty = i;
            DataMaster.Misions[i].Requirements = "None";
            DataMaster.Misions[i].Description = "Lorem Ipsum : 100";
            DataMaster.Misions[i].isCompleted = false;
            DataMaster.Misions[i].mision_Name = "Mision " + i;
            DataMaster.Misions[i].EnemiesQnty = 5 * (i + 1);
            DataMaster.Misions[i].MinDeckLevel = 0 + (1 * i);
            DataMaster.Misions[i].MaxDeckLevel = 6 + (3 * i);
            DataMaster.Misions[i].Reward1 = "RM002";
            DataMaster.Misions[i].cant1 = 10;
            DataMaster.Misions[i].Reward1 = "RM001" + i;
            DataMaster.Misions[i].cant1 = 20 + 5 * i;
            DataMaster.Misions[i].Reward1 = "RM000" + i;
            DataMaster.Misions[i].cant1 = 30 + 10 * i;
        }
        //Raw materials
        for (int i = 0; i < 4; i++)
        {
            DataMaster.RawMaterials[i] = new DataRawMaterial();
            DataMaster.RawMaterials[i].RawMaterialID = "RM00" + i;
            DataMaster.RawMaterials[i].RawMaterialName = "Iron v" + i;
            DataMaster.RawMaterials[i].Rarity = i + 1;
            DataMaster.RawMaterials[i].path = "Sprites/Ferrita";
        }
        //Extractors
        for (int i = 0; i < 2; i++)
        {
            DataMaster.Extractors[i] = new DataExtractor();
            DataMaster.Extractors[i].Id = "E00" + i;
            DataMaster.Extractors[i].rawMaterial_Id = "RM00" + i;
            DataMaster.Extractors[i].rawMaterial_initialQnty = 0;
            DataMaster.Extractors[i].rawMaterial_recolectedQnty = 0;
            DataMaster.Extractors[i].robot_id = "R00" + i;
            DataMaster.Extractors[i].robot_initialQnty = 0;
            DataMaster.Extractors[i].robot_Left = 0;
        }

        DataMaster.ScenesNames[0] = "CM_0_Main";
        DataMaster.ScenesNames[1] = "CM_1_AssemblyLines";
        DataMaster.ScenesNames[2] = "CM_2_RobotInventory";
        DataMaster.ScenesNames[3] = "CM_3_Extractions";
        DataMaster.ScenesNames[4] = "CM_4_BattleList";
        DataMaster.ScenesNames[5] = "CM_4.1_BattlePreparation";
        DataMaster.ScenesNames[6] = "CM_4.2_Minigame";
        */

        //SerializeDataOnPC();
        //SerializeData();
        //Save();
        //Load(path);
        //SerializeDataOnPC();
        //dataMaster = DeserializeDataOPc();

    }

    

    static public void Save()
    {
        //XMLOperator.Serialize(DataMaster,path);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SavedGame.gd");
        bf.Serialize(file, DataMaster);
        file.Close();

        Game.GameInstance.GuardarTiempoLineasDeEnsamblaje();

    }

    static public void SerializeDataOnPC()
    {
        XMLOperator.SerializeOnPC(DataMaster, "Assets/Sprites");
    }

    static public Data DeserializeDataOnPc()
    {
        return XMLOperator.DeserializeOnPC<Data>(path);
    }

    static public void Load(string path)
    {
        //return XMLOperator.Deserialize<Data>(path);
        if (File.Exists(Application.persistentDataPath + "/SavedGame.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavedGame.gd", FileMode.Open);
            DataMaster = (Data)bf.Deserialize(file);
            file.Close();
        }

    }

    public static DataAssemblyLine GetAssemblyLine(string id)
    {
        foreach (DataAssemblyLine temp in AllAssemblyLines)
        {
            if (temp.assembly_Line_Id == id)
            {
                return temp;
            }
        }
        return null;
    }

    static public Core GetCoreNode(string node_id, string al_id)
    {
        Core newCoreNode = new Core();
        foreach (DataNode temp in AllNodes)
        {
            if (temp.node_id == node_id)
            {
                newCoreNode.node_id = temp.node_id;
                newCoreNode.assemblyLine_id = al_id;

                newCoreNode.rawMaterial1 = temp.rawMaterial1;
                newCoreNode.rawMaterial2 = temp.rawMaterial2;
                newCoreNode.rawMaterial3 = temp.rawMaterial3;

                newCoreNode.cant1 = temp.cant1;
                newCoreNode.cant2 = temp.cant2;
                newCoreNode.cant3 = temp.cant3;

                newCoreNode.path = temp.path;
                newCoreNode.spriteIndex = temp.spriteIndex;

                Core coreTempExtension = temp as Core;
                newCoreNode.generationTime = coreTempExtension.generationTime;
                newCoreNode.robot_id = coreTempExtension.robot_id;
            }
        }
        return newCoreNode;
    }

    static public Upgrade GetUpgradeNode(string node_id, string al_id)
    {
        Upgrade newNode = new Upgrade();
        foreach (DataNode temp in AllNodes)
        {
            if (temp.node_id == node_id)
            {
                newNode.node_id = temp.node_id;
                newNode.assemblyLine_id = al_id;

                newNode.rawMaterial1 = temp.rawMaterial1;
                newNode.rawMaterial2 = temp.rawMaterial2;
                newNode.rawMaterial3 = temp.rawMaterial3;

                newNode.cant1 = temp.cant1;
                newNode.cant2 = temp.cant2;
                newNode.cant3 = temp.cant3;

                newNode.path = temp.path;
                newNode.spriteIndex = temp.spriteIndex;

            }
        }
        return newNode;
    }

    static public DataRobot GetRobot(string id)
    {
        DataRobot newRobot = new DataRobot();
        foreach (DataRobot temp in AllRobots)
        {
            if (temp.robot_id == id)
            {
                newRobot.robot_id = temp.robot_id;
                newRobot.robot_Description = temp.robot_Description;
                newRobot.LifePoints = temp.LifePoints;
                newRobot.EnergyCost = temp.EnergyCost;
                newRobot.Attack = temp.Attack;
                newRobot.Speed = temp.Speed;
                newRobot.robot_name = temp.robot_name;
                newRobot.robot_level = temp.robot_level;
                newRobot.Duration = temp.Duration;
                newRobot.InitializeStats();
            }
        }
        return newRobot;
    }

    static public DataRawMaterial GetRawMaterial(String id)
    {
        DataRawMaterial newRawMaterial = new DataRawMaterial();
        foreach (DataRawMaterial temp in AllRawMaterials)
        {
            if (temp.RawMaterialID == id)
            {
                newRawMaterial.RawMaterialID = temp.RawMaterialID;
                newRawMaterial.RawMaterialName = temp.RawMaterialName;
                newRawMaterial.Description = temp.Description;
                newRawMaterial.Rarity = temp.Rarity;
                newRawMaterial.path = temp.path;


            }
        }
        return newRawMaterial;
    }

    static public void ListLoading()
    {
        for (int i = 0; i < DataMaster.Misions.Length; i++)
            if(DataMaster.Misions[i] != null)
                AllMisions.Add(DataMaster.Misions[i]);

        for (int i = 0; i < DataMaster.RawMaterials.Length; i++)
            if (DataMaster.RawMaterials[i] != null)
                AllRawMaterials.Add(DataMaster.RawMaterials[i]);

        for (int i = 0; i < DataMaster.Extractors.Length; i++)
            if (DataMaster.Extractors[i] != null)
                AllExtractors.Add(DataMaster.Extractors[i]);

        for (int i = 0; i < DataMaster.AssemblyLines.Length; i++)
            if (DataMaster.AssemblyLines[i] != null)
                AllAssemblyLines.Add(DataMaster.AssemblyLines[i]);
        /*
        for (int i = 0; i < DataMaster.Core_Nodes.Length; i++)
            if (DataMaster.Core_Nodes[i] != null)
                AllCores.Add(DataMaster.Core_Nodes[i]);

        for (int i = 0; i < DataMaster.Upgrade_Nodes.Length; i++)
            if (DataMaster.Upgrade_Nodes[i] != null)
                AllUpgrades.Add(DataMaster.Upgrade_Nodes[i]);
                */

        for (int i = 0; i < DataMaster.Robots.Length; i++)
            if (DataMaster.Robots[i] != null)
            {
                DataRobot newRobot = DataMaster.Robots[i];
                AllRobots.Add(newRobot);
            }

        for (int i = 0; i < DataMaster.Nodes.Length; i++)
            if (DataMaster.Nodes[i] != null)
                AllNodes.Add(DataMaster.Nodes[i]);
    }

}
