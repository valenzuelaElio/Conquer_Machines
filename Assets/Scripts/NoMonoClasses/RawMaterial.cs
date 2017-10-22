using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class RawMaterial {

    [XmlElement("RawMaterialID")]
    public string RawMaterialID { get; set; }

    [XmlElement("RawMaterialName")]
    public string RawMaterialName { get; set; }

    [XmlElement("ExtractionTimePerUnit")]
    public int ExtractionTimePerUnit { get; set; }

    public RawMaterial()
    {

    }

}
