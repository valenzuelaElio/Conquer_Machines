using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class Robot{

    [XmlElement("RobotID")]
    public string RobotID { get; set; }

    [XmlElement("Durability")]
    public float Durability { get; set; }

    [XmlElement("Life")]
    public int LifePoints { get; set; }

    [XmlElement("EnergyCost")]
    public int EnergyCost { get; set; }

    public Robot()
    {

    }

}
