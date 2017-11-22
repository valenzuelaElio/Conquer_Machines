using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

public abstract class DataNode
{
    [XmlElement("ID")] public string node_id { get; set; }

    //Receta para creacion de nodos;
    [XmlElement("RawMaterial1")] public string rawMaterial1;
    [XmlElement("RawMaterial2")] public string rawMaterial2;
    [XmlElement("RawMaterial3")] public string rawMaterial3;
    [XmlElement("Quantity1")] public int cant1;
    [XmlElement("Quantity3")] public int cant3;
    [XmlElement("Quantity2")] public int cant2;

    [XmlIgnore]Dictionary<string, int> Recipe;

    public DataNode()
    {
        Recipe = new Dictionary<string, int>();
    }

    public void LoadRecipe()
    {
        Recipe.Add(rawMaterial1, cant1);
        Recipe.Add(rawMaterial2, cant2);
        Recipe.Add(rawMaterial3, cant3);
    }


}
