using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class DataRobot{

    [XmlElement("ID")] public string robot_id;
    [XmlElement("Nombre")] public string robot_name;
    [XmlElement("Nivel")] public int robot_level;
    [XmlElement("Descripcion")] public string robot_Description;

    //Robot Stats;
    [XmlElement("Duration")] public float Duration;
    [XmlElement("LifePoints")] public int LifePoints;
    [XmlElement("EnergyCost")] public int EnergyCost;
    [XmlElement("Attack")] public int Attack;
    [XmlElement("Speed")] public int Speed;

    [XmlIgnore] public Dictionary<string, float> Robotstats;

    public DataRobot()
    {
        Robotstats = new Dictionary<string, float>();
    }

    private void InitializeStats()
    {
        Robotstats.Add("Duration", Duration);
        Robotstats.Add("LifePoints", LifePoints);
        Robotstats.Add("EnergyCost", EnergyCost);
        Robotstats.Add("Attack", Attack);
        Robotstats.Add("Speed", Speed);
    }

}
