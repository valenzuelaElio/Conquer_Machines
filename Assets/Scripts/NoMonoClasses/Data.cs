﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

[Serializable()]
[XmlRoot("DataPool")]
public class Data
{
    [XmlArray("Nodes")] //[XmlArray(Nombre de la collecion)]
    [XmlArrayItem("Node", typeof(Node))]// [XmlArrayItem(Nombre en el archivo Xml, Tipo de la clase)]
    public Node[] Nodes { get; set; }

    [XmlArray("AssemblyLines")]
    [XmlArrayItem("AssemblyLine", typeof(AssemblyLine))]
    public AssemblyLine[] AssemblyLines { get; set; }

    [XmlArray("ScenesNames")]
    [XmlArrayItem("SceneName", typeof(string))]
    public string[] ScenesNames { get; set; }

    public Data()
    {
        Nodes = new Node[2];
        ScenesNames = new string[2];
        AssemblyLines = new AssemblyLine[2];

    }
}
