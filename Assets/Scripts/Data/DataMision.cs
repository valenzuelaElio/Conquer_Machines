using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DataMision {

    [XmlElement("ID")] public string mision_Id;
    [XmlElement("Nombre")] public string mision_Name;
    [XmlElement("Requerimientos")] public string Requirements;
    [XmlElement("Status")] public bool isCompleted;
    [XmlElement("Dificultad")] public int Dificulty;
    [XmlElement("Descripcion")] public string Description;
    [XmlElement("Cantidad de Enemigos")] public int EnemiesQnty;

    [XmlElement("Nivel Minimo del Deck")] public int MinDeckLevel { get; set; }
    [XmlElement("Nivel Maximo del Deck")] public int MaxDeckLevel { get; set; }

    public DataMision()
    {

    }



}
