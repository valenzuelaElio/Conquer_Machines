using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using UnityEngine.UI;

public class DataManager{

    private Data dataMaster;
    public Data DataMaster { get { return dataMaster; } set { dataMaster = value; } }
    private static string path = "Assets/DataFolder/test001Xml.xml";

    public DataManager(string XMLpath)
    {
        path = XMLpath;
        dataMaster = new Data();

        dataMaster.Nodes[0] = new Node();
        dataMaster.Nodes[0].id = "N001";
        dataMaster.Nodes[0].rawMaterial1 = "iron";
        dataMaster.Nodes[0].rawMaterial2 = "copper";
        dataMaster.Nodes[0].rawMaterial3 = "aluminium";
        dataMaster.Nodes[0].cant1 = 10;
        dataMaster.Nodes[0].cant2 = 20;
        dataMaster.Nodes[0].cant3 = 30;

        dataMaster.Nodes[1] = new Node();
        dataMaster.Nodes[1].id = "N002";
        dataMaster.Nodes[1].rawMaterial1 = "aluminium";
        dataMaster.Nodes[1].rawMaterial2 = "iron";
        dataMaster.Nodes[1].rawMaterial3 = "copper";
        dataMaster.Nodes[1].cant1 = 40;
        dataMaster.Nodes[1].cant1 = 50;
        dataMaster.Nodes[1].cant1 = 60;

        dataMaster.ScenesNames[0] = "Main";
        dataMaster.ScenesNames[1] = "AssemblyLinesScene";
        //dataMaster.ScenesNames[2] = "Extractions";

        dataMaster.AssemblyLines[0] = new AssemblyLine();
        dataMaster.AssemblyLines[0].Id = "L001";
        dataMaster.AssemblyLines[0].AssemblyLineNodesId = new string[2];
        dataMaster.AssemblyLines[0].AssemblyLineNodesId[0] = "N001";
        dataMaster.AssemblyLines[0].AssemblyLineNodesId[1] = "N002";

        dataMaster.AssemblyLines[1] = new AssemblyLine();
        dataMaster.AssemblyLines[1].Id = "L002";
        dataMaster.AssemblyLines[1].AssemblyLineNodesId = new string[2];
        dataMaster.AssemblyLines[1].AssemblyLineNodesId[0] = "N003";
        dataMaster.AssemblyLines[1].AssemblyLineNodesId[1] = "N004";

        dataMaster.Robots[0] = new Robot();
        dataMaster.Robots[0].RobotID = "R001";
        dataMaster.Robots[0].LifePoints = 50;
        dataMaster.Robots[0].Durability = 100;
        dataMaster.Robots[0].EnergyCost = 20;

        dataMaster.Robots[1] = new Robot();
        dataMaster.Robots[1].RobotID = "R002";
        dataMaster.Robots[1].LifePoints = 70;
        dataMaster.Robots[1].Durability = 120;
        dataMaster.Robots[1].EnergyCost = 40;

        dataMaster.Misions[0] = new Mision();
        dataMaster.Misions[0].Id = "M001";
        dataMaster.Misions[0].Dificulty = 1;
        dataMaster.Misions[0].Requirements = "None";
        dataMaster.Misions[0].Description = "Lorem Ipsum : 100";
        dataMaster.Misions[0].Status = "Not Completed";

        dataMaster.Misions[1] = new Mision();
        dataMaster.Misions[1].Id = "M002";
        dataMaster.Misions[1].Dificulty = 1;
        dataMaster.Misions[1].Requirements = "M001";
        dataMaster.Misions[1].Description = "Lorem Ipsum : 100";
        dataMaster.Misions[1].Status = "Not Completed";



        SerializeData();


    }

    void Start () {

        //XMLOperator.Serialize(dataMaster, path);

        /*DataMaster = XMLOperator.Deserialize<Data>(path);
        ImprimirDatosDeNodos();

        for (int i = 0; i < DataMaster.Nodes.Length; i++)
        {
            text.text = text.text + DataMaster.Nodes[i].id + "\n";
            text.text = text.text + (DataMaster.Nodes[i].rawMaterial1 + " = " + DataMaster.Nodes[i].cant1 + "\n");
            text.text = text.text + (DataMaster.Nodes[i].rawMaterial2 + " = " + DataMaster.Nodes[i].cant2 + "\n");
            text.text = text.text + (DataMaster.Nodes[i].rawMaterial3 + " = " + DataMaster.Nodes[i].cant3 + "\n");
            text.text = text.text + ("---\n");
        }*/

    }

    void ImprimirDatosDeNodos()
    {
        for (int i = 0; i < DataMaster.Nodes.Length; i++)
        {
            Debug.Log(DataMaster.Nodes[i].id);
            Debug.Log(DataMaster.Nodes[i].rawMaterial1 + " = " + DataMaster.Nodes[i].cant1);
            Debug.Log(DataMaster.Nodes[i].rawMaterial2 + " = " + DataMaster.Nodes[i].cant2);
            Debug.Log(DataMaster.Nodes[i].rawMaterial3 + " = " + DataMaster.Nodes[i].cant3);
            Debug.Log("---");
        }
    }

    public void SerializeData()
    {
        XMLOperator.Serialize(dataMaster,path);
    }

    public Data DeserializeData()
    {
        return XMLOperator.Deserialize<Data>(path);
    }

}
