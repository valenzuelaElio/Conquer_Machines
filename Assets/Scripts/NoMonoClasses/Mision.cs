using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Mision {

    public enum Objective
    {
        Ob1,Ob2,Ob3,
    }

    [XmlElement("MisionID")]
    public string Id { get; set; }

    [XmlElement("MisionName")]
    public string MisionName { get; set; }

    [XmlElement("Requirements")]
    public string Requirements { get; set; }

    [XmlElement("Dificulty")]
    public int Dificulty { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }

    [XmlElement("Status")]
    public string Status { get; set; }

    [XmlElement("Enemies - Quantity")]
    public int EnemiesQuant { get; set; }

    [XmlElement("Mission - Objective")]
    public Objective MissionObjective { get; set; }

    public Mision()
    {

    }

}
