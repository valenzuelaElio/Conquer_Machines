using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;

public class DataManager : MonoBehaviourSingleton<DataManager> {
    string json;
    Data dataNodes;

    void Start () {

        string path = "Assets/test001Xml.xml";

        //Test = XMLOperator.Deserialize<AssemblyLine>(path);

        //dataNodes = XMLOperator.Deserialize<DataNodes>(path);

        dataNodes = XMLOperator.Deserialize<Data>(path); // Carga

        //dataNodes.Node = XMLOperator.Deserialize<Node>(path);

        for (int i = 0; i < dataNodes.Node.Length; i++ )
        {
            Debug.Log(dataNodes.Node[i].id);
            Debug.Log(dataNodes.Node[i].rawMaterial1);
        }
        //dataNodes.Node[0].id = "N001";
        //dataNodes.Node[0].rawMaterial1 = "copper";

        //dataNodes.Node[1] = new Node();
        //dataNodes.Node[1].id = "N002";
        //dataNodes.Node[1].rawMaterial1 = "iron";

        XMLOperator.Serialize(dataNodes, path); //Sube

        //Node node = new Node();
        //XMLOperator.Serialize(node, path);

        /*nodes = new List<Node>();

        for (int i = 4; i > 0; i--)
        {
            Node node = XMLOperator.Deserialize<Node>(path);
            nodes.Add(node);
            Debug.Log(i);

        }

        foreach (Node node in nodes)
        {
            Debug.Log(node.id);
            Debug.Log(node.rawMaterial1);
            Debug.Log(node.rawMaterial2);
            Debug.Log(node.rawMaterial3);
        }*/
        

    }

}
