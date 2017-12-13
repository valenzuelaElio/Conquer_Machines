using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;

[Serializable]
public class DataRobot{

    [XmlElement("ID")] public string robot_id;
    [XmlElement("Nombre")] public string robot_name;
    [XmlElement("Nivel")] public int robot_level;
    [XmlElement("Descripcion")] public string robot_Description;
    [XmlElement("Sprite")] public string path;

    //Robot Stats;
    [XmlElement("Duration")] public float Duration;
    [XmlElement("LifePoints")] public float LifePoints;
    [XmlElement("EnergyCost")] public int EnergyCost;
    [XmlElement("Attack")] public int Attack;
    [XmlElement("Speed")] public float Speed;

    [XmlIgnore] public Dictionary<string, float> Robotstats;

    public DataRobot()
    {
        Robotstats = new Dictionary<string, float>();
    }

    public void InitializeStats()
    {
        Robotstats.Add("Duration", Duration);
        Robotstats.Add("LifePoints", LifePoints);
        Robotstats.Add("EnergyCost", EnergyCost);
        Robotstats.Add("Attack", Attack);
        Robotstats.Add("Speed", Speed);
    }

}
