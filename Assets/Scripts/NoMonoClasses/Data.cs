using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

[Serializable()]
[XmlRoot("DataPool")]
public class Data
{
    [XmlArray("Nodes")] //[XmlArray(Nombre de la collecion)]
    [XmlArrayItem("Node", typeof(Node))]// [XmlArrayItem(Nombre en el archivo Xml, Tipo de la clase)]
    public Node[] Nodes { get; set; }

    public Data()
    {
        Nodes = new Node[2];
    }
}
