using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Extractor {

    [XmlElement("ExtractorID")]
    public string Id { get; set; }

    [XmlElement("RobotID")]
    public string RobotID { get; set; }

    [XmlElement("RawMaterialID")]
    public string RawMaterialID { get; set; }

    [XmlElement("RawMaterialCant")]
    public int RawMaterialCant { get; set; }

    [XmlElement("RobotCant")]
    public int RobotCant { get; set; }

    RawMaterial extractingMaterial;

    public Extractor()
    {

    }

}
