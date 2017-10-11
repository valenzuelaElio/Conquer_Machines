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
    public Node[] Node { get; set; }


    public Data()
    {
        Node = new Node[2];
    }
}
