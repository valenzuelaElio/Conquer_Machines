using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System;

[Serializable]
public class DataMision {

    [XmlElement("ID")] public string mision_Id;
    [XmlElement("Nombre")] public string mision_Name;
    [XmlElement("Requerimientos")] public string Requirements;
    [XmlElement("Status")] public bool isCompleted;
    [XmlElement("Dificultad")] public int Dificulty;
    [XmlElement("Descripcion")] public string Description;
    [XmlElement("Cantidad de Enemigos")] public int EnemiesQnty;

    [XmlElement("NivelMinimodelDeck")] public int MinDeckLevel { get; set; }
    [XmlElement("NivelMaximodelDeck")] public int MaxDeckLevel { get; set; }

    [XmlElement("Reward1")] public String Reward1 { get; set; }
    [XmlElement("Cantidad1")] public int cant1 { get; set; }
    [XmlElement("Reward2")] public String Reward2 { get; set; }
    [XmlElement("Cantidad2")] public int cant2 { get; set; }
    [XmlElement("Reward3")] public String Reward3 { get; set; }
    [XmlElement("Cantidad3")] public int cant3 { get; set; }

    public DataMision()
    {

    }



}
