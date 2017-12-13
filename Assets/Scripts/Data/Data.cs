using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("DataPool")]
public class Data
{
    [XmlArray("Nodes")]
    [XmlArrayItem("Node", typeof(DataNode))]
    public DataNode[] Nodes { get; set; }

    [XmlArray("AssemblyLines")]
    [XmlArrayItem("AssemblyLine", typeof(DataAssemblyLine))]
    public DataAssemblyLine[] AssemblyLines { get; set; }

    [XmlArray("Robots")]
    [XmlArrayItem("Robot", typeof(DataRobot))]
    public DataRobot[] Robots { get; set; }

    [XmlArray("ScenesNames")]
    [XmlArrayItem("SceneName", typeof(string))]
    public string[] ScenesNames { get; set; }

    [XmlArray("Misions")]
    [XmlArrayItem("Mision", typeof(DataMision))]
    public DataMision[] Misions { get; set; }

    [XmlArray("Extractors")]
    [XmlArrayItem("Extractor", typeof(DataExtractor))]
    public DataExtractor[] Extractors { get; set; }

    [XmlArray("RawMaterials")]
    [XmlArrayItem("RawMaterial", typeof(DataRawMaterial))]
    public DataRawMaterial[] RawMaterials { get; set; }

    public Data()
    {
        Nodes           = new DataNode[100];
        ScenesNames     = new string[7];
        AssemblyLines   = new DataAssemblyLine[100];
        Robots          = new DataRobot[100];
        Misions         = new DataMision[100];
        Extractors      = new DataExtractor[100];
        RawMaterials    = new DataRawMaterial[100];

    }
}
