using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class AssemblyLine{
    //Elementos del XML
    [XmlElement("AssemblyLineID")]
    public string Id { get; set; }

    [XmlElement("AssemblyLineNodes")]
    public string[] AssemblyLineNodesId;

    [XmlElement("AssemblyLineSize")]
    public int LineSize { get { return AssemblyLineNodesId.Length; } }

    [XmlIgnore]
    private Dictionary<string, Node> AssemblyLineNodes;

    public AssemblyLine()
    {

    }

    public void Assembly(string nodeID, Node node)
    {
        if (AssemblyLineNodes.Count <= LineSize)
        {
            AddNode(nodeID, node);
        }
    }

    private void AddNode(string nodeID, Node node)
    {
        AssemblyLineNodes.Add(nodeID, node);
    }


}
