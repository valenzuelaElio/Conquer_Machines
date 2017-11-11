using System;
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

    [XmlArray("Robots")]
    [XmlArrayItem("Robot", typeof(Robot))]
    public Robot[] Robots { get; set; }

    [XmlArray("ScenesNames")]
    [XmlArrayItem("SceneName", typeof(string))]
    public string[] ScenesNames { get; set; }

    [XmlArray("Misions")]
    [XmlArrayItem("Mision", typeof(Mision))]
    public Mision[] Misions { get; set; }

    [XmlArray("Extractors")]
    [XmlArrayItem("Extractor", typeof(Extractor))]
    public Extractor[] Extractors { get; set; }

    [XmlArray("RawMaterials")]
    [XmlArrayItem("RawMaterial", typeof(RawMaterial))]
    public RawMaterial[] RawMaterials { get; set; }

    public Data()
    {
        Nodes = new Node[2];
        ScenesNames = new string[10];
        AssemblyLines = new AssemblyLine[4];
        Robots = new Robot[5];
        Misions = new Mision[5];
        Extractors = new Extractor[2];
        RawMaterials = new RawMaterial[2];

    }
}
