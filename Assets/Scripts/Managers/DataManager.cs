using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using UnityEngine.UI;

public static class DataManager{

    public static Data DataMaster { get; set; }

    public static List<DataMision> AllMisions               = new List<DataMision>();
    public static List<DataExtractor> AllExtractors         = new List<DataExtractor>();
    public static List<DataRawMaterial> AllRawMaterials     = new List<DataRawMaterial>();
    public static List<DataAssemblyLine> AllAssemblyLines   = new List<DataAssemblyLine>();
    public static List<DataRobot> AllRobots                 = new List<DataRobot>();
    public static List<Core> AllCores                       = new List<Core>();
    public static List<Upgrade> AllUpgrades                 = new List<Upgrade>();

    private static string path;

    public static void CreateDataMapExample(string XMLpath)
    {
        path = XMLpath;
        System.Random random = new System.Random();
        DataMaster = new Data();
        //Core Node
        for (int i = 0; i < 4; i++)
        {
            DataMaster.Core_Nodes[i] = new Core();
            DataMaster.Core_Nodes[i].node_id = "NC00" + i;
            DataMaster.Core_Nodes[i].rawMaterial1 = "RM00" + 0;
            DataMaster.Core_Nodes[i].rawMaterial2 = "RM00" + 1;
            DataMaster.Core_Nodes[i].rawMaterial3 = "RM00" + 2;
            DataMaster.Core_Nodes[i].cant1 = 10 * i;
            DataMaster.Core_Nodes[i].cant2 = 20 * i;
            DataMaster.Core_Nodes[i].cant3 = 30 * i;
        }
        //Upgrade Node
        for (int i = 0; i < 4; i++)
        {
            DataMaster.Upgrade_Nodes[i] = new Upgrade();
            DataMaster.Upgrade_Nodes[i].node_id = "NU00" + i;
            DataMaster.Upgrade_Nodes[i].rawMaterial1 = "RM00" + 0;
            DataMaster.Upgrade_Nodes[i].rawMaterial2 = "RM00" + 1;
            DataMaster.Upgrade_Nodes[i].rawMaterial3 = "RM00" + 2;
            DataMaster.Upgrade_Nodes[i].cant1 = 10 * i;
            DataMaster.Upgrade_Nodes[i].cant2 = 20 * i;
            DataMaster.Upgrade_Nodes[i].cant3 = 30 * i;

            DataMaster.Upgrade_Nodes[i].UpgradeType = "LifePoints";
            DataMaster.Upgrade_Nodes[i].upgradeToApply = 10 * i;
        }
        //Assembly Lines
        for (int i = 0; i < 4; i++)
        {
            DataMaster.AssemblyLines[i] = new DataAssemblyLine();
            DataMaster.AssemblyLines[i].assembly_Line_Id = "L00" + i;
            DataMaster.AssemblyLines[i].core_id = "NC00" + i;
            DataMaster.AssemblyLines[i].upgrade_Node_1 = "NU00" + 0;
            DataMaster.AssemblyLines[i].upgrade_Node_2 = "NU00" + 1;
            DataMaster.AssemblyLines[i].upgrade_Node_3 = "NU00" + 2;
            DataMaster.AssemblyLines[i].robot_id = "R00" + i;
        }
        //Robots
        for (int i = 0; i < 4; i++)
        {
            DataMaster.Robots[i] = new DataRobot();
            DataMaster.Robots[i].robot_id = "R00" + i;
            DataMaster.Robots[i].robot_Description = "lorem ipsum : 80";
            DataMaster.Robots[i].LifePoints = 50 * i + 50;
            DataMaster.Robots[i].EnergyCost = 20 * i;
            DataMaster.Robots[i].Attack = 10 * i;
            DataMaster.Robots[i].Speed = 10 * i;
            DataMaster.Robots[i].robot_name = "RHE-00" + i + "(Prototype)";
            DataMaster.Robots[i].robot_level = random.Next(1, 3);
            DataMaster.Robots[i].Duration = 10;
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
        }
        //Raw materials
        for (int i = 0; i < 4; i++)
        {
            DataMaster.RawMaterials[i] = new DataRawMaterial();
            DataMaster.RawMaterials[i].RawMaterialID = "RM00" + i;
            DataMaster.RawMaterials[i].RawMaterialName = "Iron v" + i;
            DataMaster.RawMaterials[i].Rarity = i + 1;
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

        SerializeDataOnPC();
        //SerializeData();
        //dataMaster = DeserializeData();
        //dataMaster = DeserializeDataOPc();

    }

    static public void SerializeData()
    {
        XMLOperator.Serialize(DataMaster,path);
    }

    static public void SerializeDataOnPC()
    {
        XMLOperator.SerializeOnPC(DataMaster, path);
    }

    static public Data DeserializeDataOnPc()
    {
        return XMLOperator.DeserializeOnPC<Data>(path);
    }

    static public Data DeserializeData()
    {
        return XMLOperator.Deserialize<Data>(path);
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

        for (int i = 0; i < DataMaster.Core_Nodes.Length; i++)
            if (DataMaster.Core_Nodes[i] != null)
                AllCores.Add(DataMaster.Core_Nodes[i]);

        for (int i = 0; i < DataMaster.Upgrade_Nodes.Length; i++)
            if (DataMaster.Upgrade_Nodes[i] != null)
                AllUpgrades.Add(DataMaster.Upgrade_Nodes[i]);

        for (int i = 0; i < DataMaster.Robots.Length; i++)
            if (DataMaster.Robots[i] != null)
                AllRobots.Add(DataMaster.Robots[i]);

    }

}
