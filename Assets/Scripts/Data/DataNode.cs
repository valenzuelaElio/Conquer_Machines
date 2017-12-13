using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

[Serializable]
public abstract class DataNode
{
    [XmlElement("ID")] public string node_id;
    [XmlElement("IDLineaDeEnsamblaje")] public string assemblyLine_id;
    [XmlElement("Sprite")] public string path;

    //Receta para creacion de nodos;
    [XmlElement("RawMaterial1")] public string rawMaterial1;
    [XmlElement("RawMaterial2")] public string rawMaterial2;
    [XmlElement("RawMaterial3")] public string rawMaterial3;
    [XmlElement("Quantity1")] public int cant1;
    [XmlElement("Quantity3")] public int cant3;
    [XmlElement("Quantity2")] public int cant2;

    [XmlIgnore] public Dictionary<string, int> Recipe;
    [XmlIgnore] public int spriteIndex;

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
