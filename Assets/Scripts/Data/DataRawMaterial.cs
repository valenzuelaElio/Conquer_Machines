using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System;

[Serializable]
public class DataRawMaterial {

    [XmlElement("ID")] public string RawMaterialID;
    [XmlElement("Nombre")] public string RawMaterialName;
    [XmlElement("Descripcion")] public string Description;
    [XmlElement("Rareza")] public int Rarity;
    [XmlElement("Sprite")] public string path;

    public DataRawMaterial()
    {

    }

}
