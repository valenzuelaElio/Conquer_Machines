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
    private Dictionary<string, Node> assemblyLineNodes;
    [XmlIgnore]
    public Dictionary<string, Node> AssemblyLineNodes {  get { return assemblyLineNodes; } }

    public AssemblyLine()
    {
        assemblyLineNodes = new Dictionary<string, Node>();
    }

    public void Assembly(string nodeID, Node node)
    {
        if (assemblyLineNodes.Count <= LineSize)
        {
            AddNode(nodeID, node);
        }
    }

    private void AddNode(string nodeID, Node node)
    {
        assemblyLineNodes.Add(nodeID, node);
    }


}
