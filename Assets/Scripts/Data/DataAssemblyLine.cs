using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;

[Serializable]
public class DataAssemblyLine{
    //Elementos del XML
    [XmlElement("ID")] public string assembly_Line_Id;
    [XmlElement("LastTime")] public int LastTime;

    //Lista de Nodos
    [XmlElement("Nodo Core")] public string core_id;
    [XmlElement("NododeMejora1")] public string upgrade_Node_1;
    [XmlElement("NododeMejora2")] public string upgrade_Node_2;
    [XmlElement("NododeMejora3")] public string upgrade_Node_3;

    [XmlIgnore] public Core coreNode;
    [XmlIgnore] public Dictionary<string, Upgrade> Upgrade_Nodes;
    [XmlIgnore] public Dictionary<string, DataNode> AssemblyLineNodes;

    public DataAssemblyLine()
    {
        Upgrade_Nodes = new Dictionary<string, Upgrade>();
        AssemblyLineNodes = new Dictionary<string, DataNode>();
    }

}
