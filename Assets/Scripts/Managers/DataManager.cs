using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using UnityEngine.UI;

public class DataManager : MonoBehaviourSingleton<DataManager> {

    private static Data dataMaster;
    public static Data Data { get { return dataMaster; } }
    string path = "Assets/DataFolder/test001Xml.xml";

    public Text text;

    void Start () {

        //dataNodes = XMLOperator.Deserialize<Data>(path); // Carga

        /*
        dataNodes = new Data();
        dataNodes.Nodes[0] = new Node();
        dataNodes.Nodes[0].id = "N001";
        dataNodes.Nodes[0].rawMaterial1 = "iron";
        dataNodes.Nodes[0].rawMaterial2 = "copper";
        dataNodes.Nodes[0].rawMaterial3 = "aluminium";
        dataNodes.Nodes[0].cant1 = 10;
        dataNodes.Nodes[0].cant2 = 20;
        dataNodes.Nodes[0].cant3 = 30;

        dataNodes.Nodes[1] = new Node();
        dataNodes.Nodes[1].id = "N002";
        dataNodes.Nodes[1].rawMaterial1 = "aluminium";
        dataNodes.Nodes[1].rawMaterial2 = "iron";
        dataNodes.Nodes[1].rawMaterial3 = "copper";
        dataNodes.Nodes[1].cant1 = 40;
        dataNodes.Nodes[1].cant1 = 50;
        dataNodes.Nodes[1].cant1 = 60;
        XMLOperator.Serialize(dataNodes, path); //Sube */

        Data = XMLOperator.Deserialize<Data>(path);
        ImprimirDatosDeNodos();

        for (int i = 0; i < Data.Nodes.Length; i++)
        {
            text.text = text.text + Data.Nodes[i].id + "\n";
            text.text = text.text + (Data.Nodes[i].rawMaterial1 + " = " + Data.Nodes[i].cant1 + "\n");
            text.text = text.text + (Data.Nodes[i].rawMaterial2 + " = " + Data.Nodes[i].cant2 + "\n");
            text.text = text.text + (Data.Nodes[i].rawMaterial3 + " = " + Data.Nodes[i].cant3 + "\n");
            text.text = text.text + ("---\n");
        }
    }

    void ImprimirDatosDeNodos()
    {
        for (int i = 0; i < Data.Nodes.Length; i++)
        {
            Debug.Log(Data.Nodes[i].id);
            Debug.Log(Data.Nodes[i].rawMaterial1 + " = " + Data.Nodes[i].cant1);
            Debug.Log(Data.Nodes[i].rawMaterial2 + " = " + Data.Nodes[i].cant2);
            Debug.Log(Data.Nodes[i].rawMaterial3 + " = " + Data.Nodes[i].cant3);
            Debug.Log("---");
        }
    }

    public static void SerializeData()
    {

    }

    public static void DeserializeData()
    {

    }

}
