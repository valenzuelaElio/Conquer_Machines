using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

//El core esta encargado de generar a un robot en especifico cada cierto tiempo;
[Serializable]
public class Core : DataNode
{
    [XmlElement("GenerationTime")] public float generationTime;
    [XmlElement("RobotID")] public string robot_id; //Id del robot que estoy generando;

    [XmlIgnore] public bool Generate;
    [XmlIgnore] float StartTime;
    [XmlIgnore] float TimesTamp;

    public void Generating(float time)
    {
        TimesTamp = time - StartTime;
        if (TimesTamp > generationTime)
        {
            Generate = true;
            StartTime = time;
        }
        else
        {
            Generate = false;
        }
    }

    public void StartToGenerate()
    {
        this.StartTime = Time.time;
    }

}
