using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Enemy {

    [XmlElement("EnemyID")]
    public string EnemyID { get; set; }

    [XmlElement("EnemyName")]
    public string EnemyaName { get; set; }

    [XmlElement("Attack")]
    public int Attack { get; set; }

    [XmlElement("Defense")]
    public int Defense { get; set; }

    [XmlElement("LifePoints")]
    public int LifePoints { get; set; }

    [XmlElement("Speed")]
    public int Speed { get; set; }

    //[XmlElement("SpriteName")]
    //public int SpriteName { get; set; }

    public Enemy()
    {

    }


}
