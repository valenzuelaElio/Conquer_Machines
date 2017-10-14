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


}
