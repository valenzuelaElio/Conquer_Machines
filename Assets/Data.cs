using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

[Serializable()]
[XmlRoot("DataPool")]
public class Data
{
    //        nombre de la collecion 
    [XmlArray("Nodes")]
    //          nombreXML   Clase
    [XmlArrayItem("Node", typeof(Node))]
    public Node[] Nodes { get; set; }


    public Data()
    {
        Nodes = new Node[2];
    }
}
