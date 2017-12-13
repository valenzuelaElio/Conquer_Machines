using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class DataEnemy {

    [XmlElement("ID")] public string EnemyID { get; set; }
    [XmlElement("Nombre")] public string EnemyaName { get; set; }
    [XmlElement("Attack")] public int Attack { get; set; }
    [XmlElement("Defense")] public int Defense { get; set; }
    [XmlElement("LifePoints")] public int LifePoints { get; set; }
    [XmlElement("Speed")] public int Speed { get; set; }

    public DataEnemy()
    {

    }


}
