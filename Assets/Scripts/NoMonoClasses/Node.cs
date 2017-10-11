using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

public class Node
{
    [XmlElement("NodeID")]
    public string id { get; set; }
    //Dictionary<string, int> recipe;

    [XmlElement("RawMaterial1")]
    public string rawMaterial1;
    [XmlElement("RawMaterial2")]
    public string rawMaterial2;
    [XmlElement("RawMaterial3")]
    public string rawMaterial3;

    [XmlElement("Quantity1")]
    public int cant1;
    [XmlElement("Quantity2")]
    public int cant2;
    [XmlElement("Quantity3")]
    public int cant3;

    public Node()
    {

    }


}
