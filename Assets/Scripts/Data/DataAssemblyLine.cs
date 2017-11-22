using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class DataAssemblyLine{
    //Elementos del XML
    [XmlElement("ID")] public string assembly_Line_Id;
    [XmlElement("Tiempo de generacion de robots")] public float robotGenTime;

    [XmlElement("Nodo Core")] public string core_id;
    [XmlElement("Nodo de Mejora 1")] public string upgrade_Node_1;
    [XmlElement("Nodo de Mejora 2")] public string upgrade_Node_2;
    [XmlElement("Nodo de Mejora 3")] public string upgrade_Node_3;

    [XmlElement("Robot ID")] public string robot_id;

    [XmlIgnore] public Core coreNode;
    [XmlIgnore] public Dictionary<string, Upgrade> Upgrade_Nodes;
    [XmlIgnore] public Dictionary<string, DataNode> AssemblyLineNodes;

    public DataAssemblyLine()
    {
        Upgrade_Nodes = new Dictionary<string, Upgrade>();
        AssemblyLineNodes = new Dictionary<string, DataNode>();
    }

    public void LoadAssemblyLine(Data data)
    {
        if (core_id != null)
            this.coreNode = searchCore(this.core_id, data);

        if (upgrade_Node_1 != null)
            this.Upgrade_Nodes.Add(this.upgrade_Node_1, searchUpgrades(this.upgrade_Node_1, data));
        if (upgrade_Node_2 != null)
            this.Upgrade_Nodes.Add(this.upgrade_Node_2, searchUpgrades(this.upgrade_Node_2, data));
        if (upgrade_Node_3 != null)
            this.Upgrade_Nodes.Add(this.upgrade_Node_3, searchUpgrades(this.upgrade_Node_3, data));

    }

    private Core searchCore(string core_id, Data data)
    {
        for (int i = 0; i < data.Core_Nodes.Length; i++)
        {
            if (data.Core_Nodes[i].node_id.Equals(core_id))
            {
                return data.Core_Nodes[i];
            }
        }
        return null;
    }

    private Upgrade searchUpgrades(string upgrade_id, Data data)
    {
        for (int i = 0; i < data.Upgrade_Nodes.Length; i++)
        {
            if (data.Upgrade_Nodes[i].node_id.Equals(upgrade_id))
            {
                return data.Upgrade_Nodes[i];
            }
        }
        return null;
    }

}
