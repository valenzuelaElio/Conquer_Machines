using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class Robot{

    [XmlElement("RobotID")]
    public string RobotID { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }

    //Robot Stats;
    [XmlElement("Probability_Of_Breaking")]
    public float ProbBreaking { get; set; }

    [XmlElement("Life")]
    public int LifePoints { get; set; }

    [XmlElement("EnergyCost")]
    public int EnergyCost { get; set; }

    [XmlElement("Attack")]
    public int Attack { get; set; }

    [XmlElement("AttackSpeed")]
    public int AttackSpeed { get; set; }

    [XmlIgnore]
    public float Attack_Speed { get { return (Attack / AttackSpeed) * 1.0f; } }

    public Robot()
    {

    }

}
